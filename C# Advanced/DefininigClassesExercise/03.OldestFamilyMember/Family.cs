using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> members;

        public Family()
        {
            members = new List<Person>();
        }

        public void AddMember(Person member)
        {
            members.Add(member);
        }

        public Person GetOldestMember()
        {
            if (members.Count > 0)
            {
                Person oldestPerson = members[0];

                for (int i = 1; i < members.Count; i++)
                {
                    if (members[i].Age > oldestPerson.Age)
                    {
                        oldestPerson = members[i];
                    }
                }

                return oldestPerson;
            }
            else
            {
                return null;
            }
        }
    }
}
