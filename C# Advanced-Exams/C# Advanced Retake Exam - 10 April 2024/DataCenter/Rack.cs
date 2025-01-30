using System.Text;

namespace DataCenter
{
    public class Rack
    {
        public Rack(int slots)
        {
            this.Slots = slots;
            this.Servers = new List<Server>();
        }
        public int Slots { get; set; }
        public List<Server> Servers { get; set; }
        public int GetCount => Servers.Count;

        public void AddServer(Server server)
        {
            if (Servers.Count == Slots)
                return;
            if (Servers.Exists(s => s.SerialNumber == server.SerialNumber))
                return;

            Servers.Add(server);
        }

        public bool RemoveServer(string serialNumber)
        {
            Server server = Servers.Find(s => s.SerialNumber == serialNumber);
            if (server == null) return false;

            Servers.Remove(server);
            return true;
        }

        public string GetHighestPowerUsage()
        {
            return Servers.OrderByDescending(s => s.PowerUsage)
                .FirstOrDefault().ToString();
        }

        public int GetTotalCapacity()
        {
            return Servers.Sum(s => s.Capacity);
        }

        public string DeviceManager()
        {
            return $"{Servers.Count} servers operating:" +
                   Environment.NewLine +
                   String.Join(Environment.NewLine, Servers);
        }
    }
}
