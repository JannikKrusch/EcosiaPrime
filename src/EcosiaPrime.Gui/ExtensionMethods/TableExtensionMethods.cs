using EcosiaPrime.Contracts.Models;

namespace EcosiaPrime.Gui.ExtensionMethods
{
    public static class TableExtensionMethods
    {
        /// <summary>
        /// Gibt ein ausgefülltes String Array zurück, welches als Reihe in der Tabelle verwendet wird
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
        /// Erstellt für jeden Eintag in der Liste eine Reihe in der Tabelle
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="clients"></param>
        public static void FillListView(this ListView listView, IEnumerable<Client> clients)
        {
            clients.ToList().ForEach(client => listView.Items.Add(new ListViewItem(GetFilledRow(client))));
        }
    }
}