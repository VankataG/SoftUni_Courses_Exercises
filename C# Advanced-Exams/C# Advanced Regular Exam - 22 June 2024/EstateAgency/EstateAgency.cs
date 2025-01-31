using System.Runtime.CompilerServices;
using System.Text;

namespace EstateAgency
{
    public class EstateAgency
    {
        public EstateAgency(int capacity)
        {
            this.Capacity = capacity;
            this.RealEstates = new List<RealEstate>();
        }
        public int Capacity { get; set; }
        public  List<RealEstate> RealEstates { get; set; }
        public int Count => this.RealEstates.Count;

        public void AddRealEstate(RealEstate realEstate)
        {
            if (RealEstates.Count < Capacity && !RealEstates.Exists(re => re.Address == realEstate.Address))
                this.RealEstates.Add(realEstate);
        }

        public bool RemoveRealEstate(string address)
        {
            if (this.RealEstates.Exists(re => re.Address == address))
            {
                int index = RealEstates.IndexOf(RealEstates.Find(re => re.Address == address));
                RealEstates.RemoveAt(index);
                return true;
            }

            return false;
        }

        public List<RealEstate> GetRealEstates(string postalCode)
        {
            return RealEstates.Where(re => re.PostalCode == postalCode).ToList();
        }

        public RealEstate GetCheapest()
        {
            return RealEstates.OrderBy(re => re.Price).FirstOrDefault();
        }

        public double GetLargest()
        {
            return RealEstates.OrderByDescending(re => re.Size).FirstOrDefault().Size;
        }

        public string EstateReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Real estates available:");
            foreach (RealEstate realEstate in RealEstates)
            {
                sb.AppendLine(realEstate.ToString());
            }
            return sb.ToString().Trim();
        }

    }
}
