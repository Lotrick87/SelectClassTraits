using Base.Core;
using Base.Defs;
using Base.Entities.Abilities;
using Harmony;
using PhoenixPoint.Common.Entities;
using PhoenixPoint.Common.Entities.Characters;
using PhoenixPoint.Common.Entities.GameTagsTypes;
using PhoenixPoint.Geoscape.Core;
using PhoenixPoint.Geoscape.Entities;
using PhoenixPoint.Geoscape.Levels;
using PhoenixPoint.Tactical.Entities;
using PhoenixPoint.Tactical.Entities.Abilities;
using PhoenixPoint.Tactical.Entities.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SelectClassTraits
{
    class HarmonyPatches
    {
		//Patch for FactionCharacterGenerator, Method: GenerateUnit - Add specialization to method call for GeneratePersonalAbilities
		[HarmonyPatch(typeof(FactionCharacterGenerator), "GenerateUnit")]
		public static class GenerateUnit_Patch
		{
			public static bool Prefix(ref GeoUnitDescriptor __result, GeoFaction faction, TacCharacterDef template, BaseStatSheetDef ___BaseStatsSheet, DefRepository ____defRepo)
			{
				try
				{
					if (template == null)
					{
						throw new Exception("Missing template for character");
					}

					GeoUnitDescriptor geoUnitDescriptor = new GeoUnitDescriptor(faction, new GeoUnitDescriptor.UnitTypeDescriptor(template));
					GeoUnitDescriptor.ProgressionDescriptor progressionDescriptor = null;

					foreach (ClassTagDef classTag in template.ClassTags)
					{
						SpecializationDef specializationByClassTag = Support.GetSpecializationByClassTag(classTag, ____defRepo.GetAllDefs<SpecializationDef>().ToList());

						if (specializationByClassTag != null)
						{
							if (progressionDescriptor == null)
							{
								Dictionary<int, TacticalAbilityDef> personalAbilitiesByLevel = AbilityGen.GeneratePersonalTraits(___BaseStatsSheet.PersonalAbilitiesCount, template.Data.LevelProgression.Def, specializationByClassTag, ____defRepo);
								progressionDescriptor = new GeoUnitDescriptor.ProgressionDescriptor(specializationByClassTag, personalAbilitiesByLevel);
							}
							else
							{
								progressionDescriptor.SecondarySpecDef = specializationByClassTag;
							}
						}
					}
					if (progressionDescriptor != null && template.Data.LevelProgression.IsValid)
					{
						progressionDescriptor.Level = template.Data.LevelProgression.Level;
						progressionDescriptor.ExtraAbilities.AddRange(template.Data.Abilites);
					}
					if (progressionDescriptor != null)
					{
						geoUnitDescriptor.Progression = progressionDescriptor;
					}
					geoUnitDescriptor.BonusStats = template.Data.BonusStats;
					geoUnitDescriptor.ArmorItems.AddRange(template.Data.BodypartItems.OfType<TacticalItemDef>());
					geoUnitDescriptor.Equipment.AddRange(template.Data.EquipmentItems.OfType<TacticalItemDef>());
					geoUnitDescriptor.Inventory.AddRange(template.Data.InventoryItems.OfType<TacticalItemDef>());
					__result = geoUnitDescriptor;

					return false;
				}
                catch(Exception e)
                {
					Logger.Error(e);
					return true;
                }
			}
		}

	}
}
