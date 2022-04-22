using EcosiaPrime.Contracts.Constants;
using EcosiaPrime.Contracts.Models;
using EcosiaPrime.MongoDB;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace EcosiaPrime.Gui
{
    public class GuiService : IGuiService
    {
        private readonly IMongoDBService _mongoDBService;

        public GuiService(IMongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        public bool ArePersonInputFieldsEmpty(TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password)
        {
            return (id.Text == "" || firstName.Text == "" || lastName.Text == "" || email.Text == "" || password.Text == "");
        }

        public bool ArePersonInputFieldsEmptyExeptId(TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password)
        {
            return (id.Text != "" && (firstName.Text == "" || lastName.Text == "" || email.Text == "" || password.Text == ""));
        }

        public bool AreAdressInputFieldsEmpty(TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber)
        {
            return (country.Text == "" || state.Text == "" || postCode.Text == "" || city.Text == "" || street.Text == "" || streetNumber.Text == "");
        }

        public bool ArePaymentSubscriptionInputFieldsEmpty(DateTimePicker startDate, DateTimePicker endDate)
        {
            return IsStartDateAfterEndDate(startDate, endDate);
        }

        public bool IsStartDateAfterEndDate(DateTimePicker startDate, DateTimePicker endDate)
        {
            return GetDateTime(startDate) > GetDateTime(endDate);
        }

        public DateTime GetDateTime(DateTimePicker dateTimePicker)
        {
            DateTime s = default;
            dateTimePicker.Invoke(new Action(() =>
            {
                s = dateTimePicker.Value.Date;
            }));

            return s;
        }

        public string CutDateString(string dateString)
        {
            var x = dateString.Split(", ");
            if (x.Length == 2)
            {
                return x[1];
            }
            return "";
        }

        public DateTime ParseCutString(string dateString)
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

        public async Task<bool> DoesIdExist(string collectionName, string id)
        {
            var exists = await _mongoDBService.LoadRecordByIdAsync<Client>(collectionName, id).ConfigureAwait(false);
            return exists != null;
        }

        public List<string> CheckEmail(string email)
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

        public List<string> CheckPassword(string password)
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

        public IEnumerable<string> CheckInputFieldsEmpty(
            TextBox response,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber,
            DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            var responseLines = new List<string>();
            if (ArePersonInputFieldsEmpty(id, firstName, lastName, email, password))
            {
                responseLines.Add(ResponseMessagesConstants.PersonDataInputFieldsAreEmpty);
            }

            if (AreAdressInputFieldsEmpty(country, state, postCode, city, street, streetNumber))
            {
                responseLines.Add(ResponseMessagesConstants.AddressDataInputFieldsAreEmpty);
            }

            if (ArePaymentSubscriptionInputFieldsEmpty(startDate, endDate))
            {
                responseLines.Add(ResponseMessagesConstants.PaymentSubscriptionInputFieldsAreEmpty);
            }

            if (email.Text != "")
            {
                var emailLines = CheckEmail(email.Text);
                if (emailLines.Any())
                {
                    responseLines.AddRange(emailLines);
                }
            }

            if (password.Text != "")
            {
                var passwordLines = CheckPassword(password.Text);
                if (passwordLines.Any())
                {
                    responseLines.AddRange(passwordLines);
                }
            }

            return responseLines;
        }

        public IEnumerable<string> CheckInputFieldsEmptyExeptID(
            TextBox response,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber,
            DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            var responseLines = new List<string>();
            if (!ArePersonInputFieldsEmptyExeptId(id, firstName, lastName, email, password))
            {
                responseLines.Add(ResponseMessagesConstants.PersonDataInputFieldsAreEmptyExceptID);
            }

            if (AreAdressInputFieldsEmpty(country, state, postCode, city, street, streetNumber))
            {
                responseLines.Add(ResponseMessagesConstants.AddressDataInputFieldsAreEmpty);
            }

            if (ArePaymentSubscriptionInputFieldsEmpty(startDate, endDate))
            {
                responseLines.Add(ResponseMessagesConstants.PaymentSubscriptionInputFieldsAreEmpty);
            }

            if (email.Text != "")
            {
                var emailLines = CheckEmail(email.Text);
                if (emailLines.Any())
                {
                    responseLines.AddRange(emailLines);
                }
            }

            if (password.Text != "")
            {
                var passwordLines = CheckPassword(password.Text);
                if (passwordLines.Any())
                {
                    responseLines.AddRange(passwordLines);
                }
            }

            return responseLines;
        }

        public string GetPaymentMethod(string paymentString)
        {
            var paymentmethods = PaymentMethodConstants.PaymentMethods;
            foreach (var paymentMethod in paymentmethods)
            {
                if (paymentMethod.ToLower() == paymentString.ToLower())
                {
                    return paymentMethod;
                }
            }
            return "";
        }

        public string GetSubscriptionType(string subscriptionTypeString)
        {
            var subscriptionTypes = SubscriptionTypeConstants.SubscriptionType;
            foreach (var subscriptionType in subscriptionTypes)
            {
                if (subscriptionType.ToLower() == subscriptionTypeString.ToLower())
                {
                    return subscriptionType;
                }
            }
            return "";
        }

        public string InvokeComboBox(ComboBox comboBox)
        {
            var text = "";
            comboBox.Invoke(new Action(() =>
            {
                text = comboBox.Text;
            }));
            return text;
        }

        public void InvokeComboBox(ComboBox comboBox, string input)
        {
            comboBox.Invoke(new Action(() =>
            {
                comboBox.Text = input;
            }));
        }

        public void InvokeTextBox(TextBox textBox, string input)
        {
            textBox.Invoke(new Action(() =>
            {
                textBox.Text = input;
            }));
        }

        public void InvokeResponseTextBox(TextBox response, IEnumerable<string> lines)
        {
            response.Invoke(new Action(() =>
            {
                var x = lines.ToArray();
                response.Lines = x;
            }));
        }

        public void InvokeDateTimePicker(DateTimePicker dateTimePicker, string input)
        {
            dateTimePicker.Invoke(new Action(() =>
            {
                dateTimePicker.Text = input;
            }));
        }

        public void InvokeListView(ListView listView, string[] input)
        {
            var listViewItem = new ListViewItem(input);
            listView.Invoke(new Action(() =>
            {
                listView.Items.Add(listViewItem);
            }));
        }

        public string[] GetFilledRow(Client client)
        {
            if (client != null && client.Id != null)
            {
                string[] row = {
                client.Id, client.FirstName, client.LastName, client.Email, client.Password,
                client.Address.Country, client.Address.State, client.Address.PostCode, client.Address.City, client.Address.Street, client.Address.HouseNumber,
                client.Subscription.StartDate, client.Subscription.EndDate, client.Subscription.PaymentMethod, client.Subscription.SubscriptionType
                };
                return row;
            }
            return new string[] { };
        }

        public void FillListView(ListView listView, IEnumerable<Client> clients)
        {
            clients.ToList().ForEach(client => InvokeListView(listView, GetFilledRow(client)));
        }

        public void FillListView(ListView listView, Client client)
        {
            InvokeListView(listView, GetFilledRow(client));
        }

        public async Task<bool> CreateClientAsync(
            TextBox response,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox houseNumber,
            DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            var responseLines = CheckInputFieldsEmpty(
                response,
                id, firstName, lastName, email,
                password, country, state, postCode, city, street,
                houseNumber, startDate, endDate, paymentMethod, subscriptionType);

            if (responseLines.Any())
            {
                InvokeResponseTextBox(response, responseLines);
                return false;
            }

            if (await DoesIdExist(_mongoDBService.GetMongoDBConfiguration().CollectionName, id.Text).ConfigureAwait(false))
            {
                InvokeResponseTextBox(response, new List<string> { ResponseMessagesConstants.IDAlreadyExistsInDB });
                return false;
            }

            var client = new Client();
            client.Id = id.Text;
            client.FirstName = firstName.Text;
            client.LastName = lastName.Text;
            client.Email = email.Text;
            client.Password = password.Text;

            client.Address = new Address();
            client.Address.Country = country.Text;
            client.Address.State = state.Text;
            client.Address.PostCode = postCode.Text;
            client.Address.City = city.Text;
            client.Address.Street = street.Text;
            client.Address.HouseNumber = houseNumber.Text;

            client.Subscription = new Subscription();
            client.Subscription.StartDate = startDate.Text;
            client.Subscription.EndDate = endDate.Text;

            client.Subscription.PaymentMethod = InvokeComboBox(paymentMethod);
            client.Subscription.SubscriptionType = InvokeComboBox(subscriptionType);

            var successful = await _mongoDBService.InsertRecordAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName, client).ConfigureAwait(false);
            if (successful)
            {
                InvokeResponseTextBox(response, new List<string> { ResponseMessagesConstants.AddClientToDBSuccessful });
            }
            else
            {
                InvokeResponseTextBox(response, new List<string> { ResponseMessagesConstants.AddClientToDBFailure });
            }
            return successful;
        }

        public async Task<bool> UpdateClientAsync(
            TextBox response,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber,
            DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            if (!await DoesIdExist(_mongoDBService.GetMongoDBConfiguration().CollectionName, id.Text).ConfigureAwait(false))
            {
                InvokeResponseTextBox(response, new List<string> { ResponseMessagesConstants.IDDoesntExistInDB });
                return false;
            }

            if (ArePersonInputFieldsEmptyExeptId(id, firstName, lastName, email, password) && AreAdressInputFieldsEmpty(country, state, postCode, city, streetNumber, street) && !ArePaymentSubscriptionInputFieldsEmpty(startDate, endDate))
            {
                var clientDB = await _mongoDBService.LoadRecordByIdAsync<Client>(_mongoDBService.GetMongoDBConfiguration().CollectionName, id.Text).ConfigureAwait(false);

                InvokeTextBox(id, clientDB.Id);
                InvokeTextBox(firstName, clientDB.FirstName);
                InvokeTextBox(lastName, clientDB.LastName);
                InvokeTextBox(email, clientDB.Email);
                InvokeTextBox(password, clientDB.Password);

                InvokeTextBox(country, clientDB.Address.Country);
                InvokeTextBox(state, clientDB.Address.State);
                InvokeTextBox(postCode, clientDB.Address.PostCode);
                InvokeTextBox(city, clientDB.Address.City);
                InvokeTextBox(street, clientDB.Address.Street);
                InvokeTextBox(streetNumber, clientDB.Address.HouseNumber);

                InvokeDateTimePicker(startDate, clientDB.Subscription.StartDate);
                InvokeDateTimePicker(endDate, clientDB.Subscription.EndDate);
                InvokeComboBox(paymentMethod, clientDB.Subscription.PaymentMethod);
                InvokeComboBox(subscriptionType, clientDB.Subscription.SubscriptionType);

                InvokeResponseTextBox(response, new List<string> { });
                //Hier muss --> false <-- zurückgegeben werden, obwohl alles funktioniert hat, da ansonsten alle Felder geleert werden!
                return false;
            }
            else
            {
                var responseLines = CheckInputFieldsEmpty(
                response,
                id, firstName, lastName, email,
                password, country, state, postCode, city, street,
                streetNumber, startDate, endDate, paymentMethod, subscriptionType);

                if (responseLines.Any())
                {
                    InvokeResponseTextBox(response, responseLines);
                    return false;
                }

                var client = new Client();
                client.Id = id.Text;
                client.FirstName = firstName.Text;
                client.LastName = lastName.Text;
                client.Email = email.Text;
                client.Password = password.Text;

                client.Address = new Address();
                client.Address.Country = country.Text;
                client.Address.State = state.Text;
                client.Address.PostCode = postCode.Text;
                client.Address.City = city.Text;
                client.Address.Street = street.Text;
                client.Address.HouseNumber = streetNumber.Text;

                client.Subscription = new Subscription();
                client.Subscription.StartDate = startDate.Text;
                client.Subscription.EndDate = endDate.Text;

                client.Subscription.PaymentMethod = InvokeComboBox(paymentMethod);
                client.Subscription.SubscriptionType = InvokeComboBox(subscriptionType);

                var successful = await _mongoDBService.UpsertRecordAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName, client.Id, client).ConfigureAwait(false);
                if (successful)
                {
                    InvokeResponseTextBox(response, new List<string> { ResponseMessagesConstants.UpdateClientToDBSuccessful });
                }
                else
                {
                    InvokeResponseTextBox(response, new List<string> { ResponseMessagesConstants.UpdateClientToDBFailure });
                }
                return successful;
            }
        }

        public async Task<bool> DeleteClientAsync(
            TextBox response,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber,
            DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            var responseLines = new List<string>();

            if (!await DoesIdExist(_mongoDBService.GetMongoDBConfiguration().CollectionName, id.Text).ConfigureAwait(false))
            {
                responseLines.Add(ResponseMessagesConstants.IDDoesntExistInDB);
            }

            if (responseLines.Any())
            {
                InvokeResponseTextBox(response, responseLines);
                return false;
            }

            var successful = await _mongoDBService.DeleteRecordAsync<Client>(_mongoDBService.GetMongoDBConfiguration().CollectionName, id.Text).ConfigureAwait(false);
            if (successful)
            {
                InvokeResponseTextBox(response, new List<string> { ResponseMessagesConstants.DeleteClientToDBSuccessful });
            }
            else
            {
                InvokeResponseTextBox(response, new List<string> { ResponseMessagesConstants.DeleteClientToDBFailure });
            }
            return successful;
        }

        public async Task ShowClientsAsync(ComboBox filter, ListView table, string id)
        {
            IEnumerable<Client> clients = new List<Client>();
            var client = new Client();

            switch (filter.Text.ToString())
            {
                case FilterOptionsConstants.AllByID:
                    clients = await _mongoDBService.SortRecordByIdAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName).ConfigureAwait(false);
                    break;

                case FilterOptionsConstants.AllByFirstname:
                    clients = await _mongoDBService.SortRecordByFirstNameAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName).ConfigureAwait(false);
                    break;

                case FilterOptionsConstants.AllByLastName:
                    clients = await _mongoDBService.SortRecordByLastNameAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName).ConfigureAwait(false);
                    break;

                case FilterOptionsConstants.AllByEmail:
                    clients = await _mongoDBService.SortRecordByEmailAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName).ConfigureAwait(false);
                    break;

                case FilterOptionsConstants.AllByCountry:
                    clients = await _mongoDBService.SortRecordByCountyAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName).ConfigureAwait(false);
                    break;

                case FilterOptionsConstants.AllBySubscription:
                    clients = await _mongoDBService.SortRecordBySubscriptionTypeAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName).ConfigureAwait(false);
                    break;

                case FilterOptionsConstants.OneById:
                    client = await _mongoDBService.LoadRecordByIdAsync<Client>(_mongoDBService.GetMongoDBConfiguration().CollectionName, id).ConfigureAwait(false);
                    break;
            }

            table.Invoke(new Action(() =>
            {
                table.Items.Clear();
            }));

            if (clients.Any())
            {
                FillListView(table, clients);
            }
            else if (client != null)
            {
                FillListView(table, client);
            }

            table.Invoke(new Action(() =>
            {
                table.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                foreach (ColumnHeader columnHeader in table.Columns)
                {
                    if (columnHeader.Width < 75)
                    {
                        columnHeader.Width = 100;
                    }
                }
            }));
        }

        public async Task SearchFunction(
            ListView table, ComboBox filter,
            TextBox response,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber,
            DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            var searchForString = "";
            var searchStringPrimary = "";
            var searchStringSecondary = "";
            switch (filter.Text)
            {
                case SearchFunctionConstants.SearchForID:
                    if (id.Text != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForID;
                        searchStringPrimary = id.Text;
                    }
                    break;
                case SearchFunctionConstants.SearchForFirstname:
                    if (firstName.Text != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForFirstname;
                        searchStringPrimary = firstName.Text;
                    }
                    break;
                case SearchFunctionConstants.SearchForLastName:
                    if (lastName.Text != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForLastName;
                        searchStringPrimary = lastName.Text;
                    }
                    break;
                case SearchFunctionConstants.SearchForEmail:
                    if (email.Text != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForEmail;
                        searchStringPrimary = email.Text;
                    }
                    break;
                case SearchFunctionConstants.SearchForCountry:
                    if (country.Text != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForCountry;
                        searchStringPrimary = country.Text;
                    }
                    break;
                case SearchFunctionConstants.SearchForState:
                    if (state.Text != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForState;
                        searchStringPrimary = state.Text;
                    }
                    break;
                case SearchFunctionConstants.SearchForPostCode:
                    if (postCode.Text != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForPostCode;
                        searchStringPrimary = postCode.Text;
                    }
                    break;
                case SearchFunctionConstants.SearchForCity:
                    if (city.Text != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForCity;
                        searchStringPrimary = city.Text;
                    }
                    break;
                case SearchFunctionConstants.SearchForStreet:
                    if (street.Text != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForStreet;
                        searchStringPrimary = street.Text;
                    }
                    break;
                case SearchFunctionConstants.SearchForTimeSpan:
                    if (startDate.Text != "" && endDate.Text != "" && ParseCutString(startDate.Text) != DateTime.Today && ParseCutString(endDate.Text) != DateTime.Today)
                    {
                        searchForString = SearchFunctionConstants.SearchForTimeSpan;
                        searchStringPrimary = startDate.Text;
                        searchStringSecondary = endDate.Text;
                    }
                    break;
                case SearchFunctionConstants.SearchForPaymentOption:
                    if (paymentMethod.Text != "" )
                    {
                        searchForString = SearchFunctionConstants.SearchForPaymentOption;
                        searchStringPrimary = paymentMethod.Text;
                    }
                    break;
                case SearchFunctionConstants.SearchForSubscriptionOption:
                    if (paymentMethod.Text != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForSubscriptionOption;
                        searchStringPrimary = subscriptionType.Text;
                    }
                    break;
            }

            if (searchForString != "" && searchStringPrimary != "")
            {
                await SearchAttributes(table, searchForString, searchStringPrimary, searchStringSecondary).ConfigureAwait(false);
            }
        }


        public async Task<bool> SearchAttributes(ListView table, string searchForString, string searchStringPrimary, string searchStringSecondary)
        {
            var people = await _mongoDBService.LoadRecordsAsync<Client>(_mongoDBService.GetMongoDBConfiguration().CollectionName).ConfigureAwait(false);

            IEnumerable<Client> foundList = new List<Client>();

            switch (searchForString)
            {
                case SearchFunctionConstants.SearchForID:
                    foundList = people.Where(x => x.Id.Contains(searchStringPrimary));
                    break;

                case SearchFunctionConstants.SearchForFirstname:
                    foundList = people.Where(x => x.FirstName.Contains(searchStringPrimary));
                    break;

                case SearchFunctionConstants.SearchForLastName:
                    foundList = people.Where(x => x.FirstName.Contains(searchStringPrimary));
                    break;

                case SearchFunctionConstants.SearchForEmail:
                    foundList = people.Where(x => x.Email.Contains(searchStringPrimary));
                    break;

                case SearchFunctionConstants.SearchForCountry:
                    foundList = people.Where(x => x.Address.Country.Contains(searchStringPrimary));
                    break;

                case SearchFunctionConstants.SearchForState:
                    foundList = people.Where(x => x.Address.State.Contains(searchStringPrimary));
                    break;

                case SearchFunctionConstants.SearchForCity:
                    foundList = people.Where(x => x.Address.City.Contains(searchStringPrimary));
                    break;

                case SearchFunctionConstants.SearchForStreet:
                    foundList = people.Where(x => x.Address.Street.Contains(searchStringPrimary));
                    break;

                case SearchFunctionConstants.SearchForTimeSpan:
                    var abc = ParseCutString(searchStringPrimary);
                    var z = abc;
                    foundList = people.Where(x => DateTime.Parse(x.Subscription.StartDate) >= ParseCutString(searchStringPrimary) && DateTime.Parse(x.Subscription.EndDate) <= ParseCutString(searchStringSecondary));
                    break;

                case SearchFunctionConstants.SearchForPaymentOption:
                    foundList = people.Where(x => x.Subscription.PaymentMethod.Contains(searchStringPrimary));
                    break;

                case SearchFunctionConstants.SearchForSubscriptionOption:
                    foundList = people.Where(x => x.Subscription.SubscriptionType.Contains(searchStringPrimary));
                    break;
            }
            table.Invoke(new Action(() =>
            {
                table.Items.Clear();
            }));
            var x = foundList.ToList();
            if (foundList.Any())
            {
                FillListView(table, foundList);
            }

            return true;
        }
    }
}