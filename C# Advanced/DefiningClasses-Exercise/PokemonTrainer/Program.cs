namespace PokemonTrainer
{
     class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = info[0];
                string name = info[1];
                string element = info[2];
                int health = int.Parse(info[3]);
                Pokemon pokemon = new Pokemon(name, element, health);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName));
                }

                trainers[trainerName].Pokemons.Add(pokemon);
            }


            var copyList = new Dictionary<string, Trainer>(trainers);
            while ((input = Console.ReadLine()) != "End")
            {
                switch (input)
                {
                    case "Fire":
                    case "Water":
                    case "Electricity":
                        foreach (var trainer in trainers.Values)
                        {
                            bool receivedBadge = false;

                            foreach (Pokemon pokemon in trainer.Pokemons)
                            {
                                if (pokemon.Element == input)
                                {
                                    receivedBadge = true;
                                    trainer.Badges++;
                                    break;
                                }
                            }

                            if (!receivedBadge)
                            {
                                foreach (Pokemon pokemon in trainer.Pokemons)
                                {
                                    pokemon.Health -= 10;

                                }
                            }

                            trainer.Pokemons.RemoveAll(x => x.Health <= 0);
                        }
                        break;
                }
            }

            foreach (var trainer in trainers.Values.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
