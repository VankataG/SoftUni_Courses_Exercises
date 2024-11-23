namespace _07._Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyEmployees = new();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] datas = input.Split(" -> ");
                string company = datas[0];
                string id = datas[1];

                if (!companyEmployees.ContainsKey(company))
                {
                    companyEmployees[company] = new List<string>();
                }
                
                if (!companyEmployees[company].Contains(id))
                {
                    companyEmployees[company].Add(id);
                }
            }
            foreach ((string comp , List<string> companyIDs) in companyEmployees)
            {
                Console.WriteLine(comp);
                foreach (string id in companyIDs)
                {
                    Console.WriteLine("-- " + id);
                }
            }
        }
    }
}
