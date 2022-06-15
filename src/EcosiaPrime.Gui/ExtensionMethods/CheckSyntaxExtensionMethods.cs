using EcosiaPrime.Contracts.Constants;
using System.Text.RegularExpressions;

namespace EcosiaPrime.Gui.ExtensionMethods
{
    public static class CheckSyntaxExtensionMethods
    {
        /// <summary>
        /// Gibt Datetime zurück, welches vom Parameter von String to Datetime geparsed wurde, wenn es nicht geparsed werde kann wird 31.12.9999 zurückgegeben
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public static DateTime ParseString(this string dateString)
        {
            if (DateTime.TryParse(dateString, out DateTime parsedDate))
            {
                return parsedDate;
            }
            else
            {
                return DateTime.Now.Date;//DateTime.Parse("31.12.9999");
            }
        }

        /// <summary>
        /// Gibt ResponseListe zurück, schaut ob der Parameter einer Email entspricht
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private static List<string> CheckEmail(this string email)
        {
            var responseLines = new List<string>();
            try
            {
                var emailRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
                if (Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase))
                {
                    return responseLines;
                }
                responseLines.Add(ResponseMessagesConstants.EmailIsNotValid);
                return responseLines;
            }
            catch (Exception ex)
            {
                responseLines.Add(ResponseMessagesConstants.EmailIsNotValid);
                return responseLines;
            }
        }

        /// <summary>
        /// Gibt RepsonseListe zurück, schaut, ob Passwort den Kriterien entspricht
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private static List<string> CheckPassword(this string password)
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

        /// <summary>
        /// Gibt RepsonseListe zurück, schaut, ob PLZ und Hausnummer in eine Zahl umgewandelt werden können und ob PLZ eine 5 stellige Zahl über 10000 ist und Hausnummer über 0 ist
        /// </summary>
        /// <param name="postCode"></param>
        /// <param name="houseNumber"></param>
        /// <returns></returns>
        private static List<string> CheckNumberInputsForNumbers(this string postCode, string houseNumber)
        {
            var responseLines = new List<string>();

            if (!Int32.TryParse(houseNumber, out int convertedHouseNumber) || convertedHouseNumber <= 0)
            {
                responseLines.Add(ResponseMessagesConstants.HouseNumberMustBeAnIntegerAndGreaterThanZero);
            }
            if (!Int32.TryParse(postCode, out int convertedPostCode) || convertedPostCode <= 9999)
            {
                responseLines.Add(ResponseMessagesConstants.PostCodeMustBeAnIntegerGreaterThanOrEqualsTenThousand);
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

        /// <summary>
        /// Gibt ResponseList zurück, schaut, ob alle Nicht-Zahlenfelder auch keine Zahlen enthalten
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="country"></param>
        /// <param name="state"></param>
        /// <param name="city"></param>
        /// <param name="street"></param>
        /// <returns></returns>
        private static List<string> CheckNonNumberInputsForNumbers(
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

        /// <summary>
        /// Gibt ResponseList zurück, schaut ob Felder leer sind, Email, Passwort und PLZ Kriterien entsprechen + ob alle Nicht-Zahlenfelder keine Zahlen enthalten
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="country"></param>
        /// <param name="state"></param>
        /// <param name="postCode"></param>
        /// <param name="city"></param>
        /// <param name="street"></param>
        /// <param name="houseNumber"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="paymentMethod"></param>
        /// <param name="subscriptionType"></param>
        /// <returns></returns>
        public static IEnumerable<string> CheckInputFieldsEmpty(
            this string id,
            string firstName, string lastName, string email, string password,
            string country, string state, string postCode, string city, string street, string houseNumber,
            string startDate, string endDate, string paymentMethod, string subscriptionType)
        {
            var responseLines = new List<string>();
            if (CheckIfEmptyExtensionMethods.ArePersonInputFieldsEmptyOrSpace(id, firstName, lastName, email, password))
            {
                responseLines.Add(ResponseMessagesConstants.PersonDataInputFieldsAreEmptyOrSpace);
            }

            if (CheckIfEmptyExtensionMethods.AreAdressInputFieldsEmptyOrSpace(country, state, postCode, city, street, houseNumber))
            {
                responseLines.Add(ResponseMessagesConstants.AddressDataInputFieldsAreEmptyOrSpace);
            }

            if (CheckIfEmptyExtensionMethods.ArePaymentSubscriptionInputFieldsEmpty(startDate, endDate))
            {
                responseLines.Add(ResponseMessagesConstants.PaymentSubscriptionInputFieldsAreEmpty);
            }

            var emailLines = CheckEmail(email);
            if (emailLines.Any())
            {
                responseLines.AddRange(emailLines);
            }

            var passwordLines = CheckPassword(password);
            if (passwordLines.Any())
            {
                responseLines.AddRange(passwordLines);
            }

            var nonNumberLines = CheckNonNumberInputsForNumbers(firstName, lastName, country, state, city, street);
            if (nonNumberLines.Any())
            {
                responseLines.AddRange(nonNumberLines);
            }

            var postcodehouseLines = CheckNumberInputsForNumbers(postCode, houseNumber);
            if (postcodehouseLines.Any())
            {
                responseLines.AddRange(postcodehouseLines);
            }

            return responseLines;
        }

        /// <summary>
        /// Gibt ResponseList zurück, schaut ob Felder leer sind, Email, Passwort und PLZ Kriterien entsprechen + ob alle Nicht-Zahlenfelder keine Zahlen enthalten - mit der Ausnahme von ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="country"></param>
        /// <param name="state"></param>
        /// <param name="postCode"></param>
        /// <param name="city"></param>
        /// <param name="street"></param>
        /// <param name="houseNumber"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="paymentMethod"></param>
        /// <param name="subscriptionType"></param>
        /// <returns></returns>
        public static IEnumerable<string> CheckInputFieldsEmptyExceptID(
            this string id,
            string firstName, string lastName, string email, string password,
            string country, string state, string postCode, string city, string street, string houseNumber,
            string startDate, string endDate, string paymentMethod, string subscriptionType)
        {
            var responseLines = new List<string>();
            if (!CheckIfEmptyExtensionMethods.ArePersonInputFieldsEmptyOrSpaceExceptId(id, firstName, lastName, email, password))
            {
                responseLines.Add(ResponseMessagesConstants.PersonDataInputFieldsAreEmptyOrSpaceExceptID);
            }

            if (CheckIfEmptyExtensionMethods.AreAdressInputFieldsEmptyOrSpace(country, state, postCode, city, street, houseNumber))
            {
                responseLines.Add(ResponseMessagesConstants.AddressDataInputFieldsAreEmptyOrSpace);
            }

            if (CheckIfEmptyExtensionMethods.ArePaymentSubscriptionInputFieldsEmpty(startDate, endDate))
            {
                responseLines.Add(ResponseMessagesConstants.PaymentSubscriptionInputFieldsAreEmpty);
            }

            var emailLines = CheckEmail(email);
            if (emailLines.Any())
            {
                responseLines.AddRange(emailLines);
            }

            var passwordLines = CheckPassword(password);
            if (passwordLines.Any())
            {
                responseLines.AddRange(passwordLines);
            }

            var nonNumberLines = CheckNonNumberInputsForNumbers(firstName, lastName, country, state, city, street);
            if (nonNumberLines.Any())
            {
                responseLines.AddRange(nonNumberLines);
            }

            var numberLines = CheckNumberInputsForNumbers(postCode, houseNumber);
            if (numberLines.Any())
            {
                responseLines.AddRange(numberLines);
            }

            return responseLines;
        }
    }
}