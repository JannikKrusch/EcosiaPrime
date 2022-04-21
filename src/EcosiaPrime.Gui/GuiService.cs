using EcosiaPrime.Contracts.Constants;
using EcosiaPrime.Contracts.Models;
using EcosiaPrime.MongoDB;

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
            clients.ToList().ForEach(client => InvokeListView(listView, GetFilledRow(client)));
        }

        public void FillListView(ListView listView, Client client)
        {
            InvokeListView(listView, GetFilledRow(client));
        }

        public async Task CreateClientAsync(
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
                return;
            }

            if (await DoesIdExist(_mongoDBService.GetMongoDBConfiguration().CollectionName, id.Text).ConfigureAwait(false))
            {
                InvokeResponseTextBox(response, new List<string> { ResponseMessagesConstants.IDAlreadyExistsInDB });
                return;
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

            client.Subscription.PaymentMethod = GetPaymentMethod(InvokeComboBox(paymentMethod));
            client.Subscription.SubscriptionType = GetSubscriptionType(InvokeComboBox(subscriptionType));

            var successful = await _mongoDBService.InsertRecordAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName, client).ConfigureAwait(false);
            if (successful)
            {
                InvokeResponseTextBox(response, new List<string> { ResponseMessagesConstants.AddClientToDBSuccessful });
            }
            else
            {
                InvokeResponseTextBox(response, new List<string> { ResponseMessagesConstants.AddClientToDBFailure });
            }
        }

        public async Task UpdateClientAsync(
            TextBox response,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber,
            DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            if (!await DoesIdExist(_mongoDBService.GetMongoDBConfiguration().CollectionName, id.Text).ConfigureAwait(false))
            {
                InvokeResponseTextBox(response, new List<string> { ResponseMessagesConstants.IDDoesntExistInDB });
                return;
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
                    return;
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

                client.Subscription.PaymentMethod = GetPaymentMethod(paymentMethod.Text);
                client.Subscription.SubscriptionType = GetSubscriptionType(subscriptionType.Text);

                var successful = await _mongoDBService.UpsertRecordAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName, client.Id, client).ConfigureAwait(false);
                if (successful)
                {
                    InvokeResponseTextBox(response, new List<string> { ResponseMessagesConstants.UpdateClientToDBSuccessful });
                }
                else
                {
                    InvokeResponseTextBox(response, new List<string> { ResponseMessagesConstants.UpdateClientToDBFailure });
                }
            }
        }

        public async Task DeleteClientAsync(
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
                return;
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
        }

        public async Task ShowClientsAsync(ComboBox filter, ListView table, string id)
        {
            table.Items.Clear();

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
    }
}