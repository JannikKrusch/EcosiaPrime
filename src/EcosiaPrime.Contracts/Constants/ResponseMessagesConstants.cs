namespace EcosiaPrime.Contracts.Constants
{
    public static class ResponseMessagesConstants
    {
        public const string PersonDataInputFieldsAreEmpty = "Eingabefelder für Personendaten (links) sind leer!";
        public const string PersonDataInputFieldsAreEmptyExceptID = "Alle Eingabefelder für Personendaten (links) bis auf ID müssen leer sein!";
        public const string AddressDataInputFieldsAreEmpty = "Eingabefelder für Adressdaten (mitte) sind leer!";
        public const string PaymentSubscriptionInputFieldsAreEmpty = "Eingabefelder für Bezahlung und Abonnement(rechts) sind leer oder Start- ist nach Enddatum!";
        public const string IDAlreadyExistsInDB = "Die eingegebene ID existiert bereits in der Datenbank!";
        public const string IDDoesntExistInDB = "Die eingegebene ID existiert nicht in der Datenbank";
        public const string AddClientToDBSuccessful = "Neuer Kunde der Datenbank erfolgreich eingefügt";
        public const string AddClientToDBFailure = "Einfügung in Datenbak ist fehlgeschlagen";
        public const string UpdateClientToDBSuccessful = "Aktualisierung der Kundendaten war erfolgreich!";
        public const string UpdateClientToDBFailure = "Aktualisierung der Kundendaten ist fehlgeschlagen!";
        public const string DeleteClientToDBSuccessful = "Löschung der Kundendaten war erfolgreich!";
        public const string DeleteClientToDBFailure = "Löschung der Kundendaten ist fehlgeschlagen!";
        public const string IDIsEmpty = "Eingabefeld für id ist leer";

        public const string EmailIsNotValid = "Keine gültige Email!";

        public const string PasswordNoNumber = "Passwort muss mindestes eine Zahl haben!";
        public const string PasswordNoUpperCase = "Passwort muss mindestes ein großen Buchstaben haben!";
        public const string PasswordNoLowerCase = "Passwort muss mindestes ein kleinen Buchstaben haben!";
        public const string PasswordNoMinMaxChars = "Passwort muss mindestens 8 und maximal 20 Buchstaben haben!";
        public const string PasswordNoSymbols = "Passwort muss mindestens ein Sonderzeichen haben!";

    }
}
