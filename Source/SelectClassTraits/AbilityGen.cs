using Base;
using PhoenixPoint.Common.Entities;
using PhoenixPoint.Common.Entities.Characters;
using PhoenixPoint.Tactical.Entities.Abilities;
using System;
using System.Collections.Generic;

namespace SelectClassTraits
{
    public static class AbilityGen
    {
        public static Dictionary<int, TacticalAbilityDef> GeneratePersonalTraits(int abilitiesCount, LevelProgressionDef levelDef, List<TacticalAbilityDef> personalAbilityPool, SpecializationDef specBCT)
        {
            try
            {
                //Logger.Debug($"[FactionCharacterGenerator_GeneratePersonalAbilities_POSTFIX] Generating SKILLLZ!");
                //Logger.Info($"Specialization for soldier is: {specBCT.ViewElementDef.DisplayName1.LocalizeEnglish()}");

                Dictionary<int, TacticalAbilityDef> dictionary = new Dictionary<int, TacticalAbilityDef>();
                List<TacticalAbilityDef> tmpList = new List<TacticalAbilityDef>();
                int maxLevel = levelDef.MaxLevel;
                List<int> availableSlots = new List<int>();
                for (int i = 0; i < maxLevel; i++)
                {
                    availableSlots.Add(i);
                }

                //List<TraitSetting> skills = Support.SkillsByClass(specBCT.name);

                (List<TacticalAbilityDef> PersonalAb, List<TacticalAbilityDef> TempList) = Support.SelectPersonalList(personalAbilityPool, Support.SkillsByClass(specBCT.name), abilitiesCount);

                if (PersonalAb != null || TempList != null)
                {
                    personalAbilityPool = PersonalAb;
                    tmpList = TempList;
                }
                else
                {
                    Logger.Debug($"no skills returned from SelecPersonalList!!!!");
                }

                int num = 0;
                while (num < abilitiesCount && personalAbilityPool.Count != 0)
                {
                    TacticalAbilityDef randomElement = personalAbilityPool.GetRandomElement();
                    if (randomElement != null)
                    {
                        personalAbilityPool.Remove(randomElement);
                        tmpList.Add(randomElement);
                        int slot = availableSlots.GetRandomElement();

                        //Logger.Info($"[FactionCharacterGenerator_GeneratePersonalAbilities_POSTFIX] slot: {slot}");
                        //Logger.Info($"[FactionCharacterGenerator_GeneratePersonalAbilities_POSTFIX] ability: {randomElement.ViewElementDef.DisplayName1.Localize()}");

                        availableSlots.Remove(slot);
                        //Logger.Info($"[FactionCharacterGenerator_GeneratePersonalAbilities_POSTFIX] availableSlots: {availableSlots.Count}");

                        dictionary.Add(slot, randomElement);
                        num++;
                    }
                    else
                    {
                        throw new NullReferenceException("Personal ability pool returned no TacticalAbilityDef");
                    }
                }
                personalAbilityPool.AddRange(tmpList);



                return dictionary;
                

            }
            catch (Exception e)
            {
                Logger.Error(e);
                return null;
            }
        }
    }
}
