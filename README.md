
Change what Personal Traits you get for each class of soldiers.

This mod will let you select through Modnix / Config which personal traits you want each class of soldier to be able to get. You can either change only some classes, change some skills for certain class, or disable some skills completely.

All is configurable throu


Installation:
1. Mod requires Modnix, version 2.5.5 or newer recommended:
 - Modnix on Nexus﻿
 - Modnix on GitHub

2. Download and Add Mod in Modnix:
 - Hot to Add Mod in Modnix﻿

3. In Modnix, after installing and selecting mod click on Config, you can change all settings there. Also there is some explanation about settings in Readme(also in Modnix)

Config:

After Installing mod in Modnix go to Config Tab of this mod, inside Modnix.

Choose which classes you want to change:

  "Assault": true, /if set to false Assault Class will use Vanilla Traits
  "Sniper": true, /if set to false Sniper Class will use Vanilla Traits
  "Heavy": true, /if set to false Heavy Class will use Vanilla Traits
  "Infiltrator": true, /if set to false Infiltrator Assault Class will use Vanilla Traits
  "Technician": true, /if set to false Technician Class will use Vanilla Traits
  "Berserker": true, /if set to false Berserker Class will use Vanilla Traits
  "Priest": true, /if set to false Priest Class will use Vanilla Traits

  Under each trait, choose if class can roll for it(true) or not(false). Classes are always listed in order:
Assault
Sniper
Heavy
Infiltrator
Technician
Berserker
Priest

for Example:
  "Resourceful": [
    false,   /Assault will not be able to get this Trait
    true,    /Sniper will be able to get this Trait
    false,    /Heavy will not be able to get this Trait
    true,   /Infiltrator  will be able to get this Trait
    true,   /Technician  will be able to get this Trait
    true,   /Berserker  will be able to get this Trait
    true   /Priest  will be able to get this Trait
  ],
  If you select less Traits for Class, than is generated in the game(Vanilla generates 3 Traits), missing Traits will be Filled with Random Traits from disabled list.

Notes:
Requires Modnix 2.5.5 or higher



Thanks:
mad234269 - for leting me use few parts of his code and for his great mod AssortedAdjustments(log function mod was awesome help :-) )
Sheepy - for his awesome Wiki on Modnix, C#, and mod creation
