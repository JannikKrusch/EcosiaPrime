namespace EcosiaPrime.Contracts.Constants
{
    public static class ResponseMessagesConstants
    {
        public const string PersonDataInputFieldsAreEmptyOrSpace = "Eingabefelder für Personendaten (links) sind leer oder haben Leerzeichen!";
        public const string PersonDataInputFieldsAreEmptyOrSpaceExceptID = "Alle Eingabefelder für Personendaten (links) bis auf ID müssen leer sein!";
        public const string AddressDataInputFieldsAreEmptyOrSpace = "Eingabefelder für Adressdaten (mitte) sind leer oder haben Leerzeichen!";
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
        public const string EmailIsNotUnique = "Email ist nicht einzigartig!";

        public const string PasswordNoNumber = "Passwort muss mindestes eine Zahl haben!";
        public const string PasswordNoUpperCase = "Passwort muss mindestes ein großen Buchstaben haben!";
        public const string PasswordNoLowerCase = "Passwort muss mindestes ein kleinen Buchstaben haben!";
        public const string PasswordNoMinMaxChars = "Passwort muss mindestens 8 und maximal 20 Buchstaben haben!";
        public const string PasswordNoSymbols = "Passwort muss mindestens ein Sonderzeichen haben!";

        public const string HouseNumberMustBeAnIntegerAndGreaterThanZero = "Hausnummer muss eine Zahl und größer als 0 sein";
        public const string PostCodeMustBeAnIntegerGreaterThanZero = "Postleitzahl muss eine Zahl und größer als 0 sein";
        public const string PostCodeMustHaveCertainLength = "Postleitzahl muss 5 Stellen haben";

        public const string FirstnameCantContainNumber = "Vorname kann keine Zahl behinhalten";
        public const string LastnameCantContainNumber = "Nachname kann keine Zahl behinhalten";
        public const string CountyCantContainNumber = "Land kann keine Zahl behinhalten";
        public const string StateCantContainNumber = "Bundesland kann keine Zahl behinhalten";
        public const string CityCantContainNumber = "Stadt kann keine Zahl behinhalten";
        public const string StreetCantContainNumber = "Straße kann keine Zahl behinhalten";

        public const string AdvancedSearchIncorrectSyntax = "Syntax ist falsch. Bitte Eingabe überprüfen!";


    }
}
