namespace Animals
{
    public class Animal
    {
        public Animal(string name, string favouriteFood)
        {
            this.name = name;
            this.favouriteFood = favouriteFood;
        }
        public string name;
        public string favouriteFood;

        public virtual string ExplainSelf()
        {
            return $"I am {name} and my favourite food is {favouriteFood}";
        }
    }
}
