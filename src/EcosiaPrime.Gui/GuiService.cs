using EcosiaPrime.Contracts.Constants;
using EcosiaPrime.Contracts.Models;
using EcosiaPrime.Gui.ExtensionMethods;
using EcosiaPrime.MongoDB;

namespace EcosiaPrime.Gui
{
    public class GuiService : IGuiService
    {
        private readonly IMongoDBService _mongoDBService;
        private readonly IMongoDBConfiguration _mongoDBConfiguration;

        public GuiService(IMongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
            _mongoDBConfiguration = _mongoDBService.MongoDBRepository.GetMongoDBConfiguration();
        }

        /// <summary>
        /// Schaut, ob alle Felder richtig ausgefüllt sind, wenn ja: neues Client Objekt wird erzeugt der Datenbank hinzugefügt; wenn nein: werden entsprechene Fehler angezeigt
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
        public async Task<IEnumerable<string>> CreateClientAsync(
            string id, string firstName, string lastName, string email, string password,
            string country, string state, string postCode, string city, string street, string houseNumber,
            string startDate, string endDate, string paymentMethod, string subscriptionType)
        {
            var responseLines = id.CheckInputFieldsEmpty(
                firstName, lastName, email,
                password, country, state, postCode, city, street,
                houseNumber, startDate, endDate, paymentMethod, subscriptionType);

            if (!await _mongoDBService.IsEmailUniqueAsync<Client>(_mongoDBConfiguration.CollectionName, email))
            {
                var temp = responseLines.ToList();
                temp.Add(ResponseMessagesConstants.EmailIsNotUnique);
                responseLines = temp;
            }

            if (responseLines.Any())
            {
                return responseLines;
            }

            if (await _mongoDBService.DoesIdExistAsync(_mongoDBConfiguration.CollectionName, id).ConfigureAwait(false))
            {
                return new List<string> { ResponseMessagesConstants.IDAlreadyExistsInDB };
            }

            var client = new Client();
            client.Id = id;
            client.FirstName = firstName;
            client.LastName = lastName;
            client.Email = email;
            client.Password = password;

            client.Address = new Address();
            client.Address.Country = country;
            client.Address.State = state;
            client.Address.PostCode = postCode;
            client.Address.City = city;
            client.Address.Street = street;
            client.Address.HouseNumber = houseNumber;

            client.Subscription = new Subscription();
            client.Subscription.StartDate = startDate;
            client.Subscription.EndDate = endDate;

            client.Subscription.PaymentMethod = paymentMethod;
            client.Subscription.SubscriptionType = subscriptionType;

            var successful = await _mongoDBService.MongoDBRepository.InsertRecordAsync(_mongoDBConfiguration.CollectionName, client).ConfigureAwait(false);
            if (successful)
            {
                return new List<string> { ResponseMessagesConstants.AddClientToDBSuccessful };
            }
            else
            {
                return new List<string> { ResponseMessagesConstants.AddClientToDBFailure };
            }
        }

