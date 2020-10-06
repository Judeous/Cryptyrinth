# Cryptyrinth

## Game.cs
+ Run: Calls Start, repeats Update while GameOver == false, then calls End

+ Start: Calls InitializeItems, checks for SavaData.txt, and if there is SaveData, asks if the current user is the player that uses said SaveData
   * If the player is the one that previously saved to SaveData.txt, then Load is called
   * If not, then _player1_ is rebuilt, and GetGamemode is called, then the respective functions are called:
     * Gamemode 1: FirstWeapon
     * Gamemode 2: _player2_ is created
+ Update: has a _gamemode_ switch:
   * Adventure mode:
    + _area_ switch; each area has an _explored_ bool that is set to true once the player has been through the respective case
    + In each area case, different overloads of GetAction area called with different options unique to that case, with each having the option 9: Nine Menu, which calls the NineMenu function
   * Player versus Player Mode:
    + GetAction reference so the user(s) can call the PvPBattle function, Call the DecideSpecialty function for either _player_, or Quit
+ GetGamemode
   * Has a dowhile that checks for invalid input from a GetAction switch that allows the user to set the _gamemode_
   * Clears the console at the end
+ PvPStatDisplay
   * Writes out the value of _turncounter_, and calls DisplayStats for both _players_
+ PvPBattle
   * Sets _InBattle_ bool to true
   * Enters a while(InBattle = true) loop that
    + Increments _turncounter_
    + Calls PvPStatDisplay
    + Sets _player1action_ = ' '
    + Writes _player1_'s name, then calls GetAction with the four standard battle options: Attack, Block, Heal, and Nothing. Repeats for _player2_
    + Enters a _player1action_ switch
      + The Attack ('1') case checks _player2action_:
        + If _player2action_ is Defend, ('2') then a flavor message is displayed
        + _player1_'s Attack function is called, then the IsDead function checks to see if _player2_'s health fell to or below 0
        + If _player2action_ is Attack, ('1') then a flavor message is displayed
        + _player2_'s Attack function is called, then the IsDead function is called
        + Else if _player2action_ is Heal, ('3') then a flavor message is displayed
        + _player2's_ Heal function is called
      + The Defend ('2') case enters a switch for _player2action_:
        + The Attack ('1') case calls _player2_'s Attack function then IsDead for _player1_
        + The Defend ('2') case displays flavor text and nothing more
        + The Heal ('3') case calls _player2_'s Heal function
        + The Nothing ('4') case displays flavor text and nothing more
      + The Heal ('3') case enters a switch for _player2action_:
        + The Attack ('1') case displays flavor text, then calls _player1_'s Heal function, then calls _player2_'s Attack function
        + The Defend ('2') case displays flavor text, then calls _player1_'s Heal function
        + The Heal ('3') case calls _player1_'s Heal function, displays flavor text, then calls _player2_'s Heal function
        + The Nothing ('4') case only calls _player1_'s Heal function
      + The Nothing ('4') case enters a switch for _player2action_:
        + The Attack ('1') case calls _player2_'s Attack function then IsDead for _player1_
        + The Defend ('2') case displays flavor text and nothing more
        + The Heal ('3') case fisplays flavor text then calls _player2_'s Heal function
        + The Nothing '4') case displays flavor text and nothing more
      + Default decrements _turnCounter_ to act as if nothing happened
    + If _InBattle_ is still true, checks for various combinations of _health_ being at _maxHealth_, and displays flavor text accordingly
    + Calls Regenerate function for both _players_
   * Checks to see if either _player_ had their health reach or fall below 0, and if either has, displays text and sets _GameOver_ to true and set _InBattle_ to false
