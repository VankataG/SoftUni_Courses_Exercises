using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        public void AddMember(Person member)
        {
            this.People.Add(member);
        }

        public Person GetOldestMember()
        {
            return People.OrderByDescending(x => x.Age).FirstOrDefault();
        }

        private List<Person> people = new List<Person>();

        public List<Person> People
        {
            get { return people; }

            set { people = value; }
    }


}
}
