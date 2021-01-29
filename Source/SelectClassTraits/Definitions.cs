namespace SelectClassTraits
{
    class TraitSetting
    {
        public string DefName;
        public bool Allowed;
    }

    class ClassDef
    {
        public bool ClassAllowed = true;
        public bool Resourceful = true;
        internal string ResourcefulDef = "Resourceful_AbilityDef";
        public bool Trooper = true;
        internal string TrooperDef = "GoodShot_AbilityDef";
        public bool Sniperist = true;
        internal string SniperistDef = "Focused_AbilityDef";
        public bool Reckless = true;
        internal string RecklesDef = "Reckless_AbilityDef";
        public bool SelfDefenseSpecialist = true;
        internal string SelfDefenseSpecialistDef = "SelfDefenseSpecialist_AbilityDef";
        public bool Healer = true;
        internal string HealerDef = "Helpful_AbilityDef";
        public bool Farsighted = true;
        internal string FarsightedDef = "Brainiac_AbilityDef";
        public bool Cautious = true;
        internal string CautiousDef = "Cautious_AbilityDef";
        public bool Thief = true;
        internal string ThiefDef = "Thief_AbilityDef";
        public bool Bombardier = true;
        internal string BombardierDef = "Crafty_AbilityDef";
        public bool CloseQuartersSpecialist = true;
        internal string CloseQuartersSpecialistDef = "CloseQuartersSpecialist_AbilityDef";
        public bool Quarterback = true;
        internal string QuarterbackDef = "Pitcher_AbilityDef";
        public bool Strongman = true;
        internal string StrongmanDef = "Strongman_AbilityDef";
        public bool Biochemist = true;
        internal string BiochemistDef = "BioChemist_AbilityDef";
    }

    class Classes
    {
        internal string ClassDef;
        internal int ClassCount;
    }
}
