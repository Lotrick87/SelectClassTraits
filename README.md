Change what Personal Traits you get for each class of soldiers.

This mod will let you select through Modnix / Config which personal traits you want each class of soldier to be able to get. You can either change only some classes, change some skills for certain class, or disable some skills completely.

All is configurable through Modnix / Config

What this mod does:
It will let you choose which Personal Traits(Passive skills) each class of soldier can get.

What it does not do:
It will not change how many Personal Traits(Passive Skills) you get - Vanilla game limit is 3. You can use mod Assorted Adjustments﻿ from mad234269 to do that.

Installation:
1. Mod requires Modnix, version 2.5.5 or newer recommended:
 - Modnix on Nexus﻿
 - Modnix on GitHub

2. Download and Add Mod in Modnix:
 - Hot to Add Mod in Modnix﻿

3. In Modnix, after installing and selecting mod click on Config, you can change all settings there. Also there is some explanation about settings in Readme(also in Modnix)

Config:

After Installing mod in Modnix go to Config Tab of this mod, inside Modnix.

Choose Mods for each class:

LeaveEmpty:
false - will fill all available skill slots(Vanilla 3), if not enough skills is selected it will use Vanilla Personal traits to fill the rest
true - will leave empty slots

SettingList:
-contains all information about class / build and skill selection

for each class / build:

ClassAllowed:
-if 0 Class is disabled, if all classes / builds are disabled it will use Vanilla Ability pool
-if 1 Class is enabled

ClassStatic:
-if 0 - Random selected skills assigned to random slots
-if 1 - selected skills are chosen in the ascending order indicated by the number behind skill name / def in Config
-Example: "Reckless": 10, "Trooper": 1, "Sniperist": 2 - skills will be in order: Trooper, Sniperist, Reckless

Skills:
-any skill in the game(which has CharacterProgressionData in it's AbilityDef - basically any available to Phoenix) can be asigned, even active skills
-you can even remove(delete) or add any number of skills to each build
-preferred way to add skills is to use their AbilityDef, not name(there are multiple skills in game with same name, but different Def - so while names are supported, the result may be random). Make sure you keep Syntax( the way Config is writen ), when adding or removing skills - Modnix should inform you if you make bad changes.
-Example: 
"Assault1": {
      "ClassAllowed": 1,
      "ClassStatic": 1,
      "RESOURCEFUL": 1,
      "Priest_MindControl_AbilityDef": 2,
      "Focused_AbilityDef": 3,
      "Dash_AbilityDef": 4,
    },
-number behind skill Def / name indicates whether it is disabled( if 0), or enabled ( if is bigger than 0)
-number also indicates poistion of skill in the list, if ClassStatic is set to 1


Notes:
Requires Modnix 2.5.5 or higher

Tested on 1.9.1 GOG Version of the game, with Modnix 2.5.5+

Thanks:
mad234269 - for leting me use few parts of his code and for his great mod AssortedAdjustments(log function mod was awesome help :-) )
Sheepy - for his awesome Wiki on Modnix, C#, and mod creation
