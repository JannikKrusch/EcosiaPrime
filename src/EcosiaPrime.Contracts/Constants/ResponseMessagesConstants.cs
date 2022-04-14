namespace EcosiaPrime.Contracts.Constants
{
    public static class ResponseMessagesConstants
    {
        public static readonly string PersonDataInputFieldsAreEmpty = "Eingabefelder für Personendaten (links) sind leer!";
        public static readonly string PersonDataInputFieldsAreEmptyExceptID = "Alle Eingabefelder für Personendaten (links) bis auf ID müssen leer sein!";
        public static readonly string AddressDataInputFieldsAreEmpty = "Eingabefelder für Adressdaten (mitte) sind leer!";
        public static readonly string PaymentSubscriptionInputFieldsAreEmpty = "Eingabefelder für Bezahlung und Abonnement(rechts) sind leer!";
        public static readonly string IDAlreadyExistsInDB = "Die eingegebene ID existiert bereits in der Datenbank!";
        public static readonly string IDDoesntExistInDB = "Die eingegebene ID existiert nicht in der Datenbank";
        public static readonly string AddClientToDBSuccessful = "Neuer Kunde der Datenbank erfolgreich eingefügt";
        public static readonly string AddClientToDBFailure = "Einfügung in Datenbak ist fehlgeschlagen";
        public static readonly string UpdateClientToDBSuccessful = "Aktualisierung der Kundendaten war erfolgreich!";
        public static readonly string UpdateClientToDBFailure = "Aktualisierung der Kundendaten ist fehlgeschlagen!";
        public static readonly string DeleteClientToDBSuccessful = "Löschung der Kundendaten war erfolgreich!";
        public static readonly string DeleteClientToDBFailure = "Löschung der Kundendaten ist fehlgeschlagen!";
        public static readonly string IDIsEmpty = "Eingabefeld für id ist leer";
    }
}
