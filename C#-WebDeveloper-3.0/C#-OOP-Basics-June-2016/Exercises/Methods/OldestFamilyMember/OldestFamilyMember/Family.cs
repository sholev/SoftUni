namespace OldestFamilyMember
{
    using System.Collections.Generic;

    public class Family
    {
        private List<Person> people;

        private Person oldestFamilyMember;

        public Family()
        {
            this.people = new List<Person>();
        }

        public void AddMember(Person person)
        {
            if (this.oldestFamilyMember == null || person.Age > this.oldestFamilyMember?.Age)
            {
                this.oldestFamilyMember = person;
            }

            this.people.Add(person);
        }

        public Person GetOldestMember()
        {
            return this.oldestFamilyMember;
        }
    }
}