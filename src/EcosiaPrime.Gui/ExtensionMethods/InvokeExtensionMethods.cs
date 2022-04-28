using EcosiaPrime.Contracts.Models;

namespace EcosiaPrime.Gui.ExtensionMethods
{
    public static class InvokeExtensionMethods
    {
        /// <summary>
        /// Ein Thread(GUI Thread) bekommt die Aufgabe, den Text aus einer ComboBox rauszuholen, welche dann returned wird
        /// </summary>
        /// <param name="comboBox"></param>
        /// <returns></returns>
        public static string InvokeComboBox(this ComboBox comboBox)
        {
            var text = "";
            comboBox.Invoke(new Action(() =>
            {
                text = comboBox.Text;
            }));
            return text;
        }

        /// <summary>
        /// Ein Thread(GUI Thread) bekommt die Aufgabe, den Text in der dementsprechenden ComboBox mit dem des input Parameters zu ersetzen
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="input"></param>
        public static void InvokeComboBox(this ComboBox comboBox, string input)
        {
            comboBox.Invoke(new Action(() =>
            {
                comboBox.Text = input;
            }));
        }

        /// <summary>
        /// Ein Thread(GUI Thread) bekommt die Aufgabe, den Text in der dementsprechenden TextBox mit dem des input Parameters zu ersetzen
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="input"></param>
        public static void InvokeTextBox(this TextBox textBox, string input)
        {
            textBox.Invoke(new Action(() =>
            {
                textBox.Text = input;
            }));
        }

        /// <summary>
        /// Ein Thread(GUI Thread) bekommt die Aufgabe, einer Textbox ein Array vom Typ string zu übergeben
        /// </summary>
        /// <param name="response"></param>
        /// <param name="lines"></param>
        public static void InvokeResponseTextBox(this TextBox response, IEnumerable<string> lines)
        {
            response.Invoke(new Action(() =>
            {
                response.Lines = lines.ToArray();
            }));
        }

        /// <summary>
        /// Ein Thread(GUI Thread) bekommt die Aufgabe, den Text in dem dementsprechenden DateTimePicker mit dem des input Parameters zu ersetzen
        /// </summary>
        /// <param name="dateTimePicker"></param>
        /// <param name="input"></param>
        public static void InvokeDateTimePicker(this DateTimePicker dateTimePicker, string input)
        {
            dateTimePicker.Invoke(new Action(() =>
            {
                dateTimePicker.Text = input;
            }));
        }

        /// <summary>
        /// Ein Thread(GUI Thread) bekommt die Aufgabe, das Datum aus dem dementsprechenden DateTimePicker zu holen und zu returnen
        /// </summary>
        /// <param name="dateTimePicker"></param>
        /// <returns></returns>
        public static DateTime GetDateTime(this DateTimePicker dateTimePicker)
        {
            DateTime datetime = default;
            dateTimePicker.Invoke(new Action(() =>
            {
                datetime = dateTimePicker.Value.Date;
            }));

            return datetime;
        }

        /// <summary>
        /// Ein Thread(GUI Thread) bekommt die Aufgabe, einer Listview den input Parameter vom Typ string Array hinzuzufügen
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="input"></param>
        public static void InvokeListView(this ListView listView, string[] input)
        {
            var listViewItem = new ListViewItem(input);
            listView.Invoke(new Action(() =>
            {
                listView.Items.Add(listViewItem);
            }));
        }

        /// <summary>
        /// Es wird geprüft ob das Objekt oder die Id null sind, wenn nicht null -> werden alle werte in den Feldern als string in ein Array gepackt und das Array dann returned
        /// wenn null -> neuer string Array wird erstellt und returned
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private static string[] GetFilledRow(this Client client)
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

        /// <summary>
        /// Es wird für jedes Element im IEnumerable die InvokelistView Methode ausgeführt, was dann die ListView mit den Attributen der Client-Objekte ausfüllt
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="clients"></param>
        public static void FillListView(this ListView listView, IEnumerable<Client> clients)
        {
            clients.ToList().ForEach(client => InvokeListView(listView, GetFilledRow(client)));
        }

        /// <summary>
        /// Der client Parameterwert wird wieder als Parameterwert benutzt für die GetFilledRow Methode, die dann in einer ListView eine Reihe ausfüllt mit den Attributen des Objekts
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="client"></param>
        public static void FillListView(this ListView listView, Client client)
        {
            listView.InvokeListView(GetFilledRow(client));
        }
    }
}