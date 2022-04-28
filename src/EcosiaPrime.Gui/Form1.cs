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
        }

        public void FillComboBoxes()
        {
            PaymentMethodConstants.PaymentMethods.ForEach(x => dropdownMenuPayment.Items.Add(x));
            dropdownMenuPayment.SelectedIndex = 0;

            SubscriptionTypeConstants.SubscriptionType.ForEach(x => dropdownMenuSubscription.Items.Add(x));
            dropdownMenuSubscription.SelectedIndex = 0;

            ComboBoxOptionConstants.OptionConstants.ForEach(x => dropdownMenuOption.Items.Add(x));
        }

        private void dropdownMenuPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = dropdownMenuPayment.Text;
        }

        private async void Enter_Click(object sender, EventArgs e)
        {
            if (dropdownMenuOption.Text == ComboBoxOptionConstants.Create)
            {
                var successful = await _guiService.CreateClientAsync(responseTextField, idTextfield, firstNameTextfield, lastNameTextfield, emailTextfield,
                    passwordTextfield, countryTextfield, stateTextfield, postcodeTextfield, cityTextfield, streetNameTextfield,
                    houseNumberTextfield, startDatePicker, endDatePicker, dropdownMenuPayment, dropdownMenuSubscription).ConfigureAwait(false);

                if (successful)
                {
                    ClearAllControls();
                }
            }
            else if (dropdownMenuOption.Text == ComboBoxOptionConstants.Update)
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
            else if (dropdownMenuOption.Text == ComboBoxOptionConstants.Delete)
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
            else if (dropdownMenuOption.Text == ComboBoxOptionConstants.Show)
            {
                await _guiService.ShowClientsAsync(dropdownMenuFilter, dataGrid, idTextfield.Text).ConfigureAwait(false);
            }
            else if (dropdownMenuOption.Text == ComboBoxOptionConstants.Search)
            {
                await _guiService.SearchFunctionAsync(
                    dataGrid, dropdownMenuFilter,
                    responseTextField, idTextfield, firstNameTextfield, lastNameTextfield, emailTextfield,
                    passwordTextfield, countryTextfield, stateTextfield, postcodeTextfield, cityTextfield, streetNameTextfield,
                    houseNumberTextfield, startDatePicker, endDatePicker, dropdownMenuPayment, dropdownMenuSubscription).ConfigureAwait(false);
            }
        }

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
                    control.Invoke(new Action(() =>
                    {
                        control.Visible = true;
                    }));
                }
                else
                {
                    control.Invoke(new Action(() =>
                    {
                        control.Visible = false;
                    }));
                }
            });
        }

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

        public void ClearAllControls()
        {
            _controlsList.ToList().ForEach(control =>
            {
                if (control is TextBox && control.Name != "responseTextField")
                {
                    control.Invoke(new Action(() =>
                    {
                        control.Text = string.Empty;
                    }));
                }
            });
        }
    }
}