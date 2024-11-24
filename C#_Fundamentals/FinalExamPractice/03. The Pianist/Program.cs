using System.Security.Cryptography.X509Certificates;

namespace _03._The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Piece> pieces = new();
            int numberPieces = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberPieces; i++)
            {
                string[] pieceInfo = Console.ReadLine().Split('|');
                string name = pieceInfo[0];
                string composer = pieceInfo[1];
                string key = pieceInfo[2];
                pieces.Add(new Piece(name, composer, key));
            }

            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] commands = input.Split('|');
                string piece = default;
                switch (commands[0])
                {

                    case "Add":
                        piece = commands[1];
                        string composer = commands[2];
                        string key = commands[3];
                        Piece newPiece = new Piece(piece, composer, key);
                        if (!pieces.Any(p => p.Name == piece))
                        {
                            pieces.Add(newPiece);
                            Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                        }
                        else
                        {
                            Console.WriteLine($"{piece} is already in the collection!");
                        }
                        break;
                    case "Remove":
                        piece = commands[1];
                        if (pieces.Any(p => p.Name == piece))
                        {
                            Piece pieceToRemove = pieces.Find(p => p.Name == piece);
                            pieces.Remove(pieceToRemove);
                            Console.WriteLine($"Successfully removed {piece}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }
                        break;
                    case "ChangeKey":
                        piece = commands[1];
                        string newKey = commands[2];
                        if (pieces.Any(p => p.Name == piece))
                        {
                            Piece pieceToChange = pieces.Find(p => p.Name == piece);
                            pieceToChange.Key = newKey;
                            Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }
                        break;
                }
            }

            foreach (Piece piece in pieces)
            {
                Console.WriteLine($"{piece.Name} -> Composer: {piece.Composer}, Key: {piece.Key}");
            }
        }
    }

    public class Piece
    {
        public Piece(string name, string composer, string key)
        {
            Name = name;
            Composer = composer;
            Key = key;
        }
        public string Name;
        public string Composer;
        public string Key;

    }
}
