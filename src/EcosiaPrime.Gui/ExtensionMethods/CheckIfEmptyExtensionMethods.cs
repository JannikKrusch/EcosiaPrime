namespace EcosiaPrime.Gui.ExtensionMethods
{
    public static class CheckIfEmptyExtensionMethods
    {
        /// <summary>
        /// Schaut, ob einer der Felder leer ist und gibt dementsprechenden Warheitswert zurück
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool ArePersonInputFieldsEmptyOrSpace(this string id, string firstName, string lastName, string email, string password)
        {
            return (id == "" || id.Any(Char.IsWhiteSpace) || firstName == "" || firstName.Any(Char.IsWhiteSpace) || lastName == "" || lastName.Any(Char.IsWhiteSpace) || email == "" || email.Any(Char.IsWhiteSpace) || password == "" || password.Any(Char.IsWhiteSpace));
        }

        /// <summary>
        /// Schaut, ob einer der Felder leer ist und gibt dementsprechenden Warheitswert zurück
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool ArePersonInputFieldsEmptyOrSpaceExceptId(this string id, string firstName, string lastName, string email, string password)
        {
            return (id != "" && (firstName == "" || firstName.Any(Char.IsWhiteSpace) || lastName == "" || lastName.Any(Char.IsWhiteSpace) || email == "" || email == "" || email.Any(Char.IsWhiteSpace) || password == "" || password.Any(Char.IsWhiteSpace)));
        }

        /// <summary>
        /// Schaut, ob einer der Felder leer ist und gibt dementsprechenden Warheitswert zurück
        /// </summary>
        /// <param name="country"></param>
        /// <param name="state"></param>
        /// <param name="postCode"></param>
        /// <param name="city"></param>
        /// <param name="street"></param>
        /// <param name="houseNumber"></param>
        /// <returns></returns>
        public static bool AreAdressInputFieldsEmptyOrSpace(this string country, string state, string postCode, string city, string street, string houseNumber)
        {
            return (country == "" || country.Any(Char.IsWhiteSpace) || state == "" || state.Any(Char.IsWhiteSpace) || postCode == "" || postCode.Any(Char.IsWhiteSpace) || city == "" || city.Any(Char.IsWhiteSpace) || street == "" || state.Any(Char.IsWhiteSpace) || houseNumber == "" || houseNumber.Any(Char.IsWhiteSpace));
        }

        /// <summary>
        /// Schaut, ob einer der Felder leer ist (mit Ausnahme von der ID) und gibt dementsprechenden Warheitswert zurück
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static bool ArePaymentSubscriptionInputFieldsEmpty(this string startDate, string endDate)
        {
            return IsStartDateAfterEndDate(startDate, endDate);
        }

        /// <summary>
        /// Schaut, ob das Startdatum nach dem Enddatum ist (z.B. Start: 28.04.2022 End: 12.03.2022 -> true) und gibt dementsprechenden Warheitswert zurück
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private static bool IsStartDateAfterEndDate(this string startDate, string endDate)
        {
            return startDate.GetDateTime() > endDate.GetDateTime();
        }

        ///// <summary>
        ///// Gibt Datetime von DatetimePicker zurück
        ///// </summary>
        ///// <param name="dateTimePicker"></param>
        ///// <returns></returns>
        private static DateTime GetDateTime(this string dateTimePicker)
        {
            var dateTime = DateTime.Parse(dateTimePicker);
            return dateTime;
        }
    }
}