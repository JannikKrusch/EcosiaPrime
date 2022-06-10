using EcosiaPrime.MongoDB;
using Microsoft.Extensions.Configuration;

namespace EcosiaPrime.Gui
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = configBuilder.Build();
            IMongoDBConfiguration configuration = new MongoDBConfiguration();
            config.Bind(configuration);

            MongoDBConfiguration mongoDBConfiguration = new MongoDBConfiguration()
            {
                DataBaseName = configuration.DataBaseName,
                CollectionName = configuration.CollectionName
            };

            IMongoDBRepository mongoDBRepository = new MongoDBRepository(mongoDBConfiguration);
            IMongoDBService mongoDBService = new MongoDBService(mongoDBRepository);
            IGuiService guiService = new GuiService(mongoDBService);

            // To customize application configuration such as set high DPI settings or default font
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(guiService));
        }
    }
}