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
            /*var containsLowerCase = password.Text.Any(char.IsLower);
            var containsUpperCase = password.Text.Any(char.IsUpper);
            var hasMinAmountOfCharacters = password.Text.Count() >= 8;*/
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
                client.Address.Country, client.Address.State, client.Address.PostCode, client.Address.City, client.Address.Street, client.Address.StreetNumber,
                client.Subscription.StartDate, client.Subscription.EndDate, client.Subscription.PaymentMethod, client.Subscription.SubscriptionType
                };
                return row;
            }
            return new string[] { };
        }

        public void FillListView(ListView listView, IEnumerable<Client> clients)
        {
            listView.Invoke(new Action(() =>
            {
                listView.Items.Clear();
            }));
            clients.ToList().ForEach(client => InvokeListView(listView, GetFilledRow(client)));
        }

        public void FillListView(ListView listView, Client client)
        {
            InvokeListView(listView, GetFilledRow(client));
        }

        public async Task<bool> CreateClientAsync(
            TextBox response,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber,
            DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType)
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
            client.Address.StreetNumber = streetNumber.Text;

            client.Subscription = new Subscription();
            client.Subscription.StartDate = startDate.Text;
            client.Subscription.EndDate = endDate.Text;

            client.Subscription.PaymentMethod = InvokeComboBox(paymentMethod);//GetPaymentMethod(InvokeComboBox(paymentMethod));
            client.Subscription.SubscriptionType = InvokeComboBox(subscriptionType);//GetSubscriptionType(InvokeComboBox(subscriptionType));

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
                InvokeTextBox(streetNumber, clientDB.Address.StreetNumber);

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
                client.Address.StreetNumber = streetNumber.Text;

                client.Subscription = new Subscription();
                client.Subscription.StartDate = startDate.Text;
                client.Subscription.EndDate = endDate.Text;

                client.Subscription.PaymentMethod = InvokeComboBox(paymentMethod);//GetPaymentMethod(InvokeComboBox(paymentMethod));
                client.Subscription.SubscriptionType = InvokeComboBox(subscriptionType);//GetSubscriptionType(InvokeComboBox(subscriptionType));

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
            //table.Items.Clear();

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

            if (clients.Any())
            {
                FillListView(table, clients);
            }
            else
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
            ListView table,
            TextBox response,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber,
            DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            var searchForString = "";
            var searchString = "";

            if (id.Text != "")
            {
                searchForString = SearchFunctionConstants.SearchForID;
                searchString = id.Text;
            }
            else if (firstName.Text != "")
            {
                searchForString = SearchFunctionConstants.SearchForFirstname;
                searchString = firstName.Text;
            }
            else if (lastName.Text != "")
            {
                searchForString = SearchFunctionConstants.SearchForLastName;
                searchString = lastName.Text;
            }
            else if (email.Text != "")
            {
                searchForString = SearchFunctionConstants.SearchForEmail;
                searchString = email.Text;
            }
            else if (country.Text != "")
            {
                searchForString = SearchFunctionConstants.SearchForCountry;
                searchString = country.Text;
            }
            else if (state.Text != "")
            {
                searchForString = SearchFunctionConstants.SearchForState;
                searchString = state.Text;
            }
            else if (postCode.Text != "")
            {
                searchForString = SearchFunctionConstants.SearchForPostCode;
                searchString = postCode.Text;
            }
            else if (city.Text != "")
            {
                searchForString = SearchFunctionConstants.SearchForCity;
                searchString = city.Text;
            }
            else if (street.Text != "")
            {
                searchForString = SearchFunctionConstants.SearchForStreet;
                searchString = street.Text;
            }
            else if (startDate.Text != "" && endDate.Text != "")
            {
                searchForString = SearchFunctionConstants.SearchForStreet;
                searchString = street.Text;
            }

            await SearchAttributes(table, searchForString, searchString).ConfigureAwait(false);
        }


        public async Task<bool> SearchAttributes(ListView table, string searchForString, string searchString)
        {
            var people = await _mongoDBService.LoadRecordsAsync<Client>(_mongoDBService.GetMongoDBConfiguration().CollectionName).ConfigureAwait(false);

            IEnumerable<Client> foundList = new List<Client>();

            switch (searchForString)
            {
                case SearchFunctionConstants.SearchForID:
                    foundList = people.Where(x => x.Id.Contains(searchString));
                    break;

                case SearchFunctionConstants.SearchForFirstname:
                    foundList = people.Where(x => x.FirstName.Contains(searchString));
                    break;

                case SearchFunctionConstants.SearchForLastName:
                    foundList = people.Where(x => x.FirstName.Contains(searchString));
                    break;

                case SearchFunctionConstants.SearchForEmail:
                    foundList = people.Where(x => x.Email.Contains(searchString));
                    break;

                case SearchFunctionConstants.SearchForCountry:
                    foundList = people.Where(x => x.Address.Country.Contains(searchString));
                    break;

                case SearchFunctionConstants.SearchForState:
                    foundList = people.Where(x => x.Address.State.Contains(searchString));
                    break;

                case SearchFunctionConstants.SearchForCity:
                    foundList = people.Where(x => x.Address.City.Contains(searchString));
                    break;

                case SearchFunctionConstants.SearchForStreet:
                    foundList = people.Where(x => x.Address.Street.Contains(searchString));
                    break;
            }

            var x = foundList.ToList();
            if (foundList.Any())
            {
                FillListView(table, foundList);
            }

            return true;
        }
    }
}