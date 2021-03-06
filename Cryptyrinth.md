# Cryptyrinth

## Game.cs
+ Run: Calls Start, repeats Update while GameOver == false, then calls End

+ Start: Calls InitializeItems, checks for SavaData.txt, and if there is SaveData, asks if the current user is the player that uses said SaveData
   * If the player is the one that previously saved to SaveData.txt, then Load is called
   * If not, then _player1_ is rebuilt, and GetGamemode is called, then the respective code is called:
     * Gamemode 1: FirstWeapon
     * Gamemode 2: _player2_ is created
+ Update: has a _gamemode_ switch:
   * Adventure mode:
    + _area_ switch; each area has an _explored_ bool that is set to true once the player has been through the respective case
    + In each area case, different overloads of GetAction area called with different options unique to that case, with each having the option 9: Nine Menu, which calls the NineMenu function
   * Player versus Player Mode:
    + GetAction reference so the user(s) can call the PvPBattle function, Call the DecideSpecialty function for either _player_, or Quit
+ End
   * If _gamemode_ is '1', then call a GetAction asking if the user would like Save to be called
   * If the resulting _action_ is '1', then Save is called. Otherwise, flavor is displayed
+ GetGamemode
   * Has a dowhile that checks for invalid input from a GetAction switch that allows the user to set the _gamemode_
   * Clears the console at the end
+ PvPStatDisplay
   * Writes out the value of _turnCounter_, and calls DisplayStats for both _players_
+ PvPBattle
   * Sets _InBattle_ bool to true
   * Enters a while(InBattle = true) loop that
    + Increments _turnCounter_
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
    + Calls Regenerate function for both _players_ if _player1action_ is '1', '2', '3', or '4'
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
    + Calls Regenerate functions for _player1_ and _enemy_ if _action_ is '1', '2', '3', or '4'
   * Checks to see if either _player1_ or _enemy_ had their health reach or fall below 0, and if either has, displays text and sets _GameOver_ to true and set _InBattle_ to false
+ IsDead
   * Checks to see if a Player's health is above 0. If yes, return true, otherwise display flavor text and return false
+ Pause
   * Displays flavor text and gets a ReadKey
+ ConvertEnemyAction
  + Used instead of casting because Attack uses a char instead of an int, and _enemyAction_ is sent through a Next randomizer with a weight of 2 on "Attack", so even if it could be converted with a cast or TryParse, then it still wouldn't work
  + Enters a switch for the passed in int
    + cases 0 and 1 set _newAction_ to '1'
    + case 2 sets _newAction_ to '2'
    + case 3 sets _newAction_ to '3'
    + case 4 sets _newAction_ to '4'
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
  + Calls NothingInitializer, enters a for loop which sets the "slots" to _nothing_, then calls EquipItem so _currentItem_ is _nothing_
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
  + Calls a GetAction to ask the user which "slot" they'd like to be set to the passed in Item, sets _invLocation_ to _action_ cast as an int, then sets _inventory_[_invLocation_] to the passed in Item, then calls a GetAction to ask if the user would like to set _currentItem_ to the passed in Item
+ EquipItem
  + If _hasItemEquipped_ is true, then GetAction is called to ask if the user would like to keep _currentItem_ as it is or set it to the passed in _item_, then enters a switch for _action_
    + If the player switches to the passed in _item_, (case '1') UnEquipItem is called to set _currentItem_ to _nothing_, then the stats of the passed in _item_ are set to the respective private values, _currentItem_ is set to the passed in _item_, _HasItemEquipped_ is set to true, _inventory[itemIndex]_ is set to the passed in _item_, then flavor text is displayed
    + The default case displays flavor text and nothing more
  + Otherwise, the values of the new _item_ are set to the respective private values, then flavor text is displayed, then _currentItem_ is set to the passed in _item_ and _HasItemEquipped_ is set to true, then _inventory[itemIndex]_ is set to the passed in _item_
+ UnequipItem
  + Subtracts the values of _statAddition_s and _statMultiplier_s of _currentItem_ from the respective private values, displays flavor text, sets _currentItem_ to _nothing_, then _HasItemEquipped_ is set to false
+ CheckInventory
  + Enters a for loop for every _Item_:
    + Prints i + 1, then _inventory_[i]._name_
+ InspectItem
  + Prints the name of the _item_ at _i_, then displays other stats if they are not the same as those of _nothing_. Afterwards, calls a GetAction to ask what the user would like done with _item_
  + As of now, there are two options: "[1: Equip]" and "[2: Discard]"
    + Case '1' calls EquipItem
    + Case '2' does nothing as of now
