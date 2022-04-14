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
            return (id.Text != "" || firstName.Text == "" || lastName.Text == "" || email.Text == "" || password.Text == "");
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

        public void InvokeTextBox(TextBox textBox, string input)
        {
            textBox.Invoke(new Action(() =>
            {
                textBox.Text = input;
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
            else if (options == ComboBoxOptionConstants.Anzeigen)
            {
                await ShowClientsAsync(filter).ConfigureAwait(false);
            }
        }

        public async Task CreateClientAsync(
            Label responseLabel,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox streetNumber,
            TextBox startDate, TextBox endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            if (ArePersonInputFieldsEmpty(id, firstName, lastName, email, password))
            {
                responseLabel.Invoke(new Action(() =>
                {
                    responseLabel.Text = ResponseMessagesConstants.PersonDataInputFieldsAreEmpty;
                }));
                return;
            }

            if (AreAdressInputFieldsEmpty(country, state, postCode, city, street, streetNumber))
            {
                responseLabel.Invoke(new Action(() =>
                {
                    responseLabel.Text = ResponseMessagesConstants.AddressDataInputFieldsAreEmpty;
                }));
                return;
            }

            if (ArePaymentSubscriptionInputFieldsEmpty(startDate, endDate, paymentMethod, subscriptionType))
            {
                responseLabel.Invoke(new Action(() =>
                {
                    responseLabel.Text = ResponseMessagesConstants.PaymentSubscriptionInputFieldsAreEmpty;
                }));
                return;
            }

            if (await DoesIdExist(_mongoDBService.GetMongoDBConfiguration().CollectionName, id.Text).ConfigureAwait(false))
            {
                responseLabel.Invoke(new Action(() =>
                {
                    responseLabel.Text = ResponseMessagesConstants.IDAlreadyExistsInDB;
                }));
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
                responseLabel.Invoke(new Action(() =>
                {
                    responseLabel.Text = ResponseMessagesConstants.AddClientToDBSuccessful;
                }));
            }
            else
            {
                responseLabel.Invoke(new Action(() =>
                {
                    responseLabel.Text = ResponseMessagesConstants.AddClientToDBFailure;
                }));
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
                responseLabel.Invoke(new Action(() =>
                {
                    responseLabel.Text = ResponseMessagesConstants.IDDoesntExistInDB;
                }));
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

                paymentMethod.Invoke(new Action(() =>
                {
                    paymentMethod.Text = clientDB.Subscription.PaymentMethod;
                }));

                subscriptionType.Invoke(new Action(() =>
                {
                    subscriptionType.Text = clientDB.Subscription.SubscriptionType;
                }));

                responseLabel.Invoke(new Action(() =>
                {
                    responseLabel.Text = clientDB.Id;
                }));
            }
            else
            {
                if (ArePersonInputFieldsEmpty(id, firstName, lastName, email, password))
                {
                    responseLabel.Invoke(new Action(() =>
                    {
                        responseLabel.Text = ResponseMessagesConstants.PersonDataInputFieldsAreEmpty;
                    }));
                    return;
                }

                if (AreAdressInputFieldsEmpty(country, state, postCode, city, street, streetNumber))
                {
                    responseLabel.Invoke(new Action(() =>
                    {
                        responseLabel.Text = ResponseMessagesConstants.AddressDataInputFieldsAreEmpty;
                    }));
                    return;
                }

                if (ArePaymentSubscriptionInputFieldsEmpty(startDate, endDate, paymentMethod, subscriptionType))
                {
                    responseLabel.Invoke(new Action(() =>
                    {
                        responseLabel.Text = ResponseMessagesConstants.PaymentSubscriptionInputFieldsAreEmpty;
                    }));
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
                    responseLabel.Invoke(new Action(() =>
                    {
                        responseLabel.Text = ResponseMessagesConstants.UpdateClientToDBSuccessful;
                    }));
                }
                else
                {
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
            if (ArePersonInputFieldsEmptyExeptId(id, firstName, lastName, email, password))
            {
                responseLabel.Invoke(new Action(() =>
                {
                    responseLabel.Text = ResponseMessagesConstants.PersonDataInputFieldsAreEmptyExceptID;
                }));
            }

            if (AreAdressInputFieldsEmpty(country, state, postCode, city, street, streetNumber))
            {
                responseLabel.Invoke(new Action(() =>
                {
                    responseLabel.Text = ResponseMessagesConstants.AddressDataInputFieldsAreEmpty;
                }));
                return;
            }

            if (ArePaymentSubscriptionInputFieldsEmpty(startDate, endDate, paymentMethod, subscriptionType))
            {
                responseLabel.Invoke(new Action(() =>
                {
                    responseLabel.Text = ResponseMessagesConstants.PaymentSubscriptionInputFieldsAreEmpty;
                }));
                return;
            }

            if (!await DoesIdExist(_mongoDBService.GetMongoDBConfiguration().CollectionName, id.Text).ConfigureAwait(false))
            {
                responseLabel.Invoke(new Action(() =>
                {
                    responseLabel.Text = ResponseMessagesConstants.IDDoesntExistInDB;
                }));
                return;
            }

            var successful = await _mongoDBService.DeleteRecordAsync<Client>(_mongoDBService.GetMongoDBConfiguration().CollectionName, id.Text).ConfigureAwait(false);
            if (successful)
            {
                responseLabel.Invoke(new Action(() =>
                {
                    responseLabel.Text = ResponseMessagesConstants.DeleteClientToDBSuccessful;
                }));
            }
            else
            {
                responseLabel.Invoke(new Action(() =>
                {
                    responseLabel.Text = ResponseMessagesConstants.DeleteClientToDBFailure;
                }));
            }
        }

        public async Task ShowClientsAsync(ComboBox filter)
        {

        }
    }
}