using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"@[#]+(?<BarCode>[A-Z][A-Za-z0-9]{4,}[A-Z])@[#]+";
            string digitPattern = @"[0-9]";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string barCode = default;
                if (Regex.IsMatch(input, pattern))
                {
                    string pGroup = default;
                    if (Regex.IsMatch(input, digitPattern))
                    {
                        foreach (Match digit in Regex.Matches(input, digitPattern))
                        {
                            pGroup += digit.Value;
                        }
                    }
                    else
                    {
                        pGroup = "00";
                    }

                    Console.WriteLine($"Product group: {pGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
