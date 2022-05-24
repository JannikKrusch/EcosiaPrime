using EcosiaPrime.Contracts.Constants;
using EcosiaPrime.Gui.ExtensionMethods;

namespace EcosiaPrime.Gui
{
    public partial class Form1 : Form
    {
        private readonly IGuiService _guiService;
        private IEnumerable<Control> _controlsList;

        public Form1(IGuiService guiService)
        {
            _controlsList = Controls.OfType<Control>().Where(x => x is TextBox || x is ComboBox && x.Name != "optionComboBox" || x is DateTimePicker);
            _guiService = guiService;

            InitializeComponent();
            FillComboBoxes();
        }

        /// <summary>
        /// Füllt die Comboboxen und setzt direkt den Index
        /// </summary>
        public void FillComboBoxes()
        {
            PaymentMethodConstants.PaymentMethods.ForEach(x => dropdownMenuPayment.Items.Add(x));
            dropdownMenuPayment.SelectedIndex = 0;

            SubscriptionTypeConstants.SubscriptionType.ForEach(x => dropdownMenuSubscription.Items.Add(x));
            dropdownMenuSubscription.SelectedIndex = 0;

            ComboBoxOptionConstants.OptionConstants.ForEach(x => dropdownMenuOption.Items.Add(x));
            dropdownMenuOption.SelectedIndex = 0;
        }

        private void dropdownMenuPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = dropdownMenuPayment.Text;
        }


        /// <summary>
        /// Bearbeitet den Knopfdruck
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Enter_Click(object sender, EventArgs e)
        {
            if (dropdownMenuOption.Text == ComboBoxOptionConstants.Create)
            {
                var fields = await _guiService.CreateClientAsync(
                    idTextfield.Text, firstNameTextfield.Text, lastNameTextfield.Text, emailTextfield.Text,
                    passwordTextfield.Text, countryTextfield.Text, stateTextfield.Text, postcodeTextfield.Text, cityTextfield.Text, streetNameTextfield.Text,
                    houseNumberTextfield.Text, startDatePicker.Text, endDatePicker.Text, dropdownMenuPayment.Text, dropdownMenuSubscription.Text);

                responseTextField.Lines = fields.ToArray();
                if(fields.ToArray()[0] == ResponseMessagesConstants.AddClientToDBSuccessful)
                {
                    ClearAllControls();
                }
            }
            else if (dropdownMenuOption.Text == ComboBoxOptionConstants.Update)
            {
                var fields = await _guiService.UpdateClientAsync(
                    idTextfield.Text, firstNameTextfield.Text, lastNameTextfield.Text, emailTextfield.Text,
                    passwordTextfield.Text, countryTextfield.Text, stateTextfield.Text, postcodeTextfield.Text, cityTextfield.Text, streetNameTextfield.Text,
                    houseNumberTextfield.Text, startDatePicker.Text, endDatePicker.Text, dropdownMenuPayment.Text, dropdownMenuSubscription.Text);

                var fieldList = fields.ToList();

                if (fields.Count() == 1)
                {
                    responseTextField.Lines = fields.ToArray();
                    if (fields.ToArray()[0] == ResponseMessagesConstants.UpdateClientToDBSuccessful)
                    {
                        ClearAllControls();
                    }
                }
                else if (fields.Count() == 15)
                {
                    idTextfield.Text = fieldList[0];
                    firstNameTextfield.Text = fieldList[1];
                    lastNameTextfield.Text = fieldList[2];
                    emailTextfield.Text = fieldList[3];
                    passwordTextfield.Text = fieldList[4];
                    countryTextfield.Text = fieldList[5];
                    stateTextfield.Text = fieldList[6];
                    postcodeTextfield.Text = fieldList[7];
                    cityTextfield.Text = fieldList[8];
                    streetNameTextfield.Text = fieldList[9];
                    houseNumberTextfield.Text = fieldList[10];
                    startDatePicker.Text = fieldList[11];
                    endDatePicker.Text = fieldList[12];
                    dropdownMenuPayment.Text = fieldList[13];
                    dropdownMenuSubscription.Text = fieldList[14];
                }
                else
                {
                    responseTextField.Lines = fields.ToArray();
                }
            }
            else if (dropdownMenuOption.Text == ComboBoxOptionConstants.Delete)
            {
                var fields = await _guiService.DeleteClientAsync(idTextfield.Text);

                responseTextField.Lines = fields.ToArray();
                if (fields.ToArray()[0] == ResponseMessagesConstants.DeleteClientToDBSuccessful)
                {
                    ClearAllControls();
                }
            }
            else if (dropdownMenuOption.Text == ComboBoxOptionConstants.Show)
            {
                var clients = await _guiService.ShowClientsAsync(dropdownMenuFilter.Text, idTextfield.Text);

                dataGrid.Items.Clear();
                dataGrid.FillListView(clients);
            }
            else if (dropdownMenuOption.Text == ComboBoxOptionConstants.Search)
            {
                var clients = await _guiService.SearchFunctionAsync(
                    dropdownMenuFilter.Text,
                    idTextfield.Text, firstNameTextfield.Text, lastNameTextfield.Text, emailTextfield.Text,
                     passwordTextfield.Text, countryTextfield.Text, stateTextfield.Text, postcodeTextfield.Text, cityTextfield.Text, streetNameTextfield.Text,
                     houseNumberTextfield.Text, startDatePicker.Text, endDatePicker.Text, dropdownMenuPayment.Text, dropdownMenuSubscription.Text);

                dataGrid.Items.Clear();
                dataGrid.FillListView(clients);
            }
        }

