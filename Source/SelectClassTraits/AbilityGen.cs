using Base;
using Base.Core;
using Base.Defs;
using Base.Entities.Abilities;
using PhoenixPoint.Common.Entities;
using PhoenixPoint.Common.Entities.Characters;
using PhoenixPoint.Tactical.Entities;
using PhoenixPoint.Tactical.Entities.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SelectClassTraits
{
    internal static class AbilityGen
    {
        internal static Dictionary<int, TacticalAbilityDef> GeneratePersonalTraits(int abilitiesCount, LevelProgressionDef levelDef, SpecializationDef soldierSpec, DefRepository defRepo)
        {
            try
            {
                //Logger.Debug($"[FactionCharacterGenerator_GeneratePersonalAbilities_POSTFIX] Generating SKILLLZ!");
                //Logger.Info($"Specialization for soldier is: {specBCT.ViewElementDef.DisplayName1.LocalizeEnglish()}");

                Dictionary<int, TacticalAbilityDef> dictionary = new Dictionary<int, TacticalAbilityDef>(); //dictionary to return
                List<TacticalAbilityDef> tmpList = new List<TacticalAbilityDef>();
                List<int> availableSlots = new List<int>(); //slots to fill with skills

                for (int i = 0; i < levelDef.MaxLevel; i++)
                {
                    availableSlots.Add(i);
                }



                List<TacticalAbilityDef> personalAbilityPool = new List<TacticalAbilityDef>(); //just temp
                (List<TacticalAbilityDef> PersonalAb, List<TacticalAbilityDef> TempList) = Support.SelectPersonalList(personalAbilityPool, Support.SkillsByClass(soldierSpec.name), abilitiesCount);

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