+ OpenInventory
  + If _HasItemEquipped_ is true, then displays _currentItem_ then calls a GetAction with the "options" being the names for each Item in _inventory_ and an additional option to call Unequip, then enters a switch for _action_ with each of the cases calling InspectItem for the respective _inventory_[position], or calls Unequip if _action_ is '6'
  + Otherwise, calls a GetAction with the "options" being the names for each Item in _inventory_, then enters a switch for _action_ with each of the cases calling InspectItem for the respective _inventory_[position]
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
  + _totalDefense_is set to _baseDefense_ added to _defenseAddition_ and _currentItem.defenseAddition_, the result of that being multiplied by _currentItem.defenseMultiplier_, then that number having _level_ added to it
  + _totalHealth_ is set to half of _totalDefense_ added to _baseHealth_ as well as _healthAddition_ and _currentItem.healthAddition_, the sum of those being multiplied by _currentItem.healthMultiplier_, then the result having _level_ added to it
  + _totalRegen_ is set to _baseHealthRegen_ added to _currentItem.healthRegenAddition_ and _healthRegenAddition_, the sum being multiplied by _currentItem.healthRegenMultiplier_, the result having the value of _level_ added to it
  + _totalDamage_ is set to _baseDamage added to _currentItem.damageAddition_ and _damageAddition_, the sum being multiplied by _currentItem.damageMultiplier_, and the result with _level_ added to it
  + _totalHeal_ is set to _baseHeal_ added to _currentItem.HealAddition_ and _healAddition_, their sum being multiplied by _currentItem.healMultiplier_, and that being added to _level_
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
+ SwitchItem
  + Calls GetAction to ask which item the user would like _currentItem_ to set _currentItem_ to, then enters an _action_ switch that calls EquipItem passing in respective ints and _inventory_ array locations
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
  + The query is written to the console, then the options are printed in order, then the choice char is set to the player's input through a ReadKey, and the value is returned

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
    + Otherwise, _totalDefense has _damage_ is subtracted from it, then depending on whether or not _totalDefense fell below or to 0, different flavor text is displayed
  + _name_, _totalHealth_, and _totalDefense_ are displayed
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
      + _wallEastX_ is set to _wallXEBorders_, then _wallSouthY are set to _wallXEBorders, and _wallNorthY + _wallYLengths_ are set to _labylocationY_
    + North (case 'n') enters a switch for _wallXLengths_:
      + If X lengths are 1, (case 1) _wallXEBorders_ and _wallXEBorders_ are set to the player's X location: _labyLocationX_
      + case 2: _wallXBorders_ are sent through a Next to make them either _labyLocationX_ or _labyLocationX_ + 1, then if _wallXWBorders_ are _labyLocationX_, then _wallXEBorders_ are set to _labyLocationX_ + 1. Otherwise, _wallXEBorders_ are set to _labyLocationX_. Either way, _wallXWBorders are set to _wallXEBorders - 1
      + case 3: _wallXWBorders_ are set to _labyLocationX_ - 1, and _wallXEBorders_ are set to _labyLocationX_ + 1
      + case 4: _wallEastX_ is set to _wallXEBorders_, then _wallSouthY are set to _wallXEBorders, and _wallNorthY are set to _labylocationY_ + _wallYLengths_
      + _wallNorthY_ is set to _labyLocationY_, then _wallSouthY_ is set to _labyLocationY_ + _wallYLengths_, then _wallSouthY_ are set to _labyLocationY_ and _wallNorthY are set to _labyLocationY_ + _wallYLengths_, and _wallEastX_ is set to _wallXEBorders_ and _wallEastX_ is set to _wallXWBorders_
    + East (case 'e') enters a switch for _wallYLengths_:
      + If _wallYLengths_ are 1 (case 1), the _wallNorthY_ are set to _labyLocationY_ and _wallSouthY_ are set to _labyLocationY_
      + case 2: _wallNorthY_ are sent through a Next to make them either _labyLocationY_ or _labyLocationY_ + 1, then if _wallSouthY_ are _labyLocationY_, then set _wallSouthY_ to _labyLocationY_ + 1. Otherwise set _wallSouthY_ to _labyLocationY_
      + case 3: _wallNorthY_ are set to _labyLocationY_ - 1 and _wallSBorders_ are set to _labyLocationY_ + 1
      + case 4: _wallNorthY are sent through a Next to make them either _labyLocationY_ or _labyLocationY_ + 1, then if _wallNorthY_ are _labyLocationY - 1, set _wallSouthY_ to _labyLocationY_ + 2. Otherwise, set _wallSBorders to _labyLocationY_ + 1
      + _wallXWBorders are set to _labyLocationX_, _wallXEBorders_ are set to _labyLocationX_ + _wallXLengths_, then _wallEastX_ is set to _labyLocationX, and _wallWestX_ is set to _labyLocationX_ + _wallYLengths_
    + West (case 'w') enters a switch for _wallYLengths_:
      + If _wallYLengths_ are 1, (case 1) the _wallNorthY_ are set to _labyLocationY_ and _wallSouthY_ are set to _labyLocationY_
      + case 2: _wallNorthY_ are sent through a Next to make them either _labyLocationY_ or _labyLocationY_ + 1, then if _wallSouthY_ are _labyLocationY_, then set _wallSouthY_ to _labyLocationY_ + 1. Otherwise set _wallSouthY_ to _labyLocationY_
      + case 3: _wallNorthY_ are set to _labyLocationY_ - 1 and _wallSBorders_ are set to _labyLocationY_ + 1
      + case 4: _wallNorthY_ are sent through a Next to make them anywhere from _labyLocationY_ - 1 to _labyLocationY_ + 2, then if _wallSouthY_ are _labyLocationY_ - 1, then set _wallSouthY_ to _labyLocationY_ + 2. Otherwise set _wallSBorders_ to _labyLocationY_ + 1
  + If the value of _labyLocationX_ is the same as that of _escapeDoorEX_ and the value of _labylocationY_ is the same as that of _escapeDoorEY_, then _CanEscapeW_ is set to true_
  + Else if the value of __labyLocationX_ is the same as that of _escapeDoorWX_ and the value of _labylocationY_ is the same as that of _escapeDoorWY_, then _CanEscapeE_ is set to true_
  + If the value of _escapeDoorWY_ is within or equal to those of _wallSouthY_ and _wallNorthY_, and the value of _escapeDoorWX_ is within or equal to those of _wallEastX_ and _wallWestX_, then set _CanEscapeW_ to true
  + If the value of _escapeDoorEY_ is within or equal to those of _wallSouthY_ and _wallNorthY_, and the value of _escapeDoorEX_ is within or equal to those of _wallEastX_ and _wallWestX_, then set _CanEscapeE_ to true
  + Based on the value of _facingDirection_, the values for _doorSouthChance_, _coorNorthChance_, _doorEastChance_, _doorWestChance_ are randomized from 1 to 50 if the cardinal direction in the _Chance_ variable name is not the opposite of _facingDirection_ (If it is, then the value is set to 50, guaranteeing that the next mentioned respective bool will be set to true), then the respective _DoorDirectionExists_ bool is set to whether or not the previously randomized numbers are greater than or equal to 25
  + If _DoorSouthExists_, then set the value of _doorSouthY_ to be somewhere from _wallXWBorders_ to _wallXEBorders_, and set _doorSouthX_'s value to be that of _wallSouthY_
  + If _DoorNorthExists_, then set the value of _doorNorthY_ to be somewhere from _wallXWBorders_ to _wallXEBorders_, and set _doorNorthX_'s value to be that of _wallSouthY_
  + If _DoorEastExists_, then check to see if _CanEscapeW_ is true. If it is, then set the value of _doorEastY_ to that of _escapeDoorWY and the value of _doorEastX_ to that of _escapeDoorWX_. Otherwise, set the value of _doorEastY_ to be somewhere from _wallNorthY_ to _wallSouthY_, and set _doorEast_'s value to be that of _wallEastX_
  + If _DoorEastExists_, then check to see if _CanEscapeE_ is true. If it is, then set the value of _doorWestY_ to that of _escapeDoorEY and the value of _doorWestX_ to that of _escapeDoorEX_. Otherwise, set the value of _doorWestY_ to be somewhere from _wallNorthY_ to _wallSouthY_, and set _doorWest_'s value to be that of _wallWestX_
  + RoomSizeAssigner is called
