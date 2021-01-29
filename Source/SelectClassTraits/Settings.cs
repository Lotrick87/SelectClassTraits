using System.Collections;
using System.Collections.Generic;

namespace SelectClassTraits
{
    internal class Settings
    {
        internal static IDictionary<string, Classes> ClassesDict = new Dictionary<string, Classes>(){
            { "Assault", new Classes(){ ClassDef = "AssaultSpecializationDef", ClassCount = 1 } },
            { "Sniper", new Classes(){ ClassDef = "SniperSpecializationDef", ClassCount = 1 } },
            { "Heavy", new Classes(){ ClassDef = "HeavySpecializationDef", ClassCount = 1 } },
            { "Infiltrator", new Classes(){ ClassDef = "InfiltratorSpecializationDef", ClassCount = 1 } },
            { "Technician", new Classes(){ ClassDef = "TechnicianSpecializationDef", ClassCount = 1 } },
            { "Berserker", new Classes(){ ClassDef = "BerserkerSpecializationDef", ClassCount = 1 } },
            { "Priest", new Classes(){ ClassDef = "PriestSpecializationDef", ClassCount = 1 } }
        };

        internal static IDictionary<string, IDictionary<string, int>> Setup()
        {
            IDictionary<string, IDictionary<string, int>> result = new Dictionary<string, IDictionary<string, int>>();
            IDictionary<string, int> defaultSkills = new Dictionary<string, int>() {
                { "RESOURCEFUL", 1 },
                { "TROOPER", 2 },
                { "SNIPERIST", 3 },
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

        public IDictionary<string, IDictionary<string, int>> SettingList = Setup();

        //old stuff to delete
        internal bool Assault = true;
        internal bool Sniper = true;
        internal bool Heavy = true;
        internal bool Infiltrator = true;
        internal bool Technician = true;
        internal bool Berserker = true;
        internal bool Priest = true;

        internal bool[] Resourceful = { true, true, true, true, true, true, true };
        internal bool[] Trooper = { true, true, true, true, true, true, true };
        internal bool[] Sniperist = { true, true, true, true, true, true, true };
        internal bool[] Reckless = { true, true, true, true, true, true, true };
        internal bool[] SelfDefense = { true, true, true, true, true, true, true };
        internal bool[] Healer = { true, true, true, true, true, true, true };
        internal bool[] Farsighted = { true, true, true, true, true, true, true };
        internal bool[] Cautious = { true, true, true, true, true, true, true };
        internal bool[] Thief = { true, true, true, true, true, true, true };
        internal bool[] Bombardier = { true, true, true, true, true, true, true };
        internal bool[] CloseQuarters = { true, true, true, true, true, true, true };
        internal bool[] Quarterback = { true, true, true, true, true, true, true };
        internal bool[] Strongman = { true, true, true, true, true, true, true };
        internal bool[] Biochemist = { true, true, true, true, true, true, true };

        // DebugLevel (0: nothing, 1: error, 2: debug, 3: info)
        public int Debug = 1;
    }

}
