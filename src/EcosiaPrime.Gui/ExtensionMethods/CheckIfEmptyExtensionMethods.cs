namespace EcosiaPrime.Gui.ExtensionMethods
{
    public static class CheckIfEmptyExtensionMethods
    {
        public static bool ArePersonInputFieldsEmpty(this TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password)
        {
            return (id.Text == "" || firstName.Text == "" || lastName.Text == "" || email.Text == "" || password.Text == "");
        }

        public static bool ArePersonInputFieldsEmptyExeptId(this TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password)
        {
            return (id.Text != "" && (firstName.Text == "" || lastName.Text == "" || email.Text == "" || password.Text == ""));
        }

        public static bool AreAdressInputFieldsEmpty(this TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox houseNumber)
        {
            return (country.Text == "" || state.Text == "" || postCode.Text == "" || city.Text == "" || street.Text == "" || houseNumber.Text == "");
        }

        public static bool ArePaymentSubscriptionInputFieldsEmpty(this DateTimePicker startDate, DateTimePicker endDate)
        {
            return IsStartDateAfterEndDate(startDate, endDate);
        }

        public static bool IsStartDateAfterEndDate(this DateTimePicker startDate, DateTimePicker endDate)
        {
            return GetDateTime(startDate) > GetDateTime(endDate);
        }

        public static DateTime GetDateTime(this DateTimePicker dateTimePicker)
        {
            DateTime s = default;
            dateTimePicker.Invoke(new Action(() =>
            {
                s = dateTimePicker.Value.Date;
            }));

            return s;
        }
    }
}