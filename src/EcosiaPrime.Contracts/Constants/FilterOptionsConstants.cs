using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosiaPrime.Contracts.Constants
{
    public static class FilterOptionsConstants
    {
        public static readonly List<string> FilterOptions = new List<string>()
        {
            AllByID,
            AllByFirstname,
            AllByLastName,
            AllByEmail,
            AllByCountry,
            AllBySubscription,
            OneById,
        };

        public const string AllByID = "Alle(Sortiert nach ID)";
        public const string AllByFirstname = "Alle (Sortiert nach Vorname)";
        public const string AllByLastName = "Alle (sortiert nach Nachname)";
        public const string AllByEmail = "Alle (sortiert nach Email)";
        public const string AllByCountry = "Alle (sortiert nach Land)";
        public const string AllBySubscription = "Alle (sortiert nach Abonnement)";
        public const string OneById = "Eine Person (durch ID)";
    }
}
