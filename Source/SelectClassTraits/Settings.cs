using System.Collections.Generic;

namespace SelectClassTraits
{
    internal class Settings
    {
        public bool LeaveEmpty = false;
        public IDictionary<string, IDictionary<string, int>> SettingList = Setup();

        // DebugLevel (0: nothing, 1: error, 2: debug, 3: info)
        public int Debug = 2;

        internal static IDictionary<string, Classes> ClassesDict = new Dictionary<string, Classes>(){
            { "Assault", new Classes(){ ClassDef = "AssaultSpecializationDef", ClassCount = 3 } },
            { "Sniper", new Classes(){ ClassDef = "SniperSpecializationDef", ClassCount = 3 } },
            { "Heavy", new Classes(){ ClassDef = "HeavySpecializationDef", ClassCount = 3 } },
            { "Infiltrator", new Classes(){ ClassDef = "InfiltratorSpecializationDef", ClassCount = 3 } },
            { "Technician", new Classes(){ ClassDef = "TechnicianSpecializationDef", ClassCount = 3 } },
            { "Berserker", new Classes(){ ClassDef = "BerserkerSpecializationDef", ClassCount = 3 } },
            { "Priest", new Classes(){ ClassDef = "PriestSpecializationDef", ClassCount = 3 } }
        };

        internal static IDictionary<string, IDictionary<string, int>> Setup()
        {
            IDictionary<string, IDictionary<string, int>> result = new Dictionary<string, IDictionary<string, int>>();
            IDictionary<string, int> defaultSkills = new Dictionary<string, int>() {
                { "ClassAllowed", 1 },
                { "ClassStatic", 0 },
                { "RESOURCEFUL", 1 },
                { "TROOPER", 2 },
                { "Focused_AbilityDef", 3 },
                { "RECKLESS", 4 },
                { "SELF DEFENSE SPECIALIST", 5 },
                { "HEALER", 6 },
                { "FARSIGHTED", 7 },
                { "CAUTIOUS", 8 },
                { "THIEF", 9 },
                { "BOMBARDIER", 10 },
                { "CLOSE QUARTERS SPECIALIST", 11 },
                { "QUARTERBACK", 12 },
                { "STRONGMAN", 13 },
                { "BIOCHEMIST", 14 }
            };

            foreach(var cld in ClassesDict)
            {
                if(cld.Value.ClassCount > 0)
                {
                    for(int i = 1; i <= cld.Value.ClassCount; i++)
                    {
                        result.Add( cld.Key + i , defaultSkills);
                    }
                }
            }

            return result;
        }
    }

}