+ RoomSizeAssigner
  + Enters a _wallXLengths_ switch:
    + If the length of the X-running walls are 1, (case 1) enter a _wallYLengths_ switch:
      + If the lengths of the Y-running walls are 1, (case 1) set _roomShape_ to "1x1" and set _roomType_ to "square"
      + case 2: set _roomShape_ to "1x2" and _roomType_ to "rectangle"
      + case 3: set _roomShape_ to "1x3" and _roomType_ to "hallway"
      + case 4: set _roomShape_ to "1x4" and _roomType_ to "hallway"
    + case 2: enter a _wallYLengths_ switch:
      + If the lengths of the Y-running walls are 1, (case 1) set _roomShape_ to "1x2" and set _roomType_ to "rectangle"
      + case 2: set _roomShape_ to "2x2" and _roomType_ to "rectangle"
      + case 3: set _roomShape_ to "2x3" and _roomType_ to "rectangle"
      + case 4: set _roomShape_ to "2x4" and _roomType_ to "hallway"
    + case 3: enter a _wallYLengths_ switch:
      + If the lengths of the Y-running walls are 1, (case 1) set _roomShape_ to "1x3" and set _roomType_ to "hallway"
      + case 2: set _roomShape_ to "2x3" and _roomType_ to "rectangle"
      + case 3: set _roomShape_ to "3x3" and _roomType_ to "square"
      + case 4: set _roomShape_ to "3x4" and _roomType_ to "rectangle"
    + case 4: enter a _wallYLengths_ switch:
      + If the lengths of the Y-running walls are 1, (case 1) set _roomShape_ to "1x4" and set _roomType_ to "hallway"
      + case 2: set _roomShape_ to "2x4" and _roomType_ to "hallway"
      + case 3: set _roomShape_ to "3x4" and _roomType_ to "rectangle"
      + case 4: set _roomShape_ to "4x4" and _roomType_ to "square"
