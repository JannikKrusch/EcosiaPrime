using EcosiaPrime.Contracts.Models;

namespace EcosiaPrime.Gui.ExtensionMethods
{
    public static class TableExtensionMethods
    {
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

        public static void FillListView(this ListView listView, IEnumerable<Client> clients)
        {
            clients.ToList().ForEach(client => listView.Items.Add(new ListViewItem(GetFilledRow(client))));
        }
    }
}