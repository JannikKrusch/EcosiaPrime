using EcosiaPrime.Contracts.Constants;
using EcosiaPrime.Contracts.Models;
using EcosiaPrime.Gui.ExtensionMethods;
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

        public async Task<bool> DoesIdExistAsync(string collectionName, string id)
        {
            var exists = await _mongoDBService.LoadRecordByIdAsync<Client>(collectionName, id).ConfigureAwait(false);
            return exists != null;
        }

        public async Task<bool> CreateClientAsync(
            TextBox response,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox houseNumber,
            DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            var responseLines = CheckSyntaxExtensionMethods.CheckInputFieldsEmpty(
                response,
                id, firstName, lastName, email,
                password, country, state, postCode, city, street,
                houseNumber, startDate, endDate, paymentMethod, subscriptionType);

            if (responseLines.Any())
            {
                response.InvokeResponseTextBox(responseLines);
                return false;
            }

            if (await DoesIdExistAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName, id.Text).ConfigureAwait(false))
            {
                response.InvokeResponseTextBox(new List<string> { ResponseMessagesConstants.IDAlreadyExistsInDB });
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

            client.Subscription.PaymentMethod = paymentMethod.InvokeComboBox();
            client.Subscription.SubscriptionType = subscriptionType.InvokeComboBox();

            var successful = await _mongoDBService.InsertRecordAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName, client).ConfigureAwait(false);
            if (successful)
            {
                response.InvokeResponseTextBox(new List<string> { ResponseMessagesConstants.AddClientToDBSuccessful });
            }
            else
            {
                response.InvokeResponseTextBox(new List<string> { ResponseMessagesConstants.AddClientToDBFailure });
            }
            return successful;
        }

        public async Task<bool> UpdateClientAsync(
            TextBox response,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox houseNumber,
            DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            if (!await DoesIdExistAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName, id.Text).ConfigureAwait(false))
            {
                response.InvokeResponseTextBox(new List<string> { ResponseMessagesConstants.IDDoesntExistInDB });
                return false;
            }

            if (id.ArePersonInputFieldsEmptyExceptId(firstName, lastName, email, password) && country.AreAdressInputFieldsEmpty(state, postCode, city, houseNumber, street) && !startDate.ArePaymentSubscriptionInputFieldsEmpty(endDate))
            {
                var clientDB = await _mongoDBService.LoadRecordByIdAsync<Client>(_mongoDBService.GetMongoDBConfiguration().CollectionName, id.Text).ConfigureAwait(false);

                id.InvokeTextBox(clientDB.Id);
                firstName.InvokeTextBox(clientDB.FirstName);
                lastName.InvokeTextBox(clientDB.LastName);
                email.InvokeTextBox(clientDB.Email);
                password.InvokeTextBox(clientDB.Password);

                country.InvokeTextBox(clientDB.Address.Country);
                state.InvokeTextBox(clientDB.Address.State);
                postCode.InvokeTextBox(clientDB.Address.PostCode);
                city.InvokeTextBox(clientDB.Address.City);
                street.InvokeTextBox(clientDB.Address.Street);
                houseNumber.InvokeTextBox(clientDB.Address.HouseNumber);

                startDate.InvokeDateTimePicker(clientDB.Subscription.StartDate);
                endDate.InvokeDateTimePicker(clientDB.Subscription.EndDate);
                paymentMethod.InvokeComboBox(clientDB.Subscription.PaymentMethod);
                subscriptionType.InvokeComboBox(clientDB.Subscription.SubscriptionType);

                response.InvokeResponseTextBox(new List<string> { });
                //Hier muss --> false <-- zurückgegeben werden, obwohl alles funktioniert hat, da ansonsten alle Felder geleert werden!
                return false;
            }
            else
            {
                var responseLines = response.CheckInputFieldsEmpty(
                id, firstName, lastName, email,
                password, country, state, postCode, city, street,
                houseNumber, startDate, endDate, paymentMethod, subscriptionType);

                if (responseLines.Any())
                {
                    response.InvokeResponseTextBox(responseLines);
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

                client.Subscription.PaymentMethod = paymentMethod.InvokeComboBox();
                client.Subscription.SubscriptionType = subscriptionType.InvokeComboBox();

                var successful = await _mongoDBService.UpsertRecordAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName, client.Id, client).ConfigureAwait(false);
                if (successful)
                {
                    response.InvokeResponseTextBox(new List<string> { ResponseMessagesConstants.UpdateClientToDBSuccessful });
                }
                else
                {
                    response.InvokeResponseTextBox(new List<string> { ResponseMessagesConstants.UpdateClientToDBFailure });
                }
                return successful;
            }
        }

        public async Task<bool> DeleteClientAsync(
            TextBox response,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox houseNumber,
            DateTimePicker startDate, DateTimePicker endDate, ComboBox paymentMethod, ComboBox subscriptionType)
        {
            var responseLines = new List<string>();

            if (!await DoesIdExistAsync(_mongoDBService.GetMongoDBConfiguration().CollectionName, id.Text).ConfigureAwait(false))
            {
                responseLines.Add(ResponseMessagesConstants.IDDoesntExistInDB);
            }

            if (responseLines.Any())
            {
                response.InvokeResponseTextBox(responseLines);
                return false;
            }

            var successful = await _mongoDBService.DeleteRecordAsync<Client>(_mongoDBService.GetMongoDBConfiguration().CollectionName, id.Text).ConfigureAwait(false);
            if (successful)
            {
                response.InvokeResponseTextBox(new List<string> { ResponseMessagesConstants.DeleteClientToDBSuccessful });
            }
            else
            {
                response.InvokeResponseTextBox(new List<string> { ResponseMessagesConstants.DeleteClientToDBFailure });
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
                table.FillListView(clients);
            }
            else if (client != null)
            {
                table.FillListView(client);
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

        public async Task SearchFunctionAsync(
            ListView table, ComboBox filter,
            TextBox response,
            TextBox id, TextBox firstName, TextBox lastName, TextBox email, TextBox password,
            TextBox country, TextBox state, TextBox postCode, TextBox city, TextBox street, TextBox houseNumber,
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
                    if (startDate.Text != "" && endDate.Text != "" && startDate.Text.ParseCutString() != DateTime.Today && endDate.Text.ParseCutString() != DateTime.Today)
                    {
                        searchForString = SearchFunctionConstants.SearchForTimeSpan;
                        searchStringPrimary = startDate.Text;
                        searchStringSecondary = endDate.Text;
                    }
                    break;

                case SearchFunctionConstants.SearchForPaymentOption:
                    if (paymentMethod.Text != "")
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
                await SearchAttributesAsync(table, searchForString, searchStringPrimary, searchStringSecondary).ConfigureAwait(false);
            }
        }

        public async Task SearchAttributesAsync(ListView table, string searchForString, string searchStringPrimary, string searchStringSecondary)
        {
            var people = await _mongoDBService.LoadRecordsAsync<Client>(_mongoDBService.GetMongoDBConfiguration().CollectionName).ConfigureAwait(false);

            IEnumerable<Client> foundList = new List<Client>();

            switch (searchForString)
            {
                case SearchFunctionConstants.SearchForID:
                    foundList = people.Where(x => x.Id.ToLower().Contains(searchStringPrimary.ToLower()));
                    break;

                case SearchFunctionConstants.SearchForFirstname:
                    foundList = people.Where(x => x.FirstName.ToLower().Contains(searchStringPrimary.ToLower()));
                    break;

                case SearchFunctionConstants.SearchForLastName:
                    foundList = people.Where(x => x.FirstName.ToLower().Contains(searchStringPrimary.ToLower()));
                    break;

                case SearchFunctionConstants.SearchForEmail:
                    foundList = people.Where(x => x.Email.ToLower().Contains(searchStringPrimary.ToLower()));
                    break;

                case SearchFunctionConstants.SearchForCountry:
                    foundList = people.Where(x => x.Address.Country.ToLower().Contains(searchStringPrimary.ToLower()));
                    break;

                case SearchFunctionConstants.SearchForState:
                    foundList = people.Where(x => x.Address.State.ToLower().Contains(searchStringPrimary.ToLower()));
                    break;

                case SearchFunctionConstants.SearchForCity:
                    foundList = people.Where(x => x.Address.City.ToLower().Contains(searchStringPrimary.ToLower()));
                    break;

                case SearchFunctionConstants.SearchForStreet:
                    foundList = people.Where(x => x.Address.Street.ToLower().Contains(searchStringPrimary.ToLower()));
                    break;

                case SearchFunctionConstants.SearchForTimeSpan:
                    var abc = searchStringPrimary.ParseCutString();
                    var z = abc;
                    foundList = people.Where(x => DateTime.Parse(x.Subscription.StartDate) >= searchStringPrimary.ParseCutString() && DateTime.Parse(x.Subscription.EndDate) <= searchStringSecondary.ParseCutString());
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
                table.FillListView(foundList);
            }
        }
    }
}