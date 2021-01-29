using Base;
using Base.Defs;
using PhoenixPoint.Common.Entities;
using PhoenixPoint.Common.Entities.GameTagsTypes;
using PhoenixPoint.Tactical.Entities.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SelectClassTraits
{
    class Support
    {
        //FactionCharacterGenerator Method used by GenerateUnit
        internal static SpecializationDef GetSpecializationByClassTag(ClassTagDef classTag, List<SpecializationDef> SpecializationsDefs)
        {
            return SpecializationsDefs.FirstOrDefault((SpecializationDef t) => t.ClassTag == classTag);
        }

        internal static List<TacticalAbilityDef> SelectSkills(string soldierSpec, DefRepository defRep)
        {
            List<TacticalAbilityDef> skillList = new List<TacticalAbilityDef>();

            try
            {
                IDictionary<string, int> skills = GetClassDictionary(soldierSpec);
                List<TacticalAbilityDef> allAbilities = defRep.GetAllDefs<TacticalAbilityDef>().ToList();
                List<TacticalAbilityDef> viewEAbilities = (from p in defRep.GetAllDefs<TacticalAbilityDef>()
                                                           where p.ViewElementDef != null
                                                           select p).ToList();


                foreach (var sk in skills)
                {
                    if (sk.Value > 0)
                    {
                        bool found = false;
                        foreach (var aA in allAbilities)
                        {
                            if (aA.name == sk.Key)
                            {
                                skillList.Add(aA);
                                found = true;
                            }
                        }
                        if (!found)
                        {
                            foreach (var vEA in viewEAbilities)
                            {
                                if (vEA.ViewElementDef.DisplayName1.LocalizeEnglish() == sk.Key && !found)
                                {
                                    skillList.Add(vEA);
                                    found = true;
                                }
                            }
                        }
                        if (!found)
                        {
                            Logger.Debug($"Ability: {sk.Value}  was not found in AbilityDef");
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Logger.Error(e);
            }
            return skillList;
        }

        //get correct Dictionary for class from settings
        private static IDictionary<string, int> GetClassDictionary(string spec)
        {
            IDictionary<string, int> result = new Dictionary<string, int>();
            string className = null;

            foreach(var gcn in Settings.ClassesDict)
            {
                if(gcn.Value.ClassDef == spec)
                {
                    className = gcn.Key;
                }
            }

            foreach(var sl in new Settings().SettingList)
            {
                if(sl.Key == className)
                {
                    result = sl.Value;
                }
            }

            return result;
        }




        //old stuff to delete
        //inserts settings to list of objects
        internal static List<TraitSetting> SkillsByClass(string WhatClass)
        {
            int ClassNum = 0;
            bool ClassAllowed = false;

            switch (WhatClass)
            {
                case "AssaultSpecializationDef":
                    ClassNum = 0;
                    ClassAllowed = SelectClassTraits.Settings.Assault;
                    break;
                case "SniperSpecializationDef":
                    ClassNum = 1;
                    ClassAllowed = SelectClassTraits.Settings.Sniper;
                    break;
                case "HeavySpecializationDef":
                    ClassNum = 2;
                    ClassAllowed = SelectClassTraits.Settings.Heavy;
                    break;
                case "InfiltratorSpecializationDef":
                    ClassNum = 3;
                    ClassAllowed = SelectClassTraits.Settings.Infiltrator;
                    break;
                case "TechnicianSpecializationDef":
                    ClassNum = 4;
                    ClassAllowed = SelectClassTraits.Settings.Technician;
                    break;
                case "BerserkerSpecializationDef":
                    ClassNum = 5;
                    ClassAllowed = SelectClassTraits.Settings.Berserker;
                    break;
                case "PriestSpecializationDef":
                    ClassNum = 6;
                    ClassAllowed = SelectClassTraits.Settings.Priest;
                    break;
            }

            List<TraitSetting> AllowedTraits = new List<TraitSetting>();

            if (ClassAllowed) //if class is set to true select abilities based on settings
            {
                AllowedTraits.Add(new TraitSetting() { DefName = "Resourceful_AbilityDef", Allowed = SelectClassTraits.Settings.Resourceful[ClassNum] });
                AllowedTraits.Add(new TraitSetting() { DefName = "GoodShot_AbilityDef", Allowed = SelectClassTraits.Settings.Trooper[ClassNum] });
                AllowedTraits.Add(new TraitSetting() { DefName = "Focused_AbilityDef", Allowed = SelectClassTraits.Settings.Sniperist[ClassNum] });
                AllowedTraits.Add(new TraitSetting() { DefName = "Reckless_AbilityDef", Allowed = SelectClassTraits.Settings.Reckless[ClassNum] });
                AllowedTraits.Add(new TraitSetting() { DefName = "SelfDefenseSpecialist_AbilityDef", Allowed = SelectClassTraits.Settings.SelfDefense[ClassNum] });
                AllowedTraits.Add(new TraitSetting() { DefName = "Helpful_AbilityDef", Allowed = SelectClassTraits.Settings.Healer[ClassNum] });
                AllowedTraits.Add(new TraitSetting() { DefName = "Brainiac_AbilityDef", Allowed = SelectClassTraits.Settings.Farsighted[ClassNum] });
                AllowedTraits.Add(new TraitSetting() { DefName = "Cautious_AbilityDef", Allowed = SelectClassTraits.Settings.Cautious[ClassNum] });
                AllowedTraits.Add(new TraitSetting() { DefName = "Thief_AbilityDef", Allowed = SelectClassTraits.Settings.Thief[ClassNum] });
                AllowedTraits.Add(new TraitSetting() { DefName = "Crafty_AbilityDef", Allowed = SelectClassTraits.Settings.Bombardier[ClassNum] });
                AllowedTraits.Add(new TraitSetting() { DefName = "CloseQuartersSpecialist_AbilityDef", Allowed = SelectClassTraits.Settings.CloseQuarters[ClassNum] });
                AllowedTraits.Add(new TraitSetting() { DefName = "Pitcher_AbilityDef", Allowed = SelectClassTraits.Settings.Quarterback[ClassNum] });
                AllowedTraits.Add(new TraitSetting() { DefName = "Strongman_AbilityDef", Allowed = SelectClassTraits.Settings.Strongman[ClassNum] });
                AllowedTraits.Add(new TraitSetting() { DefName = "BioChemist_AbilityDef", Allowed = SelectClassTraits.Settings.Biochemist[ClassNum] });
            }
            else //if not select all abilites
            {
                AllowedTraits.Add(new TraitSetting() { DefName = "Resourceful_AbilityDef", Allowed = true });
                AllowedTraits.Add(new TraitSetting() { DefName = "GoodShot_AbilityDef", Allowed = true });
                AllowedTraits.Add(new TraitSetting() { DefName = "Focused_AbilityDef", Allowed = true });
                AllowedTraits.Add(new TraitSetting() { DefName = "Reckless_AbilityDef", Allowed = true });
                AllowedTraits.Add(new TraitSetting() { DefName = "SelfDefenseSpecialist_AbilityDef", Allowed = true });
                AllowedTraits.Add(new TraitSetting() { DefName = "Helpful_AbilityDef", Allowed = true });
                AllowedTraits.Add(new TraitSetting() { DefName = "Brainiac_AbilityDef", Allowed = true });
                AllowedTraits.Add(new TraitSetting() { DefName = "Cautious_AbilityDef", Allowed = true });
                AllowedTraits.Add(new TraitSetting() { DefName = "Thief_AbilityDef", Allowed = true });
                AllowedTraits.Add(new TraitSetting() { DefName = "Crafty_AbilityDef", Allowed = true });
                AllowedTraits.Add(new TraitSetting() { DefName = "CloseQuartersSpecialist_AbilityDef", Allowed = true });
                AllowedTraits.Add(new TraitSetting() { DefName = "Pitcher_AbilityDef", Allowed = true });
                AllowedTraits.Add(new TraitSetting() { DefName = "Strongman_AbilityDef", Allowed = true });
                AllowedTraits.Add(new TraitSetting() { DefName = "BioChemist_AbilityDef", Allowed = true });
            }

            return AllowedTraits;
        }

        internal static (List<TacticalAbilityDef> PersonalAb, List<TacticalAbilityDef> TempList) SelectPersonalList(List<TacticalAbilityDef> PersonalAbilitiesList, List<TraitSetting> SelectedTraits, int TraitCount)
        {
            try
            {
                List<TacticalAbilityDef> TempList = new List<TacticalAbilityDef>();

                //Find index of abilities to remove in PersonalAbilityPool
                int num = -1;
                int[] numList = new int[PersonalAbilitiesList.Count];

                for (int i = 0; i < PersonalAbilitiesList.Count; i++)
                {
                    for (int a = 0; a < SelectedTraits.Count; a++)
                    {
                        if (PersonalAbilitiesList[i].name == SelectedTraits[a].DefName && !SelectedTraits[a].Allowed)
                        {
                            num++;
                            numList[num] = i;
                        }
                    }
                }

                //remove unwanted abilities from pool
                while(num >= 0)
                {
                    //Logger.Debug($"SelectPersonalList Removing Ability: {PersonalAbilitiesList[numList[num]].ViewElementDef.DisplayName1.LocalizeEnglish()}");
                    TempList.Add(PersonalAbilitiesList[numList[num]]);
                    PersonalAbilitiesList.RemoveAt(numList[num]);
                    num--;
                }

                //if there is not enough abilities, re-add some random ones to pool
                while (PersonalAbilitiesList.Count < TraitCount)
                {
                    //Logger.Debug($"There wasnt Enough Traits left in list( {PersonalAbilitiesList.Count} < {TraitCount} ), adding random abilities to list");
                    TacticalAbilityDef randomElement = TempList.GetRandomElement();

                    if (randomElement != null)
                    {
                        TempList.Remove(randomElement);
                        PersonalAbilitiesList.Add(randomElement);
                        //Logger.Info($"Adding random ability to list: {randomElement.ViewElementDef.DisplayName1.LocalizeEnglish()}");
                    }
                    else
                    {
                        throw new NullReferenceException("Personal ability pool in SelectPersonalList returned no TacticalAbilityDef");
                    }
                }

                return (PersonalAbilitiesList, TempList);
            }
            catch(Exception e)
            {
                Logger.Error(e);
                return (null, null);
            }
        }

    }
}
