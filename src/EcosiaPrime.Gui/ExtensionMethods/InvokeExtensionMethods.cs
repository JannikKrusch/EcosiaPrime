using EcosiaPrime.Contracts.Models;

namespace EcosiaPrime.Gui.ExtensionMethods
{
    public static class InvokeExtensionMethods
    {
        public static string InvokeComboBox(this ComboBox comboBox)
        {
            var text = "";
            comboBox.Invoke(new Action(() =>
            {
                text = comboBox.Text;
            }));
            return text;
        }

        public static void InvokeComboBox(this ComboBox comboBox, string input)
        {
            comboBox.Invoke(new Action(() =>
            {
                comboBox.Text = input;
            }));
        }

        public static void InvokeTextBox(this TextBox textBox, string input)
        {
            textBox.Invoke(new Action(() =>
            {
                textBox.Text = input;
            }));
        }

        public static void InvokeResponseTextBox(this TextBox response, IEnumerable<string> lines)
        {
            response.Invoke(new Action(() =>
            {
                var x = lines.ToArray();
                response.Lines = x;
            }));
        }

        public static void InvokeDateTimePicker(this DateTimePicker dateTimePicker, string input)
        {
            dateTimePicker.Invoke(new Action(() =>
            {
                dateTimePicker.Text = input;
            }));
        }

        public static void InvokeListView(this ListView listView, string[] input)
        {
            var listViewItem = new ListViewItem(input);
            listView.Invoke(new Action(() =>
            {
                listView.Items.Add(listViewItem);
            }));
        }

        public static string[] GetFilledRow(this Client client)
        {
            if (client != null && client.Id != null)
            {
                string[] row = {
                client.Id, client.FirstName, client.LastName, client.Email, client.Password,
                client.Address.Country, client.Address.State, client.Address.PostCode, client.Address.City, client.Address.Street, client.Address.HouseNumber,
                client.Subscription.StartDate, client.Subscription.EndDate, client.Subscription.PaymentMethod, client.Subscription.SubscriptionType
                };
                return row;
            }
            return new string[] { };
        }

        public static void FillListView(this ListView listView, IEnumerable<Client> clients)
        {
            clients.ToList().ForEach(client => InvokeListView(listView, GetFilledRow(client)));
        }

        public static void FillListView(this ListView listView, Client client)
        {
            InvokeListView(listView, GetFilledRow(client));
        }
    }
}