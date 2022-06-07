namespace EcosiaPrime.Contracts.Constants
{
    public static class ComboBoxOptionConstants
    {
        public const string Create = "Erstellen";
        public const string Update = "Bearbeiten";
        public const string Delete = "Löschen";
        public const string Show = "Anzeigen";
        public const string Search = "Suchen";
        public const string AdvancedSearch = "Fortg. Suchen";

        public static readonly List<string> OptionConstants = new List<string>
        {
            Create,
            Update,
            Delete,
            Show,
            Search,
            AdvancedSearch
        };
    }
}