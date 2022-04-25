using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosiaPrime.Utilities.ExtensionMethods
{
    public static class CheckIfEmptyExtensionMethods
    {
        public static bool ArePersonInputFieldsEmpty(System.Windows.Forms.TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password)
        {
            return (id.Text == "" || firstName.Text == "" || lastName.Text == "" || email.Text == "" || password.Text == "");
        }

        public static bool ArePersonInputFieldsEmptyExeptId(TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password)
        {
            return (id.Text != "" && (firstName.Text == "" || lastName.Text == "" || email.Text == "" || password.Text == ""));
        }

        public static bool AreAdressInputFieldsEmpty(TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox houseNumber)
        {
            return (country.Text == "" || state.Text == "" || postCode.Text == "" || city.Text == "" || street.Text == "" || houseNumber.Text == "");
        }

        public static bool ArePaymentSubscriptionInputFieldsEmpty(DateTimePicker startDate, DateTimePicker endDate)
        {
            return IsStartDateAfterEndDate(startDate, endDate);
        }
    }
}
