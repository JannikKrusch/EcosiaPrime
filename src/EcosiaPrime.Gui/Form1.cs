using EcosiaPrime.MongoDB;

namespace EcosiaPrime.Gui
{
    public partial class Form1 : Form
    {
        private readonly IMongoDBService _mongoDBService;
        public Form1(IMongoDBService mongoDBService)
        {
            _mongoDBService = mongoDBService;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}