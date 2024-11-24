using System.Text;
using System.Text.RegularExpressions;
namespace Race
{
    public class Participant
    {

        public string Name { get; set; }
        public int Distance { get; set; }
        public Participant(string name)
        {
            Name = name;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string words = @"[A-Za-z]";
            string digits = @"\d";
            List<Participant> participants = new List<Participant>();
            string[] participantName = Console.ReadLine().Split(", ");
            string command;
            for (int i = 0; i < participantName.Length; i++)
            {
                participants.Add(new Participant(participantName[i]));
            }

            while ((command = Console.ReadLine()) != "end of race")
            {
                StringBuilder st = new StringBuilder();
                foreach (Match m in Regex.Matches(command, words))
                {
                    st.Append(m.Value);
                }
                var foundParticipant = participants.FirstOrDefault(participants => participants.Name == st.ToString());
                if (foundParticipant != null)
                {
                    int distance = 0;
                    foreach (Match match in Regex.Matches(command, digits))
                    {
                        distance = int.Parse(match.Value);
                    }
                    foundParticipant.Distance += distance;
                }
            }
            var winners = participants.OrderByDescending(p => p.Distance)
                .ToList();
            Console.WriteLine($"1st place: {winners[0].Name}");
            Console.WriteLine($"2nd place: {winners[1].Name}");
            Console.WriteLine($"3rd place: {winners[2].Name}");

        }
    }
}