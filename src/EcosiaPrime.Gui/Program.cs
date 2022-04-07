
using EcosiaPrime.Contracts.Models;
using EcosiaPrime.MongoDB;
using Newtonsoft.Json;

namespace EcosiaPrime.Gui
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            dynamic json = JsonConvert.DeserializeObject(File.ReadAllText("..\\..\\..\\appsettings.json"));
            Console.WriteLine(json);
            var mongoDBConfiguration = new MongoDBConfiguration();
            var mongoDBConfirgurationJson = json["MongoDBConfiguration"];
            mongoDBConfiguration.DateBaseName = mongoDBConfirgurationJson["DataBaseName"];
            mongoDBConfiguration.CollectionName = mongoDBConfirgurationJson["CollectionName"];

            IMongoDBRepository mongoDBRepository = new MongoDBRepository(mongoDBConfiguration);
            IMongoDBService mongoDBService = new MongoDBService(mongoDBRepository);

            Client client = new Client();
            client.SetFirstName("pskfa");
            client.SetLastName("cnoi");
            client.SetEmail("ijeiw");
            client.SetId("812");
            client.SetSubscription(new Subscription());
            client.SetAddress(new Address());
            client.SetPassword("fwoemfw");

            await mongoDBRepository.InsertRecord<Client>(mongoDBConfiguration.CollectionName, client).ConfigureAwait(false);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(mongoDBService));
        }
    }
}