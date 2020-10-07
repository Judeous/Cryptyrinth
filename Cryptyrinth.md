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

## Character.cs
+ Heal
  + If _totalHeal_ is less than or equal to 5, then displays flavor text and nothing more
  + If _totalHeal_ is greater than 5, then _name_, _totalHealth_, and _totalDefense_ are displayed before and after adding _totalHeal_ to _totalHealth_
+ Attack
  + Checks to see if _defenderHealth_ is greater than 0, and if so, it enters a switch for _defenderAction_:
    + case '2' calls _defender_'s DefendAttack function
    + default calls _defender_'s GetDirectAttack function
+ GetDirectAttack
  + _name_, _totalHealth_, and _totalDefense_ are displayed before and after subtracting _attackerDamage_ from _totalHealth_
+ DefendAttack
  + If _totalDefense_ is 0, display flavor text then calls GetDirectAttack
  + Otherwise, display _name_, _totalHealth_, and _totalDefense_, then subtract _attackerDamage_ from _totalDefense_
  + If _totalDefense_ is now below or equal to 0, display flavor text, set _totalDefense_ back to 0
  + Otherwise, just display flavor text
  + _name_, _totalHealth_, and _totalDefense_ are displayed once more with the new values
+ Regenerate
  + If _totalHealth_ is less than _maxHealth_ and _totalHealth_ is greater than 0, then add _totalRegen_ to _totalHealth_
  + If the new value of _totalHealth_ is greater than _maxHealth_ then set _totalHealth_ to the value of _maxHealth_
+ DisplayStats
  + Prints _name_, _totalHealth_, _totalHeal_, _totalDamage_, and _totalDefense_
+ GetIsBot
  + returns _IsBot_
  + Nothing is done with this currently, but in the future I would like to add an option in that would allow one of the _players_ in PvPBattle to have their _action_ variable treated the same as _enemy_ in the AdventureBattle function
+ GetName
  + returns _name_
+ GetHealth
  + returns _totalHealth_
+ GetMaxHealth
  + returns _maxHealth_
+ GetHealthRegen
  + returns _totalregen_
+ Pause
  + prints out flavor text then gets a ReadKey

 ## Player.cs
+ Player Constructor
  + Initializes _inventory_, _baseHealth_, _baseHealthRegen_, _baseDefense_, _level_, _currentExperience_, _totalHeal_, _baseHeal_, _damageMultiplier_, _style_, _specialty_
  + Calls NothingInitializer, enters a for loop which sets the "slots" to _nothing_, then calls EquipItem, then EquipWeapon, so _currentItem_ and _currentWeapon_ are all _nothing_
+ Overload Player Constructor
  + Sets passed in values to the respective private values
+ NothingInitializer
  + Initializes the stats for _nothing_ Item, sets _statMultiplier_s to 1 and _statAddition_s to 0
+ Save
  + Uses previously declared SaveData.txt StreamWriter to write out the values needed for StatCalculation to set them back to where they were when Save was called during a previous run
+ Load
  + Declares temporary values for a previously declared SaveData.txt StreamReader to read into, then does a TryParse for all non-string values:
    + Load is a bool function, and all the TryParses are within if statements. If any of the TryParses fail, the function returns false to prevent any half-loading
  + After TryParse for read-in values is run successfully, the private values are set to the respective temporary values, then StatCalculation is called, then the function returns true
