using EcosiaPrime.Contracts.Constants;

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
            /*dataGrid.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            dataGrid.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            filterComboBox.Visible = false;*/
        }

        public void FillComboBoxes()
        {
            PaymentMethodConstants.PaymentMethods.ForEach(x => dropdownMenuPayment.Items.Add(x));
            dropdownMenuPayment.SelectedIndex = 0;

            SubscriptionTypeConstants.SubscriptionType.ForEach(x => dropdownMenuSubscription.Items.Add(x));
            dropdownMenuSubscription.SelectedIndex = 0;

            //FilterOptionsConstants.FilterOptions.ForEach(x => dropdownMenuFilter.Items.Add(x));

            ComboBoxOptionConstants.OptionConstants.ForEach(x => dropdownMenuOption.Items.Add(x));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void dropdownMenuPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = dropdownMenuPayment.Text;
        }

        private async void Enter_Click(object sender, EventArgs e)
        {
            FilterOptionsConstants.FilterOptions.ForEach(x => dropdownMenuFilter.Items.Add(x));
            if (dropdownMenuOption.Text == ComboBoxOptionConstants.Erstellen)
            {
                var successful = await _guiService.CreateClientAsync(responseTextField, idTextfield, firstNameTextfield, lastNameTextfield, emailTextfield,
                    passwordTextfield, countryTextfield, stateTextfield, postcodeTextfield, cityTextfield, streetNameTextfield,
                    houseNumberTextfield, startDatePicker, endDatePicker, dropdownMenuPayment, dropdownMenuSubscription).ConfigureAwait(false);

                if (successful)
                {
                    ClearAllControls();
                }
            }
            else if (dropdownMenuOption.Text == ComboBoxOptionConstants.Bearbeiten)
            {
                var successful = await _guiService.UpdateClientAsync(
                    responseTextField, idTextfield, firstNameTextfield, lastNameTextfield, emailTextfield,
                    passwordTextfield, countryTextfield, stateTextfield, postcodeTextfield, cityTextfield, streetNameTextfield,
                    houseNumberTextfield, startDatePicker, endDatePicker, dropdownMenuPayment, dropdownMenuSubscription).ConfigureAwait(false);

                if (successful)
                {
                    ClearAllControls();
                }
            }
            else if (dropdownMenuOption.Text == ComboBoxOptionConstants.Löschen)
            {
                var successful = await _guiService.DeleteClientAsync(
                    responseTextField, idTextfield, firstNameTextfield, lastNameTextfield, emailTextfield,
                    passwordTextfield, countryTextfield, stateTextfield, postcodeTextfield, cityTextfield, streetNameTextfield,
                    houseNumberTextfield, startDatePicker, endDatePicker, dropdownMenuPayment, dropdownMenuSubscription).ConfigureAwait(false);

                if (successful)
                {
                    ClearAllControls();
                }
            }
            else if (dropdownMenuOption.Text == ComboBoxOptionConstants.Anzeigen)
            {
                await _guiService.ShowClientsAsync(dropdownMenuFilter, dataGrid, idTextfield.Text).ConfigureAwait(false);
            }
            else if (dropdownMenuOption.Text == ComboBoxOptionConstants.Suchen)
            {
                SearchFunctionConstants.SearchFunctions.ForEach(x => dropdownMenuFilter.Items.Add(x)); 
                await _guiService.SearchFunction(
                    dataGrid, dropdownMenuFilter,
                    responseTextField, idTextfield, firstNameTextfield, lastNameTextfield, emailTextfield,
                    passwordTextfield, countryTextfield, stateTextfield, postcodeTextfield, cityTextfield, streetNameTextfield,
                    houseNumberTextfield, startDatePicker, endDatePicker, dropdownMenuPayment, dropdownMenuSubscription).ConfigureAwait(false);
            }
        }

        private void firstNameTextfield_TextChanged(object sender, EventArgs e)
        {
        }

        private void optionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (dropdownMenuOption.Text)
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

                case ComboBoxOptionConstants.Suchen:
                    ChangeVisibilityOfFields(ComboBoxOptionConstants.Suchen);
                    break;

                default:
                    ChangeVisibilityOfFields(ComboBoxOptionConstants.Clear);
                    break;
            }
        }

        public void ChangeVisibilityOfFields(string option)
        {
            if (_controlsList == null)
            {
                return;
            }

            if (_controlsList.Count() > 0)
            {
                if(option == ComboBoxOptionConstants.Anzeigen)
                {
                    dropdownMenuFilter.Items.Clear();
                    FilterOptionsConstants.FilterOptions.ForEach(x => dropdownMenuFilter.Items.Add(x));
                }
                else if(option == ComboBoxOptionConstants.Suchen)
                {
                    dropdownMenuFilter.Items.Clear();
                    SearchFunctionConstants.SearchFunctions.ForEach(x => dropdownMenuFilter.Items.Add(x));
                }
                
                //dropdownMenuFilter.SelectedIndex = 0;
            }

            foreach (Control control in _controlsList)
            {
                foreach (string opt in GetVisibleFieldsList(option))
                {
                    if (control.Name == opt)
                    {
                        control.Invoke(new Action(() =>
                        {
                            control.Visible = true;
                        }));
                        break;
                    }
                    else
                    {
                        control.Invoke(new Action(() =>
                        {
                            control.Visible = false;
                        }));
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

                case ComboBoxOptionConstants.Suchen:
                    return VisibleTextFieldListConstants.Suchen;
                default:
                    return VisibleTextFieldListConstants.Erstellen;
            }
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
                if (control is TextBox && control.Name != "responseTextField")
                {
                    control.Invoke(new Action(() =>
                    {
                        control.Text = string.Empty;
                    }));
                }
            }
        }

        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private async void emailTextfield_TextChanged(object sender, EventArgs e)
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

        private void startDateTextfield_TextChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void houseNumberTextfield_TextChanged(object sender, EventArgs e)
        {

        }
    }
}