        /// <summary>
        /// Methode hat 2 durchläufe
        /// 1. Nur die ID ausgefüllt -> wenn ID in Datenbank existiert, werden die Daten in die Felder übertragen
        /// 2. Wenn alle Felder ausgefüllt sind -> bearbeitete Version ersetzt die alte Version vom Kunden
        /// Bei Fehlern werden Fehlermeldungen ausgegeben
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
        public async Task<IEnumerable<string>> UpdateClientAsync(
            string id, string firstName, string lastName, string email, string password,
            string country, string state, string postCode, string city, string street, string houseNumber,
            string startDate, string endDate, string paymentMethod, string subscriptionType)
        {
            if (!await _mongoDBService.DoesIdExistAsync(_mongoDBConfiguration.CollectionName, id).ConfigureAwait(false))
            {
                return new List<string> { ResponseMessagesConstants.IDDoesntExistInDB };
            }

            if (id.ArePersonInputFieldsEmptyExceptId(firstName, lastName, email, password) && country.AreAdressInputFieldsEmpty(state, postCode, city, houseNumber, street) && !startDate.ArePaymentSubscriptionInputFieldsEmpty(endDate))
            {
                var clientDB = await _mongoDBService.MongoDBRepository.LoadRecordByIdAsync<Client>(_mongoDBConfiguration.CollectionName, id).ConfigureAwait(false);

                var fields = new List<string>();
                fields.Add(clientDB.Id);
                fields.Add(clientDB.FirstName);
                fields.Add(clientDB.LastName);
                fields.Add(clientDB.Email);
                fields.Add(clientDB.Password);
                fields.Add(clientDB.Address.Country);
                fields.Add(clientDB.Address.State);
                fields.Add(clientDB.Address.PostCode);
                fields.Add(clientDB.Address.City);
                fields.Add(clientDB.Address.Street);
                fields.Add(clientDB.Address.HouseNumber);
                fields.Add(clientDB.Subscription.StartDate);
                fields.Add(clientDB.Subscription.EndDate);
                fields.Add(clientDB.Subscription.PaymentMethod);
                fields.Add(clientDB.Subscription.SubscriptionType);

                return fields;
            }
            else
            {
                var responseLines = id.CheckInputFieldsEmpty(
                firstName, lastName, email,
                password, country, state, postCode, city, street,
                houseNumber, startDate, endDate, paymentMethod, subscriptionType).ToList();

                var clientDB = await _mongoDBService.MongoDBRepository.LoadRecordByIdAsync<Client>(_mongoDBConfiguration.CollectionName, id).ConfigureAwait(false);
                if (clientDB.Email != email)
                {
                    if (!await _mongoDBService.IsEmailUniqueAsync<Client>(_mongoDBConfiguration.CollectionName, email))
                    {
                        var temp = responseLines.ToList();
                        temp.Add(ResponseMessagesConstants.EmailIsNotUnique);
                        responseLines = temp;
                    }
                }

                if (responseLines.Any())
                {
                    return responseLines;
                }

                var client = new Client();
                client.Id = id;
                client.FirstName = firstName;
                client.LastName = lastName;
                client.Email = email;
                client.Password = password;

                client.Address = new Address();
                client.Address.Country = country;
                client.Address.State = state;
                client.Address.PostCode = postCode;
                client.Address.City = city;
                client.Address.Street = street;
                client.Address.HouseNumber = houseNumber;

                client.Subscription = new Subscription();
                client.Subscription.StartDate = startDate;
                client.Subscription.EndDate = endDate;

                client.Subscription.PaymentMethod = paymentMethod;
                client.Subscription.SubscriptionType = subscriptionType;

                responseLines = new List<string>();
                var successful = await _mongoDBService.MongoDBRepository.UpsertRecordAsync(_mongoDBConfiguration.CollectionName, client.Id, client).ConfigureAwait(false);
                if (successful)
                {
                    responseLines.Add(ResponseMessagesConstants.UpdateClientToDBSuccessful);
                }
                else
                {
                    responseLines.Add(ResponseMessagesConstants.UpdateClientToDBFailure);
                }
                return responseLines;
            }
        }

        /// <summary>
        /// Schaut, ob eingebene ID existiert und löscht entsprechenen Eintag oder gibt Fehlermeldung aus
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<string>> DeleteClientAsync(string id)
        {
            var responseLines = new List<string>();

            if (!await _mongoDBService.DoesIdExistAsync(_mongoDBConfiguration.CollectionName, id).ConfigureAwait(false))
            {
                responseLines.Add(ResponseMessagesConstants.IDDoesntExistInDB);
            }

            if (responseLines.Any())
            {
                return responseLines;
            }

            var fields = new List<string>();
            var successful = await _mongoDBService.MongoDBRepository.DeleteRecordAsync<Client>(_mongoDBConfiguration.CollectionName, id).ConfigureAwait(false);
            if (successful)
            {
                fields.Add(ResponseMessagesConstants.DeleteClientToDBSuccessful);
            }
            else
            {
                fields.Add(ResponseMessagesConstants.DeleteClientToDBFailure);
            }
            return fields;
        }

        /// <summary>
        /// Einträge werden dem Filter entsprechend in eine Liste eingetragen und zurückgegeben
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Client>> ShowClientsAsync(string filter, string id)
        {
            IEnumerable<Client> clients = new List<Client>();
            var client = new Client();

            switch (filter)
            {
                case FilterOptionsConstants.AllByID:
                    clients = await _mongoDBService.SortRecordByIdAsync(_mongoDBConfiguration.CollectionName).ConfigureAwait(false);
                    break;

                case FilterOptionsConstants.AllByFirstname:
                    clients = await _mongoDBService.SortRecordByFirstNameAsync(_mongoDBConfiguration.CollectionName).ConfigureAwait(false);
                    break;

                case FilterOptionsConstants.AllByLastName:
                    clients = await _mongoDBService.SortRecordByLastNameAsync(_mongoDBConfiguration.CollectionName).ConfigureAwait(false);
                    break;

                case FilterOptionsConstants.AllByEmail:
                    clients = await _mongoDBService.SortRecordByEmailAsync(_mongoDBConfiguration.CollectionName).ConfigureAwait(false);
                    break;

                case FilterOptionsConstants.AllByCountry:
                    clients = await _mongoDBService.SortRecordByCountyAsync(_mongoDBConfiguration.CollectionName).ConfigureAwait(false);
                    break;

                case FilterOptionsConstants.AllBySubscription:
                    clients = await _mongoDBService.SortRecordBySubscriptionTypeAsync(_mongoDBConfiguration.CollectionName).ConfigureAwait(false);
                    break;

                case FilterOptionsConstants.OneById:
                    client = await _mongoDBService.MongoDBRepository.LoadRecordByIdAsync<Client>(_mongoDBConfiguration.CollectionName, id).ConfigureAwait(false);
                    break;
            }

            if (clients.Any())
            {
                return clients;
            }
            else if (client != null)
            {
                return new List<Client>() { client };
            }
            else
            {
                return new List<Client>() { };
            }
        }