+ AddToInventory
  + Sets _inventory[inventoryLocation_ to the passed in _item_
+ EquipItem
  + If _hasItemEquipped_ is true, then GetAction is called to ask if the user would like to keep _currentItem_ as it is or set it to the passed in _item_, then enters a switch for _action_
    + If the player switches to the passed in _item_, (case '1') UnEquipItem is called to set _currentItem_ to _nothing_, then the stats of the passed in _item_ are set to the respective private values, _currentItem_ is set to the passed in _item_, _HasItemEquipped_ is set to true, _inventory[itemIndex]_ is set to the passed in _item_, then flavor text is displayed
    + The default case displays flavor text and nothing more
  + Otherwise, the values of the new _item_ are set to the respective private values, then flavor text is displayed, then _currentItem_ is set to the passed in _item_ and _HasItemEquipped_ is set to true, then _inventory[itemIndex]_ is set to the passed in _item_
+ EquipWeapon
  + Does the same as EquipItem, but using _HasWeaponEquipped_, _currentWeapon_, and _UnequipWeapon_
+ UnequipItem
  + Subtracts the values of _statAddition_s and _statMultiplier_s of _currentItem_ from the respective private values, displays flavor text, sets _currentItem_ to _nothing_, then _HasItemEquipped_ is set to false
+ UnEquipWeapon
  + If _currentWeapon.damageAddition_ is greater than 0, then text will be displayed showing the value of _damageAddition_ that will be subtracted from the private _damageAddition_
  + _damageAddition_ is subtracted from_baseDamage_, _damageMultiplier_ of _currentItem_ is subtracted from the private _damageMultiplier_, _currentWeapon_ is set to _nothing_, and _HasWeaponEquipped_ is set to false
+ CheckInventory
  + Enters a for loop for every _Item_:
    + Prints the name of the _item_ at _i_, then displays other stats if they are not the same as those of _nothing_
+ GainExperience
  + Displays the value of passed in _gainedExp_, adds that value to _currentExperience_, displays _currentExperience_ and _experinceRequirement_, and if _currentExperience_ is greater than _experinceRequirement_, then LevelUp is called
+ LevelUp
  + Enters a do/while loop that loops an invalid choice
    + Enters another do/while loop that continues while _currentExperince_ is greater than _experienceRequirement_
      + Flavor text is displayed, then GetAction is called, asking which of five stats the player would like to increment:
        + Health (case '1') increments _healthAddition_ by 5
        + Regen (case '2') increments _healthRegenAddition_ by 5
        + Heal (case '3') increments _healAddition_ by 5
        + Defense (case '4') increments _defenseAddition by 5
        + Damage (case '5') increments _damageAddition_ by 5
        + Split Evenly (case '6') increments all above by 1
      + Once a valid option is selected, _level_ is incremented, _experienceRequirement_ is subtracted from _currentExperince_, then StatCalculation is called
  + If _level_ is 10, then text is displayed, hinting at entering a previously inaccessible area
+ StatCalculation
  + _experinceRequirement_ is set to _level_ multiplied by 30
  + _totalDefense_is set to _baseDefense_ added to _currentWeapon.defenseAddition_, the result of that being multiplied by _currentWeapon.defenseMultiplier_, then that number having _level_ added to it
  + _totalHealth_ is set to half of _totalDefense_ added to _baseHealth_ as well as_currentItem.healthAddition_, the sum of those being multiplied by _currentItem.healthMultiplier_, then the result having _level_ added to it
  + _totalRegen_ is set to _baseHealthRegen_ added to _currentItem.healthRegenAddition_, the sum being multiplied by _currentItem.healthRegenMultiplier_, the result having the value of _level_ added to it
  + _totalDamage_ is set to _baseDamage added to _currentWeapon.damageAddition_, the sum being multiplied by _currentWeapon.damageMultiplier_, and the result with _level_ added to it
  + _totalHeal_ is set to _baseHeal_ added to _currentItem.HealAddition_, their sum being multiplied by _currentItem.healMultiplier_, and that being added to _level_
+ ChangeName
  + Enters a do/while the player is dissatisfied with their name:
    + Text is displayed, asking the user what they'd like _name_ to be set to, then does a ReadLine
    + Calls GetAction asking if the user is satisfied with the _input_ they gave
  + Sets private _name_ to _input_
+ StatCheck
  + Prints out _name_, _currentExperience_, _experienceRequirement_, _totalHealth_, _totalHealthRegen_, _totalHeal_, _totalDefense_, _totalDamage_, _level_, _style_, _specialty_
+ GetArea
  + returns _area_
+ ChangeArea
  + sets private _area_ to _newArea_
+ GetLevel
  + returns _level_
+ GetInventory
  + returns _inventory
+ GetSpecialty
  + returns _specialty_
+ GetWeapon
  + returns _currentWeapon_
+ GetItem
  + returns _currentItem_
+ OpenInventory
  + Displays flavor text, then enters a for loop for every _item_ in _inventory_
    + Prints out the position (Plus 1) then _inventory[i].name_
+ SwitchItem
  + Calls GetAction to ask which item the user would like _currentItem_ to be set to
+ DisplayStats
  + Prints _name_, _specialty_, _totalHealth_, _totalHeal_, _totalDamage_, totalDefense_
+ DecideSpecialty
  + Calls GetAction to ask the user which _style_ they would like _player_ to have, then enters a styleKey switch
    + Magic (case '1') displays the _baseHealth_, _baseHealthRegen_, _baseHeal_, _damageMult_, and _baseDefense_ of the four _specialties_ of the Magic _style_
    + Warrior (case '2') displays the _baseHealth_, _baseHealthRegen_, _baseHeal_, _damageMult_, and _baseDefense_ of the four _specialties_ of the Warrior _style_
    + Trickster (case '3') displays the _baseHealth_, _baseHealthRegen_, _baseHeal_, _damageMult_, and _baseDefense_ of the four _specialties_ of the Trickster _style_
    + In all three cases, GetAction is called to ask the user which of the four _specialties_ they would like the _player_ to be assigned to, then enters a _specialtyKey_ switch which assigns the values of the chosen _specialty_
+ GetAction (And all overloads)
  + Takes in a choice char, a string query, and varying amounts of strings for options
  + The query is written to the console, then the options are written in order, then the choice char is set to the player's input through a ReadKey, and the value is returned

## Enemy.cs
+ Enemy Constructor
  + initializes _totalHealth_, _totalHeal_, _damageMultiplier_, _baseDamage_, all of the strings in the _messages_ array, and the private _name_ is set to the passed in _name_, then EnemySetup is called
+ EnemySetup
  + Enters a switch for the private _name_ variable
    + For all cases, the values are set
  + _experience_ is set to _totalHealth_ multiplied by _damageMultiplier_, the result being added to _totalDamage_ and _totalDefense_
  + _maxHealth_ is assigned to the value of _totalHealth_
  + _totalDamage_ is set to _baseDamage_ multiplied by _damageMultiplier_
+ DisplayMessage
  + Enters a switch for passed in _message_
    + case "approach" displays messages[0]
    + case "attack" displays messages[1]
    + case "heal" displays messages[2]
    + case "defend" displays messages[3]
    + case "noDef" displays messages[4]
    + case "defDestroyed displays messages[5]
    + case "uselessDef" displays messages[6]
    + case "nothing" displays messages[7]
    + case "death" displays messages[8]
+ DefendAttack
  + Checks to see if _totalDefense_ is 0
    + If it is, then flavor text is displayed, and GetDirectAttack is called
    + Otherwise, _name_, _totalHealth_, and _totalDefense_ are displayed, then _totalDefense has _damage_ is subtracted from it, then depending on whether or not _totalDefense fell below or to 0, different flavor text is displayed, then _name_, _totalHealth_, and _totalDefense_ are displayed once more
+ GetExp
  + returns _experience

## Labyrinth
+ GenerateRoom
  + Randomizes the values of _wallXLengths_ and _wallYLengths_ between the value of _mixWallLength_ and _MaxWallLength_ then enters a switch for _facingDirection_ to assign values to room variables based on the value of _facingDirection_:
    + South (case 's') enters a switch for _wallXLengths_:
      + If X lengths are 1, (case 1) _wallXEBorders_ and _wallXEBorders_ are set to the player's X location: _labyLocationX_
      + case 2: _wallXBorders_ are sent through a Next to make them either _labyLocationX_ or _labyLocationX_ + 1, then if _wallXWBorders_ are _labyLocationX_, then _wallXEBorders_ are set to _labyLocationX_ + 1. Otherwise, _wallXEBorders_ are set to _labyLocationX_. Either way, _wallXWBorders are set to _wallXEBorders - 1
      + case 3: _wallXWBorders_ are set to _labyLocationX_ - 1, and _wallXEBorders_ are set to _labyLocationX_ + 1
      + case 4: _wallXBorders are randomized within the values of _labyLocationX_ and _labyLocationX_ + 1, then if _wallXWBorders_ are _labyLocationX_ - 1, then _wallXEBorders_ are set to _labyLocationX_ + 2. Otherwise, _wallXEBorders are set to _labyLocationX_ + 1
      + _wallEastX_ is set to _wallXEBorders_, then _wallYSBorders are set to _wallXEBorders, and _wallYNBorders + _wallYLengths_ are set to _labylocationY_
    + North (case 'n') enters a switch for _wallXLengths_:
      + If X lengths are 1, (case 1) _wallXEBorders_ and _wallXEBorders_ are set to the player's X location: _labyLocationX_
      + case 2: _wallXBorders_ are sent through a Next to make them either _labyLocationX_ or _labyLocationX_ + 1, then if _wallXWBorders_ are _labyLocationX_, then _wallXEBorders_ are set to _labyLocationX_ + 1. Otherwise, _wallXEBorders_ are set to _labyLocationX_. Either way, _wallXWBorders are set to _wallXEBorders - 1
      + case 3: _wallXWBorders_ are set to _labyLocationX_ - 1, and _wallXEBorders_ are set to _labyLocationX_ + 1
      + case 4: _wallEastX_ is set to _wallXEBorders_, then _wallYSBorders are set to _wallXEBorders, and _wallYNBorders are set to _labylocationY_ + _wallYLengths_
      + _wallNorthY_ is set to _labyLocationY_, then _wallSouthY_ is set to _labyLocationY_ + _wallYLengths_, then _wallYSBorders_ are set to _labyLocationY_ and _wallYNBorders are set to _labyLocationY_ + _wallYLengths_, and _wallEastX_ is set to _wallXEBorders_ and _wallEastX_ is set to _wallXWBorders_
    + East (case 'e') enters a switch for _wallYLengths_:
      + If _wallYLengths_ are 1 (case 1), the _wallYNBorders_ are set to _labyLocationY_ and _wallYSBorders_ are set to _labyLocationY_
      + case 2: _wallYNBorders_ are sent through a Next to make them either _labyLocationY_ or _labyLocationY_ + 1, then if _wallYSBorders_ are _labyLocationY_, then set _wallYSBorders_ to _labyLocationY_ + 1. Otherwise set _wallYSBorders_ to _labyLocationY_
      + case 3: _wallYNBorders_ are set to _labyLocationY_ - 1 and _wallSBorders_ are set to _labyLocationY_ + 1
      + case 4: _wallYNBorders are sent through a Next to make them either _labyLocationY_ or _labyLocationY_ + 1, then if _wallyNBorders_ are _labyLocationY - 1,