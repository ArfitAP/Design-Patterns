using Iterator;

Console.Title = "Iterator";

PeopleCollection people = new PeopleCollection();

people.Add(new Person("Kevin", "Belgium"));
people.Add(new Person("Gill", "Belgium"));
people.Add(new Person("Roland", "Netherlands"));
people.Add(new Person("Thomas", "Germany"));

var iterator = people.CreateIterator();

for(Person person = iterator.First(); !iterator.IsDone; person = iterator.Next())
{
    Console.WriteLine(person.Name);
}

Console.ReadLine();
