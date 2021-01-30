Config:

LeaveEmpty: false - will fill all skills slots, even if not enough skills selected
					(will use personal traits to fill)
			true - will leave empty slots

SettingList:
-contains list of skills for each class / build
-ClassAllowed - if 0 Class is disabled
-ClassStatic - if 1 Class will be static(skills will not be generated randomly,
	but by the ascending order of numbers, that are behind each skill in Config)
-skills can be any skills in the game, which have CharacterProgressionData,
	not only Passive Traits
-you can remove(delete) or add any number of skills, 
	preferred is to use AbilityDef(there are multiple Defs using the same name),
	so the result of using name may not be what you expected, but mod supports both ways
	Example: Def: Dash_AbilityDef, name: DASH
	Example2: Def: ExtraMove_AbilityDef, name: DASH
-if skill number is 0, skill is disabled Example: "RESOURCEFUL": 0
-if skill number is higher than 0 skill is enabled, number is also used to set
	skill order, if ClassStatic is set to 1