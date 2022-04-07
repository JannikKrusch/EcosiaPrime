
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
        static void Main()
        {
            dynamic json = JsonConvert.DeserializeObject(File.ReadAllText("..\\..\\..\\appsettings.json"));
            Console.WriteLine(json);
            var mongoDBConfiguration = new MongoDBConfiguration();
            var mongoDBConfirgurationJson = json["MongoDBConfiguration"];
            mongoDBConfiguration.DateBaseName = mongoDBConfirgurationJson["DataBaseName"];
            mongoDBConfiguration.CollectionName = mongoDBConfirgurationJson["CollectionName"];

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}