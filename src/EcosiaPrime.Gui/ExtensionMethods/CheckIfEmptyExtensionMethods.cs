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
        public static bool ArePersonInputFieldsEmpty(this string id, string firstName, string lastName, string email, string password)
        {
            return (id == "" || firstName == "" || lastName == "" || email == "" || password == "");
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
        public static bool ArePersonInputFieldsEmptyExceptId(this string id, string firstName, string lastName, string email, string password)
        {
            return (id != "" && (firstName == "" || lastName == "" || email == "" || password == ""));
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
        public static bool AreAdressInputFieldsEmpty(this string country, string state, string postCode, string city, string street, string houseNumber)
        {
            return (country == "" || state == "" || postCode == "" || city == "" || street == "" || houseNumber == "");
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
            //DateTime dateTime = default;
            var dateTime = DateTime.Parse(dateTimePicker);
            //dateTimePicker.Invoke(new Action(() =>
            //{
            //    s = dateTimePicker.Value.Date;
            //}));

            return dateTime;
        }
    }
}