+ AdventureBattle
   * Sets _InBattle_ to true, calls _enemy_.EnemySetup, clears the console, sets _turnCounter_ to 0, the enters a while (InBattle ==true) loop
    + Increments turn counter, writes out the value of _turnCounter_, calls DisplayStats for _player1_ and _enemy_, randomizes _enemyAction_ with a weight of 2 towards Attack (0 and 1 both Attack)
    + Calls GetAction with the four standard battle options: Attack, Block, Heal, and Nothing for _action_
    + Enters a switch for _action_:
      + The Attack ('1') case checks _enemyAction:
        + If _enemyAction_ is Defend, (2) then a flavor message is displayed
        + _player1_'s Attack function is called, then the IsDead function checks to see if _enemy_'s health fell to or below 0
        + If _enemyAction_ is Attack, (1 or 0) _player1_'s Attack function is called, then a flavor message is displayed
        + _enemy_'s Attack function is called, then the IsDead function is called
        + Else if _enemyAction_ is Heal, (3) then a flavor message is displayed
        + _enemy_'s Heal function is called
      + The Defend ('2') case checks to see if enemyAction is 1 or 0 before entering a switch for _enemyAction_:
        + The Attack (1 or 0) calls _enemy_'s Attack function then IsDead for _player1_
        + The Defend (2) case displays flavor text and nothing more
        + The Heal (3) case calls _enemy_'s Heal function after displaying flavor text
        + The Nothing (4) case displays flavor text and nothing more
      + The Heal ('3') case enters a switch for _enemyAction_:
        + The Attack (1) case displays flavor text, then calls _player1_'s Heal function, then calls _enemy_'s Attack function
        + The Defend (2) case displays flavor text, then calls _player1_'s Heal function
        + The Heal (3) case calls _player1_'s Heal function, displays flavor text, then calls _enemy_'s Heal function
        + The Nothing (4) case only calls _player1_'s Heal function
      + The Nothing ('4') case enters a switch for _enemyAction_ after checking to see if it's 1 or 0:
        + The Attack (1) case calls _enemy_'s Attack function then IsDead for _player1_
        + The Defend (2) case displays flavor text and nothing more
        + The Heal (3) case fisplays flavor text then calls _enemy_'s Heal function
        + The Nothing (4) case displays flavor text and nothing more
      + If InBattle is still true, checks for various combinations of _health_ being at _maxHealth_, and displays flavor text accordingly
    + Calls Regenerate functions for _player1_ and _enemy_
   * Checks to see if either _player1_ or _enemy_ had their health reach or fall below 0, and if either has, displays text and sets _GameOver_ to true and set _InBattle_ to false
+ IsDead
   * Checks to see if a Player's health is above 0. If yes, return true, otherwise display flavor text and return false
+ End
   * Empty
+ Pause
   * Displays flavor text and gets a ReadKey
+ InitializeItems
   * Sets names and values for items
+ FirstWeapon
  + Calls a GetAction asking the user which Item they would like, then enters a switch based on their input, and calls _player1_'s AddToInventory function depending on the input
+ NineMenu
  + Calls a GetAction with 6 choices:
    + Case '1' only breaks out of the switch, despite the option saying Return to game, which, yes it does return to the game, but sending it to default would do the same
    + Case '2', Return to game, calls the OpenInventory function for _player1_
    + Case '3', Switch Item, calls the SwitchItem function for _player1_
    + Case '4', Check Stats, calls the StatCheck function for _player1_
    + Case '8', Change Name, calls the ChangeName function for _player1_
    + Case '0', Quit, calls GetAction to ask if the user is sure they'd like to leave, and if input is '1', then _GameOver_ is set to true, and GetAction is called again to ask if the user would like to Save, and if input is '1', then the Save function is called, then the program ends. If not, then flavor text is displayed and the program ends
+ Save
  + Declares a Streamwriter for SaveData.txt, calls _player1_'s Save function, then writes out the values of all the _AreaExplored_ bools, then closes the Writer.
+ Load
  + First, checks to see if SaveData.txt exists. If not, then it returns false. If it does exist, then it calls _player1_'s return function, declares temporary values to hold read values from SaveData.txt, then TryParse is tried on all read values, and if those are successful, then the temporary values are set to the respective real values. The reader is them closed, and the function returns true
+ GetAction (And all overloads)
  + Takes in a choice char, a string query, and varying amounts of strings for options
  + The query is written to the console, then the options are written in order, then the choice char is set to the player's input through a ReadKey, and the value is returned