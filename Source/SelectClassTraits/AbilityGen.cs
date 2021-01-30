using Base;
using Base.Defs;
using PhoenixPoint.Common.Entities;
using PhoenixPoint.Common.Entities.Characters;
using PhoenixPoint.Tactical.Entities.Abilities;
using System;
using System.Collections.Generic;

namespace SelectClassTraits
{
    internal static class AbilityGen
    {
        internal static Dictionary<int, TacticalAbilityDef> GeneratePersonalTraits(int abilitiesCount, LevelProgressionDef levelDef, SpecializationDef soldierSpec, DefRepository defRepo, List<TacticalAbilityDef> personalAbilityPool)
        {
            try
            {
                Logger.Info($"Specialization for soldier is: {soldierSpec.ViewElementDef.DisplayName1.LocalizeEnglish()}");

                Dictionary<int, TacticalAbilityDef> dictionary = new Dictionary<int, TacticalAbilityDef>(); //dictionary to return
                List<TacticalAbilityDef> tmpList = new List<TacticalAbilityDef>();
                List<int> availableSlots = new List<int>(); //slots to fill with skills

                for (int i = 0; i < levelDef.MaxLevel; i++)
                {
                    availableSlots.Add(i);
                }

                (List<TacticalAbilityDef> skills, int classStat) = Support.SelectSkills(soldierSpec.name, defRepo);

                if (skills.IsEmpty())
                {
                    skills = personalAbilityPool;
                    Logger.Info($"SelectSkills returned no skills!");
                }

                if (skills.Count < abilitiesCount && personalAbilityPool.Count > 0 && !SelectClassTraits.Settings.LeaveEmpty) //if not enough skills and LeavyEmpty is not true, fill up from personalanilitypool
                {
                    List<TacticalAbilityDef> tmpList2 = new List<TacticalAbilityDef>();

                    foreach(var skl in skills) //check if some skills in personalabilitypool already are in skills and remove them
                    {
                        if (personalAbilityPool.Contains(skl))
                        {
                            tmpList2.Add(skl);
                            personalAbilityPool.Remove(skl);
                        }
                    }

                    while (skills.Count < abilitiesCount && personalAbilityPool.Count > 0) //fill up with random skills
                    {
                        TacticalAbilityDef rando = personalAbilityPool.GetRandomElement();
                        tmpList2.Add(rando);
                        skills.Add(rando);
                        personalAbilityPool.Remove(rando);
                        
                    }

                    personalAbilityPool.AddRange(tmpList2);
                }

                if(classStat != 1) //if class is not static generate skills randomly
                {
                    int num = 0;
                    while (num < abilitiesCount && skills.Count > 0)
                    {
                        TacticalAbilityDef randomElement = skills.GetRandomElement();
                        if (randomElement != null)
                        {
                            skills.Remove(randomElement);
                            tmpList.Add(randomElement);
                            int slot = availableSlots.GetRandomElement();

                            Logger.Info($"GeneratePersonalAbilities slot: {slot}   ability: {randomElement.ViewElementDef.DisplayName1.Localize()}");

                            availableSlots.Remove(slot);

                            dictionary.Add(slot, randomElement);
                            num++;
                        }
                        else
                        {
                            throw new NullReferenceException("skills list returned no TacticalAbilityDef");
                        }

                    }

                }
                else //if static just copy
                {
                    Logger.Info("Class is static:");
                    for(int i = 0; i < skills.Count && i < abilitiesCount; i++)
                    {
                        dictionary.Add(availableSlots[i], skills[i]);
                        Logger.Info($"i: {i}   slot: {availableSlots[i]}   skill: {skills[i].ViewElementDef.DisplayName1.LocalizeEnglish()}");
                    }
                }

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
