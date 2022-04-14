using EcosiaPrime.Contracts.Constants;
using EcosiaPrime.MongoDB;

namespace EcosiaPrime.Gui
{
    public partial class Form1 : Form
    {
        private readonly IMongoDBService _mongoDBService;
        private IEnumerable<Control> _controlsList;

        public Form1(IMongoDBService mongoDBService)
        {
            _controlsList = Controls.OfType<Control>().Where(x => x is TextBox || x is ComboBox && x.Name != "optionComboBox");
            _mongoDBService = mongoDBService;
            InitializeComponent();
            dataGrid.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            dataGrid.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            filterComboBox.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void dropdownMenuPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = dropdownMenuPayment.Text;
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            if (optionComboBox.Text == ComboBoxOptionConstants.Bearbeiten)
            {
                optionComboBox.SelectedIndex = -1;
            }

            ClearAllControls();
        }

        private void firstNameTextfield_TextChanged(object sender, EventArgs e)
        {
        }

        private void optionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (optionComboBox.Text)
            {
                case ComboBoxOptionConstants.Erstellen:
                    ChangeVisibilityOfFields(ComboBoxOptionConstants.Erstellen);
                    break;

                case ComboBoxOptionConstants.Bearbeiten:
                    ChangeVisibilityOfFields(ComboBoxOptionConstants.Bearbeiten);
                    break;

                case ComboBoxOptionConstants.Löschen:
                    ChangeVisibilityOfFields(ComboBoxOptionConstants.Löschen);
                    break;

                case ComboBoxOptionConstants.Anzeigen:
                    ChangeVisibilityOfFields(ComboBoxOptionConstants.Anzeigen);
                    break;

                default:
                    ChangeVisibilityOfFields(ComboBoxOptionConstants.Clear);
                    break;
            }
        }

        public void ChangeVisibilityOfFields(string option)
        {
            foreach (Control control in _controlsList)
            {
                foreach (string opt in GetVisibleFieldsList(option))
                {
                    if (control.Name == opt)
                    {
                        control.Visible = true;
                        break;
                    }
                    else
                    {
                        control.Visible = false;
                    }
                }
            }
        }
        
        public List<string> GetVisibleFieldsList(string option)
        {
            switch (option)
            {
                case ComboBoxOptionConstants.Erstellen:
                    return VisibleTextFieldListConstants.Erstellen;

                case ComboBoxOptionConstants.Bearbeiten:
                    return VisibleTextFieldListConstants.Bearbeiten;

                case ComboBoxOptionConstants.Löschen:
                    return VisibleTextFieldListConstants.Löschen;

                case ComboBoxOptionConstants.Anzeigen:
                    return VisibleTextFieldListConstants.Anzeigen;

                default:
                    return VisibleTextFieldListConstants.Erstellen;
            }
            return null;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGrid.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            dataGrid.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void ClearAllControls()
        {
            foreach (Control control in _controlsList)
            {
                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }
            }
        }

        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void emailTextfield_TextChanged(object sender, EventArgs e)
        {

        }

        private void cityTextfield_TextChanged(object sender, EventArgs e)
        {

        }

        private void countryTextfield_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordTextfield_TextChanged(object sender, EventArgs e)
        {

        }
    }
}