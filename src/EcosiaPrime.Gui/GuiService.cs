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

        public bool ArePaymentSubscriptionInputFieldsEmpty(TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            return (startDate.Text == "" || endDate.Text == "" || paymentMethod.Text == "" || subscriptionType.Text == "");
        }

        public async Task<bool> DoesIdExist(string collectionName, string id)
        {
            var exists = await _mongoDBService.LoadRecordByIdAsync<Client>(collectionName, id).ConfigureAwait(false);
            return exists != null;
        }

        public string CheckInputFieldsEmpty(
            Label responseLabel,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber,
            TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            var responseText = "";
            if (ArePersonInputFieldsEmpty(id, firstName, lastName, email, password))
            {
                responseText += ResponseMessagesConstants.PersonDataInputFieldsAreEmpty + "\n";
            }

            if (AreAdressInputFieldsEmpty(country, state, postCode, city, street, streetNumber))
            {
                responseText += ResponseMessagesConstants.AddressDataInputFieldsAreEmpty + "\n";
            }

            if (ArePaymentSubscriptionInputFieldsEmpty(startDate, endDate, paymentMethod, subscriptionType))
            {
                responseText += ResponseMessagesConstants.PaymentSubscriptionInputFieldsAreEmpty;
            }
            return responseText;
        }

        public string CheckInputFieldsEmptyExeptID(
            Label responseLabel,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber,
            TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            var responseText = "";
            if (!ArePersonInputFieldsEmptyExeptId(id, firstName, lastName, email, password))
            {
                responseText += ResponseMessagesConstants.PersonDataInputFieldsAreEmptyExceptID + "\n";
            }

            if (AreAdressInputFieldsEmpty(country, state, postCode, city, street, streetNumber))
            {
                responseText += ResponseMessagesConstants.AddressDataInputFieldsAreEmpty + "\n";
            }

            if (ArePaymentSubscriptionInputFieldsEmpty(startDate, endDate, paymentMethod, subscriptionType))
            {
                responseText += ResponseMessagesConstants.PaymentSubscriptionInputFieldsAreEmpty;
            }
            return responseText;
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

        public void InvokeLabel(Label label, string input)
        {
            label.Invoke(new Action(() =>
            {
                label.Text = input;
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

        public async void StartButtonPressed(
            string options, Label responseLabel, ComboBox filter,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber,
            TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            await Option(
                options, responseLabel, filter,
                id, firstName, lastName, email, password,
                country, state, postCode, city, street, streetNumber,
                startDate, endDate, paymentMethod, subscriptionType).ConfigureAwait(false);
        }

        public async Task Option(
            string options, Label responseLabel, ComboBox filter,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber,
            TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            if (options == ComboBoxOptionConstants.Erstellen)
            {
                await CreateClientAsync(
                    responseLabel,
                    id, firstName, lastName, email, password,
                    country, state, postCode, city, street, streetNumber,
                    startDate, endDate, paymentMethod, subscriptionType)
                    .ConfigureAwait(false);
            }
            else if (options == ComboBoxOptionConstants.Bearbeiten)
            {
                await UpdateClientAsync(
                    responseLabel,
                    id, firstName, lastName, email, password,
                    country, state, postCode, city, street, streetNumber,
                    startDate, endDate, paymentMethod, subscriptionType).ConfigureAwait(false);
            }
            else if (options == ComboBoxOptionConstants.Löschen)
            {
                await DeleteClientAsync(
                    responseLabel,
                    id, firstName, lastName, email, password,
                    country, state, postCode, city, street, streetNumber,
                    startDate, endDate, paymentMethod, subscriptionType).ConfigureAwait(false);
            }
        }

        public async Task CreateClientAsync(
            Label responseLabel,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber,
            TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            var text = CheckInputFieldsEmpty(
                responseLabel,
                id, firstName, lastName, email,
                password, country, state, postCode, city, street,
                streetNumber, startDate, endDate, paymentMethod, subscriptionType);

            if (text != "")
            {
                InvokeLabel(responseLabel, text);
                return;
            }

            if (await DoesIdExist(_mongoDBService.GetMongoDBConfiguration().CollectionName, id.Text).ConfigureAwait(false))
            {
                InvokeLabel(responseLabel, ResponseMessagesConstants.IDAlreadyExistsInDB);
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
                InvokeLabel(responseLabel, ResponseMessagesConstants.AddClientToDBSuccessful);
            }
            else
            {
                InvokeLabel(responseLabel, ResponseMessagesConstants.AddClientToDBFailure);
            }
        }

        public async Task UpdateClientAsync(
            Label responseLabel,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber,
            TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            if (!await DoesIdExist(_mongoDBService.GetMongoDBConfiguration().CollectionName, id.Text).ConfigureAwait(false))
            {
                InvokeLabel(responseLabel, ResponseMessagesConstants.IDDoesntExistInDB);
                return;
            }

            if (ArePersonInputFieldsEmptyExeptId(id, firstName, lastName, email, password) && AreAdressInputFieldsEmpty(country, state, postCode, city, streetNumber, street) && ArePaymentSubscriptionInputFieldsEmpty(startDate, endDate, paymentMethod, subscriptionType))
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

                InvokeTextBox(startDate, clientDB.Subscription.StartDate);
                InvokeTextBox(endDate, clientDB.Subscription.EndDate);
                InvokeComboBox(paymentMethod, clientDB.Subscription.PaymentMethod);
                InvokeComboBox(subscriptionType, clientDB.Subscription.SubscriptionType);

                InvokeLabel(responseLabel, "");
            }
            else
            {
                var text = CheckInputFieldsEmptyExeptID(
                responseLabel,
                id, firstName, lastName, email,
                password, country, state, postCode, city, street,
                streetNumber, startDate, endDate, paymentMethod, subscriptionType);

                if (text != "")
                {
                    InvokeLabel(responseLabel, text);
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

                var successful = await _mongoDBService.InsertRecordAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName, client).ConfigureAwait(false);
                if (successful)
                {
                    InvokeLabel(responseLabel, ResponseMessagesConstants.UpdateClientToDBSuccessful);
                    responseLabel.Invoke(new Action(() =>
                    {
                        responseLabel.Text = ResponseMessagesConstants.UpdateClientToDBSuccessful;
                    }));
                }
                else
                {
                    InvokeLabel(responseLabel, ResponseMessagesConstants.UpdateClientToDBFailure);
                    responseLabel.Invoke(new Action(() =>
                    {
                        responseLabel.Text = ResponseMessagesConstants.UpdateClientToDBFailure;
                    }));
                }
            }
        }

        public async Task DeleteClientAsync(
            Label responseLabel,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber,
            TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            var text = "";

            if (!await DoesIdExist(_mongoDBService.GetMongoDBConfiguration().CollectionName, id.Text).ConfigureAwait(false))
            {
                text += ResponseMessagesConstants.IDDoesntExistInDB;
            }

            if (text != "")
            {
                InvokeLabel(responseLabel, text);
                return;
            }

            /*if (ArePersonInputFieldsEmptyExeptId(id, firstName, lastName, email, password))
            {
                InvokeLabel(responseLabel, ResponseMessagesConstants.PersonDataInputFieldsAreEmptyExceptID);
                responseLabel.Invoke(new Action(() =>
                {
                    responseLabel.Text = ResponseMessagesConstants.PersonDataInputFieldsAreEmptyExceptID;
                }));
            }

            if (AreAdressInputFieldsEmpty(country, state, postCode, city, street, streetNumber))
            {
                InvokeLabel(responseLabel, ResponseMessagesConstants.AddressDataInputFieldsAreEmpty);
                //responseLabel.Invoke(new Action(() =>
                //{
                //    responseLabel.Text = ResponseMessagesConstants.AddressDataInputFieldsAreEmpty;
                //}));
                return;
            }

            if (ArePaymentSubscriptionInputFieldsEmpty(startDate, endDate, paymentMethod, subscriptionType))
            {
                InvokeLabel(responseLabel, ResponseMessagesConstants.PaymentSubscriptionInputFieldsAreEmpty);
                //responseLabel.Invoke(new Action(() =>
                //{
                //    responseLabel.Text = ResponseMessagesConstants.PaymentSubscriptionInputFieldsAreEmpty;
                //}));
                return;
            }*/

            /*if (!await DoesIdExist(_mongoDBService.GetMongoDBConfiguration().CollectionName, id.Text).ConfigureAwait(false))
            {
                InvokeLabel(responseLabel, ResponseMessagesConstants.IDDoesntExistInDB);
                //responseLabel.Invoke(new Action(() =>
                //{
                //    responseLabel.Text = ResponseMessagesConstants.IDDoesntExistInDB;
                //}));
                return;
            }*/

            var successful = await _mongoDBService.DeleteRecordAsync<Client>(_mongoDBService.GetMongoDBConfiguration().CollectionName, id.Text).ConfigureAwait(false);
            if (successful)
            {
                InvokeLabel(responseLabel, ResponseMessagesConstants.DeleteClientToDBSuccessful);
            }
            else
            {
                InvokeLabel(responseLabel, ResponseMessagesConstants.DeleteClientToDBFailure);
            }
        }

        public async Task ShowClientsAsync(ComboBox filter, ListView table, string id)
        {
            table.Items.Clear();
            switch (filter.Text)
            {
                case FilterOptionsConstants.AllByID:
                    var people = await _mongoDBService.SortRecordByIdAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName).ConfigureAwait(false);
                    foreach (var person in people)
                    {
                        string[] row = {
                            person.Id, person.FirstName, person.LastName, person.Email, person.Password,
                            person.Address.Country, person.Address.State, person.Address.PostCode, person.Address.City, person.Address.Street, person.Address.StreetNumber,
                            person.Subscription.StartDate, person.Subscription.EndDate, person.Subscription.PaymentMethod, person.Subscription.SubscriptionType
                        };
                        InvokeListView(table, row);
                    }
                    break;

                case FilterOptionsConstants.AllByFirstname:
                    people = await _mongoDBService.SortRecordByFirstNameAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName).ConfigureAwait(false);
                    foreach (var person in people)
                    {
                        string[] row = {
                            person.Id, person.FirstName, person.LastName, person.Email, person.Password,
                            person.Address.Country, person.Address.State, person.Address.PostCode, person.Address.City, person.Address.Street, person.Address.StreetNumber,
                            person.Subscription.StartDate, person.Subscription.EndDate, person.Subscription.PaymentMethod, person.Subscription.SubscriptionType
                        };
                        InvokeListView(table, row);
                    }
                    break;

                case FilterOptionsConstants.AllByLastName:
                    people = await _mongoDBService.SortRecordByLastNameAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName).ConfigureAwait(false);
                    foreach (var person in people)
                    {
                        string[] row = {
                            person.Id, person.FirstName, person.LastName, person.Email, person.Password,
                            person.Address.Country, person.Address.State, person.Address.PostCode, person.Address.City, person.Address.Street, person.Address.StreetNumber,
                            person.Subscription.StartDate, person.Subscription.EndDate, person.Subscription.PaymentMethod, person.Subscription.SubscriptionType
                        };
                        InvokeListView(table, row);
                    }
                    break;

                case FilterOptionsConstants.AllByEmail:
                    people = await _mongoDBService.SortRecordByEmailAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName).ConfigureAwait(false);
                    foreach (var person in people)
                    {
                        string[] row = {
                            person.Id, person.FirstName, person.LastName, person.Email, person.Password,
                            person.Address.Country, person.Address.State, person.Address.PostCode, person.Address.City, person.Address.Street, person.Address.StreetNumber,
                            person.Subscription.StartDate, person.Subscription.EndDate, person.Subscription.PaymentMethod, person.Subscription.SubscriptionType
                        };
                        InvokeListView(table, row);
                    }
                    break;

                case FilterOptionsConstants.AllByCountry:
                    people = await _mongoDBService.SortRecordByCountyAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName).ConfigureAwait(false);
                    foreach (var person in people)
                    {
                        string[] row = {
                            person.Id, person.FirstName, person.LastName, person.Email, person.Password,
                            person.Address.Country, person.Address.State, person.Address.PostCode, person.Address.City, person.Address.Street, person.Address.StreetNumber,
                            person.Subscription.StartDate, person.Subscription.EndDate, person.Subscription.PaymentMethod, person.Subscription.SubscriptionType
                        };
                        InvokeListView(table, row);
                    }
                    break;

                case FilterOptionsConstants.AllBySubscription:
                    people = await _mongoDBService.SortRecordBySubscriptionTypeAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName).ConfigureAwait(false);
                    foreach (var person in people)
                    {
                        string[] row = {
                            person.Id, person.FirstName, person.LastName, person.Email, person.Password,
                            person.Address.Country, person.Address.State, person.Address.PostCode, person.Address.City, person.Address.Street, person.Address.StreetNumber,
                            person.Subscription.StartDate, person.Subscription.EndDate, person.Subscription.PaymentMethod, person.Subscription.SubscriptionType
                        };
                        InvokeListView(table, row);
                    }
                    break;

                case FilterOptionsConstants.OneById:
                        var singlePerson = await _mongoDBService.LoadRecordByIdAsync<Client>(_mongoDBService.GetMongoDBConfiguration().CollectionName, id).ConfigureAwait(false);
                    
                        string[] singelRow = {
                            singlePerson.Id, singlePerson.FirstName, singlePerson.LastName, singlePerson.Email, singlePerson.Password,
                            singlePerson.Address.Country, singlePerson.Address.State, singlePerson.Address.PostCode, singlePerson.Address.City, singlePerson.Address.Street, singlePerson.Address.StreetNumber,
                            singlePerson.Subscription.StartDate, singlePerson.Subscription.EndDate, singlePerson.Subscription.PaymentMethod, singlePerson.Subscription.SubscriptionType
                        };
                        InvokeListView(table, singelRow);
                    
                    break;
            }
        }
    }
}