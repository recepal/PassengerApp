using PassengerApp.Model;

namespace PassengerApp.BL
{
    public abstract class Ticket
    {
        protected NetworkEnum NetworkType { get; set; }
        protected CountryEnum CountryType { get; set; }
        abstract public void Network();
        abstract public void Country();

        public async Task<Passenger> Get(string id)
        {
            ApiClient apiClient = new();
            var result = await apiClient.Get<Passenger>($@"crud/passenger/{id}");

            return result;
        }

        public async Task<bool> Insert(Passenger passenger)
        {
            ApiClient apiClient = new();
            bool result = await apiClient.Post<bool>("crud/passenger", passenger);

            return result;
        }

        public async Task<bool> Update(Passenger passenger) {

            ApiClient apiClient = new();
            bool result = await apiClient.Post<bool>("crud/updatePassenger", passenger);

            return result;
        }

        public async Task<Passenger> Delete(string id)
        {
            ApiClient apiClient = new();
            var result = await apiClient.Get<Passenger>($@"crud/deletePassenger/{id}");

            return result;
        }
    }

    public class Sceniro1 : Ticket
    {
        public override void Country()
        {
            CountryType = CountryEnum.USA;
        }

        public override void Network()
        {
            NetworkType = NetworkEnum.Offline;
        }
    }

    public class Sceniro2 : Ticket
    {
        public override void Country()
        {
            CountryType = CountryEnum.UK;
        }

        public override void Network()
        {
            NetworkType = NetworkEnum.Online;
        }
    }
}