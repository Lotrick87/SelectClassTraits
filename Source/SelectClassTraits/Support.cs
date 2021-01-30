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

        //make list of skills to choose from
        internal static (List<TacticalAbilityDef>, int) SelectSkills(string soldierSpec, DefRepository defRep)
        {
            List<TacticalAbilityDef> skillList = new List<TacticalAbilityDef>();
            int classStat = 0;

            try
            {
                IDictionary<string, int> skills = GetClassDictionary(soldierSpec);
                List<TacticalAbilityDef> viewEAbilities = (from p in defRep.GetAllDefs<TacticalAbilityDef>()
                                                           where p.ViewElementDef != null && p.CharacterProgressionData !=null
                                                           select p).ToList();

                var skillsV = from p in skills
                              orderby p.Value ascending
                              select p;

                foreach (var sk in skillsV)
                {
                    if (sk.Value > 0 && sk.Key != "ClassAllowed" && sk.Key != "ClassStatic")
                    {
                        bool found = false;
                        foreach (var vEA in viewEAbilities)
                        {
                            if(( string.Equals(vEA.name, sk.Key, StringComparison.OrdinalIgnoreCase) || string.Equals(vEA.ViewElementDef.DisplayName1.LocalizeEnglish(), sk.Key, StringComparison.OrdinalIgnoreCase)) && !found)
                            {
                                skillList.Add(vEA);
                                found = true;
                            }
                        }
                        if (!found)
                        {
                            Logger.Debug($"Ability: {sk.Key}  was not found in AbilityDef and was not added to list!");
                        }
                    } 
                    else if (sk.Key == "ClassStatic")
                    {
                        classStat = sk.Value;
                    }
                }
            }
            catch(Exception e)
            {
                Logger.Error(e);
            }
            return (skillList, classStat);
        }
        
        //get correct Dictionary for class from settings
        private static IDictionary<string, int> GetClassDictionary(string spec)
        {
            IDictionary<string, int> result = new Dictionary<string, int>();
            string className = null;
            List<string> classNames = new List<string>();

            foreach(var gcn in Settings.ClassesDict)
            {
                if(gcn.Value.ClassDef == spec)
                {
                    className = gcn.Key;
                }
            }

            classNames = (from p in SelectClassTraits.Settings.SettingList
                         where p.Key.Contains(className) && p.Value["ClassAllowed"] > 0
                         select p.Key).ToList();

            if (!classNames.IsEmpty()) 
            {
                className = classNames.GetRandomElement();
            }

            Logger.Debug($"className is: {className}");
            foreach(var sl in SelectClassTraits.Settings.SettingList)
            {
                if(sl.Key == className)
                {
                    result = sl.Value;
                }
            }

            return result;
        }
    }
}
