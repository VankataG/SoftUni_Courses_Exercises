namespace _03._Heroes_of_Code_and_Logic_VII
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            Dictionary<string, Hero> heroes = new();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] heroData = Console.ReadLine().Split();
                int hp = int.Parse(heroData[1]);
                int mp = int.Parse(heroData[2]);
                if (hp > 100) hp = 100;
                if (mp > 200) mp = 200;
                Hero hero = new Hero(heroData[0], hp, mp);
                heroes.Add(heroData[0], hero);
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input.Split(" - ");
                string heroName = commands[1];
                switch (commands[0])
                {
                    case "CastSpell":
                        int manaNeeded = int.Parse(commands[2]);
                        string spellName = commands[3];
                        heroes[heroName].CastSpell(manaNeeded, spellName);
                        break;
                    case "TakeDamage":
                        int dmg = int.Parse(commands[2]);
                        string attacker = commands[3];
                        heroes[heroName].TakeDamage(dmg, attacker, heroes);
                        break;
                    case "Recharge":
                        int manaAmount = int.Parse(commands[2]);
                        heroes[heroName].Recharge(manaAmount);
                        break;
                    case "Heal":
                        int hitAmount = int.Parse(commands[2]);
                        heroes[heroName].Heal(hitAmount);
                        break;
                }
            }

            foreach (Hero hero in heroes.Values)
            {
                Console.WriteLine($"{hero.Name}\n  HP: {hero.HP}\n  MP: {hero.MP}");
            }
        }
    }

    public class Hero
    {
        public Hero(string name, int hP, int mP)
        {
            Name = name;
            HP = hP;
            MP = mP;
        }

        public void CastSpell(int manaNeeded, string spellName)
        {
            if (MP >= manaNeeded)
            {
                MP -= manaNeeded;
                Console.WriteLine($"{Name} has successfully cast {spellName} and now has {MP} MP!");
            }
            else
            {
                Console.WriteLine($"{Name} does not have enough MP to cast {spellName}!");
            }
        }

        public void TakeDamage(int dmg, string attacker, Dictionary<string, Hero> heroes)
        {
            HP -= dmg;
            if (HP > 0)
            {
                Console.WriteLine($"{Name} was hit for {dmg} HP by {attacker} and now has {HP} HP left!");
            }
            else
            {
                Console.WriteLine($"{Name} has been killed by {attacker}!");
                heroes.Remove(Name);
            }
        }

        public void Recharge(int manaAmount)
        {
            if (MP + manaAmount > 200)
            {
                manaAmount = 200 - MP;
            }

            MP += manaAmount;
            Console.WriteLine($"{Name} recharged for {manaAmount} MP!");
        }

        public void Heal(int hitAmount)
        {
            if (HP + hitAmount > 100)
            {
                hitAmount = 100 - HP;
            }

            HP += hitAmount;
            Console.WriteLine($"{Name} healed for {hitAmount} HP!");
        }
        public string Name;
        public int HP;
        public int MP;
    }
}
