using EcosiaPrime.Contracts.Constants;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace EcosiaPrime.Gui.ExtensionMethods
{
    public static class CheckSyntaxExtensionMethods
    {
        public static string CutDateString(this string dateString)
        {
            var x = dateString.Split(", ");
            if (x.Length == 2)
            {
                return x[1];
            }
            return "";
        }

        public static DateTime ParseCutString(this string dateString)
        {
            var cutDateString = CutDateString(dateString);

            var couldParse = DateTime.TryParse(cutDateString, out DateTime parsedDate);

            if (couldParse)
            {
                return parsedDate;
            }
            else
            {
                return DateTime.Parse("31.12.9999");
            }
        }

        public static List<string> CheckEmail(this string email)
        {
            var responseLines = new List<string>();
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return responseLines;
            }
            catch (Exception ex)
            {
                responseLines.Add(ResponseMessagesConstants.EmailIsNotValid);
                return responseLines;
            }
        }

        public static List<string> CheckPassword(this string password)
        {
            var responseLines = new List<string>();

            //https://stackoverflow.com/questions/34715501/validating-password-using-regex-c-sharp
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasMiniMaxChars = new Regex(@"^.{8,20}$");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasNumber.IsMatch(password))
            {
                responseLines.Add(ResponseMessagesConstants.PasswordNoNumber);
            }
            if (!hasUpperChar.IsMatch(password))
            {
                responseLines.Add(ResponseMessagesConstants.PasswordNoUpperCase);
            }
            if (!hasLowerChar.IsMatch(password))
            {
                responseLines.Add(ResponseMessagesConstants.PasswordNoLowerCase);
            }
            if (!hasMiniMaxChars.IsMatch(password))
            {
                responseLines.Add(ResponseMessagesConstants.PasswordNoMinMaxChars);
            }
            if (!hasSymbols.IsMatch(password))
            {
                responseLines.Add(ResponseMessagesConstants.PasswordNoSymbols);
            }

            return responseLines;
        }

        public static List<string> CheckNumberInputsForNumbers(this string postCode, string houseNumber)
        {
            var responseLines = new List<string>();

            var couldParse = Int32.TryParse(houseNumber, out int convertedHouseNumber);
            if (!couldParse)
            {
                responseLines.Add(ResponseMessagesConstants.HouseNumberMustBeAnInteger);
            }
            couldParse = Int32.TryParse(postCode, out int convertedPostCode);
            if (!couldParse)
            {
                responseLines.Add(ResponseMessagesConstants.PostCodeMustBeAnInteger);
            }
            else
            {
                if (postCode.Length != 5)
                {
                    responseLines.Add(ResponseMessagesConstants.PostCodeMustHaveCertainLength);
                }
            }

            return responseLines;
        }

        public static List<string> CheckNonNumberInputsForNumbers(
            this string firstName, string lastName,
            string country, string state, string city, string street)
        {
            var responseLines = new List<string>();
            var hasNumber = new Regex(@"[0-9]+");

            if (hasNumber.IsMatch(firstName))
            {
                responseLines.Add(ResponseMessagesConstants.FirstnameCantContainNumber);
            }

            if (hasNumber.IsMatch(lastName))
            {
                responseLines.Add(ResponseMessagesConstants.LastnameCantContainNumber);
            }

            if (hasNumber.IsMatch(country))
            {
                responseLines.Add(ResponseMessagesConstants.CountyCantContainNumber);
            }

            if (hasNumber.IsMatch(state))
            {
                responseLines.Add(ResponseMessagesConstants.StateCantContainNumber);
            }

            if (hasNumber.IsMatch(city))
            {
                responseLines.Add(ResponseMessagesConstants.CityCantContainNumber);
            }

            if (hasNumber.IsMatch(street))
            {
                responseLines.Add(ResponseMessagesConstants.StreetCantContainNumber);
            }

            return responseLines;
        }

        public static IEnumerable<string> CheckInputFieldsEmpty(
            this TextBox response,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox houseNumber,
            DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            var responseLines = new List<string>();
            if (CheckIfEmptyExtensionMethods.ArePersonInputFieldsEmpty(id, firstName, lastName, email, password))
            {
                responseLines.Add(ResponseMessagesConstants.PersonDataInputFieldsAreEmpty);
            }

            if (CheckIfEmptyExtensionMethods.AreAdressInputFieldsEmpty(country, state, postCode, city, street, houseNumber))
            {
                responseLines.Add(ResponseMessagesConstants.AddressDataInputFieldsAreEmpty);
            }

            if (CheckIfEmptyExtensionMethods.ArePaymentSubscriptionInputFieldsEmpty(startDate, endDate))
            {
                responseLines.Add(ResponseMessagesConstants.PaymentSubscriptionInputFieldsAreEmpty);
            }

            var emailLines = CheckEmail(email.Text);
            if (emailLines.Any())
            {
                responseLines.AddRange(emailLines);
            }

            var passwordLines = CheckPassword(password.Text);
            if (passwordLines.Any())
            {
                responseLines.AddRange(passwordLines);
            }

            var nonNumberLines = CheckNonNumberInputsForNumbers(firstName.Text, lastName.Text, country.Text, state.Text, city.Text, street.Text);
            if (nonNumberLines.Any())
            {
                responseLines.AddRange(nonNumberLines);
            }

            var postcodehouseLines = CheckNumberInputsForNumbers(postCode.Text, houseNumber.Text);
            if (postcodehouseLines.Any())
            {
                responseLines.AddRange(postcodehouseLines);
            }

            return responseLines;
        }

        public static IEnumerable<string> CheckInputFieldsEmptyExeptID(
            this TextBox response,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox houseNumber,
            DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            var responseLines = new List<string>();
            if (!CheckIfEmptyExtensionMethods.ArePersonInputFieldsEmptyExeptId(id, firstName, lastName, email, password))
            {
                responseLines.Add(ResponseMessagesConstants.PersonDataInputFieldsAreEmptyExceptID);
            }

            if (CheckIfEmptyExtensionMethods.AreAdressInputFieldsEmpty(country, state, postCode, city, street, houseNumber))
            {
                responseLines.Add(ResponseMessagesConstants.AddressDataInputFieldsAreEmpty);
            }

            if (CheckIfEmptyExtensionMethods.ArePaymentSubscriptionInputFieldsEmpty(startDate, endDate))
            {
                responseLines.Add(ResponseMessagesConstants.PaymentSubscriptionInputFieldsAreEmpty);
            }

            var emailLines = CheckEmail(email.Text);
            if (emailLines.Any())
            {
                responseLines.AddRange(emailLines);
            }

            var passwordLines = CheckPassword(password.Text);
            if (passwordLines.Any())
            {
                responseLines.AddRange(passwordLines);
            }

            var nonNumberLines = CheckNonNumberInputsForNumbers(firstName.Text, lastName.Text, country.Text, state.Text, city.Text, street.Text);
            if (nonNumberLines.Any())
            {
                responseLines.AddRange(nonNumberLines);
            }

            var numberLines = CheckNumberInputsForNumbers(postCode.Text, houseNumber.Text);
            if (numberLines.Any())
            {
                responseLines.AddRange(numberLines);
            }

            return responseLines;
        }
    }
}