+ LabyrinthRoomText
  + Enters a _roomShape_ switch that writes different flavor text based off of the value of _roomShape_
  + Four if statements check the values of _DoorDirectionExists_, and if any apply, then a _roomType_ switch is entered with respectively descriptive flavor text
+ LabyrinthActionText
  + Runs through a series of if/else _DoorDirectionExists_ statements that display respectively descriptive flavor text. After these, prints "[9: Nine Menu]"
+ EnterLabyrinthW
  + sets _facingDirection_ to 'w', _oldLabyLocationX_ to _labyLocationX_, _oldLabyLocationY_ to _labyLocationY_, _labyLocationX_ to 5, and _labyLocationY_ to 25
  + Calls GenerateRoom, then sets _DoorEastExists_ to true
  + Not sure if setting _DoorEastExists_ to true after calling GenerateRoom would make "escaping" possible. I will look into this later
+ EnterLabyrinthE
  + sets _facingDirection_ to 'e', _oldLabyLocationX_ to _labyLocationX_, _oldLabyLocationY_ to _labyLocationY_, _labyLocationX_ to 9, and _labyLocationY_ to 22
  + Calls GenerateRoom, then sets _DoorWestExists_ to true
  + Same unsureness as previous function
+ DoSouth
  + If _DoorSouthExists_ is true, then sets _oldLabyLocationX_ to _labyLocationX_, _oldLabyLocationY_ to _labyLocationY_, _labyLocationX_ to _doorSouthX_, _labyLocationY to _doorSouthY_, then calls GenerateRoom
  + Otherwise, writes sarcastic flavor text
+ DoNorth
  + If _DoorNorthExists_ is true, then sets _oldLabyLocationX_ to _labyLocationX_, _oldLabyLocationY_ to _labyLocationY_, _labyLocationX_ to _doorNorthX_, _labyLocationY to _doorNorthY_, then calls GenerateRoom
  + Otherwise, writes sarcastic flavor text
+ DoEast
  + If _DoorEastExists_ is true, if _CanEscapeE_ is true, then calls _player_'s ChangeArea, passing in "LabyrinthEntryway". Otherwise, sets _oldLabyLocationX_ to _labyLocationX_, _oldLabyLocationY_ to _labyLocationY_, _labyLocationX_ to _doorEastX_, _labyLocationY to _doorEastY_, then calls GenerateRoom
  + Otherwise, writes sarcastic flavor text
+ DoWest
  + If _DoorWestExists_ is true, if _CanEscapeW_ is true, then calls _player_'s ChangeArea, passing in "LabyrinthEntryway". Otherwise, then sets _oldLabyLocationX_ to _labyLocationX_, _oldLabyLocationY_ to _labyLocationY_, _labyLocationX_ to _doorWestX_, _labyLocationY to _doorWestY_, then calls GenerateRoom
  + Otherwise, writes sarcastic flavor text
+ GoBack
  + Sets _labyLocationX_ to _oldLabyLocationX_ and _labyLocationY_ to _oldLabyLocationY_
+ Pause
  + Prints flavor text and gets a ReadKey

## Item.cs
+ Initial Constructor
  + Initialies all variables by setting them all to 0
+ Overload Constructor
  + Sets not currently private variables to passed in variables
  + Currently unused, as the Item class was a Struct thrown into a class
+ Save
  + Writes all variables to SaveData.txt
+ Load
  + Declares temporary values for a previously declared SaveData.txt StreamReader to read into, then does a TryParse for all non-string values:
    + Load is a bool function, and all the TryParses are within if statements. If any of the TryParses fail, the function returns false to prevent any half-loading
  + After TryParse for read-in values is run successfully, the private values are set to the respective temporary values, then StatCalculation is called, then the function returns true