        /// <summary>
        /// Es wird nach Einträgen gesucht, die dem Suchkriterium entsprechen und gibt eine Liste zurück
        /// </summary>
        /// <param name="filter"></param>
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
        public async Task<IEnumerable<Client>> SearchFunctionAsync(
            string filter,
            string id, string firstName, string lastName, string email, string password,
            string country, string state, string postCode, string city, string street, string houseNumber,
            string startDate, string endDate, string paymentMethod, string subscriptionType)
        {
            var searchForString = "";
            var searchStringPrimary = "";
            var searchStringSecondary = "";
            switch (filter)
            {
                case SearchFunctionConstants.SearchForID:
                    if (id != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForID;
                        searchStringPrimary = id;
                    }
                    break;

                case SearchFunctionConstants.SearchForFirstname:
                    if (firstName != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForFirstname;
                        searchStringPrimary = firstName;
                    }
                    break;

                case SearchFunctionConstants.SearchForLastName:
                    if (lastName != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForLastName;
                        searchStringPrimary = lastName;
                    }
                    break;

                case SearchFunctionConstants.SearchForEmail:
                    if (email != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForEmail;
                        searchStringPrimary = email;
                    }
                    break;

                case SearchFunctionConstants.SearchForCountry:
                    if (country != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForCountry;
                        searchStringPrimary = country;
                    }
                    break;

                case SearchFunctionConstants.SearchForState:
                    if (state != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForState;
                        searchStringPrimary = state;
                    }
                    break;

                case SearchFunctionConstants.SearchForPostCode:
                    if (postCode != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForPostCode;
                        searchStringPrimary = postCode;
                    }
                    break;

                case SearchFunctionConstants.SearchForCity:
                    if (city != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForCity;
                        searchStringPrimary = city;
                    }
                    break;

                case SearchFunctionConstants.SearchForStreet:
                    if (street != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForStreet;
                        searchStringPrimary = street;
                    }
                    break;

                case SearchFunctionConstants.SearchForTimeSpan:
                    if (startDate != "" && endDate != "" && startDate.ParseString() != DateTime.Today && endDate.ParseString() != DateTime.Today)
                    {
                        searchForString = SearchFunctionConstants.SearchForTimeSpan;
                        searchStringPrimary = startDate;
                        searchStringSecondary = endDate;
                    }
                    break;

                case SearchFunctionConstants.SearchForPaymentOption:
                    if (paymentMethod != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForPaymentOption;
                        searchStringPrimary = paymentMethod;
                    }
                    break;

                case SearchFunctionConstants.SearchForSubscriptionOption:
                    if (paymentMethod != "")
                    {
                        searchForString = SearchFunctionConstants.SearchForSubscriptionOption;
                        searchStringPrimary = subscriptionType;
                    }
                    break;
            }

            if (searchForString != "" && searchStringPrimary != "")
            {
                return await SearchAttributesAsync(searchForString, searchStringPrimary, searchStringSecondary).ConfigureAwait(false);
            }
            return new List<Client>() { };
        }

        /// <summary>
        /// Ist die eigentliche Suchfunktion für die obrige Methode
        /// </summary>
        /// <param name="searchForString"></param>
        /// <param name="searchStringPrimary"></param>
        /// <param name="searchStringSecondary"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Client>> SearchAttributesAsync(string searchForString, string searchStringPrimary, string searchStringSecondary)
        {
            var people = await _mongoDBService.MongoDBRepository.LoadRecordsAsync<Client>(_mongoDBConfiguration.CollectionName).ConfigureAwait(false);

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
                    foundList = people.Where(x => DateTime.Parse(x.Subscription.StartDate) >= searchStringPrimary.ParseString() && DateTime.Parse(x.Subscription.EndDate) <= searchStringSecondary.ParseString());
                    break;

                case SearchFunctionConstants.SearchForPaymentOption:
                    foundList = people.Where(x => x.Subscription.PaymentMethod.Contains(searchStringPrimary));
                    break;

                case SearchFunctionConstants.SearchForSubscriptionOption:
                    foundList = people.Where(x => x.Subscription.SubscriptionType.Contains(searchStringPrimary));
                    break;
            }

            return foundList;
        }
    }
}