        /// <summary>
        /// Setzt die Sichtbarkeit der Elemente je nach dem, was im Hauptmenü ausgewählt worden ist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void optionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (dropdownMenuOption.Text)
            {
                case ComboBoxOptionConstants.Create:
                    ChangeVisibilityOfFields(ComboBoxOptionConstants.Create);
                    break;

                case ComboBoxOptionConstants.Update:
                    ChangeVisibilityOfFields(ComboBoxOptionConstants.Update);
                    break;

                case ComboBoxOptionConstants.Delete:
                    ChangeVisibilityOfFields(ComboBoxOptionConstants.Delete);
                    break;

                case ComboBoxOptionConstants.Show:
                    ChangeVisibilityOfFields(ComboBoxOptionConstants.Show);
                    break;

                case ComboBoxOptionConstants.Search:
                    ChangeVisibilityOfFields(ComboBoxOptionConstants.Search);
                    break;

                default:
                    ChangeVisibilityOfFields(ComboBoxOptionConstants.Create);
                    break;
            }
        }
        /// <summary>
        /// Setzt die Visible Eigenschaft der GUI-Elemente
        /// </summary>
        /// <param name="option"></param>
        public void ChangeVisibilityOfFields(string option)
        {
            if (_controlsList == null)
            {
                return;
            }

            if (_controlsList.Any())
            {
                if (option == ComboBoxOptionConstants.Show)
                {
                    dropdownMenuFilter.Items.Clear();
                    FilterOptionsConstants.FilterOptions.ForEach(x => dropdownMenuFilter.Items.Add(x));
                    dropdownMenuFilter.SelectedIndex = 0;
                }
                else if (option == ComboBoxOptionConstants.Search)
                {
                    dropdownMenuFilter.Items.Clear();
                    SearchFunctionConstants.SearchFunctions.ForEach(x => dropdownMenuFilter.Items.Add(x));
                    dropdownMenuFilter.SelectedIndex = 0;
                }
            }

            _controlsList.ToList().ForEach(control =>
            {
                if (GetVisibleFieldsList(option).Any(x => x == control.Name))
                {
                    control.Visible = true;
                }
                else
                {
                    control.Visible = false;
                }
            });
        }


        /// <summary>
        /// Gibt Liste mit Namen der Elemente zurück, die sichtbar sein dürfen
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        public List<string> GetVisibleFieldsList(string option)
        {
            switch (option)
            {
                case ComboBoxOptionConstants.Create:
                    return VisibleTextFieldListConstants.Create;

                case ComboBoxOptionConstants.Update:
                    return VisibleTextFieldListConstants.Update;

                case ComboBoxOptionConstants.Delete:
                    return VisibleTextFieldListConstants.Delete;

                case ComboBoxOptionConstants.Show:
                    return VisibleTextFieldListConstants.Show;

                case ComboBoxOptionConstants.Search:
                    return VisibleTextFieldListConstants.Search;

                default:
                    return VisibleTextFieldListConstants.Create;
            }
        }

        public void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGrid.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            dataGrid.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        /// <summary>
        /// Leert jede Textbox bis auf die, die für die Nachrichten zuständig ist
        /// </summary>
        public void ClearAllControls()
        {
            _controlsList.ToList().ForEach(control =>
            {
                if (control is TextBox && control.Name != "responseTextField")
                {
                    control.Text = string.Empty;
                }
            });
        }
    }
}