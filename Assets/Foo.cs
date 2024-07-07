using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PersonUtility;

public class Foo : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Foo>();

        Bar();
    }

    public void Bar()
    {
        Person laura = People.Employee("Laura", "Human Resources", 15);
        laura.AddFacet(new FMarried(1997, "Silver"));
        laura.AddFacet(new FHairAttributes("Brown", 2.5F, true));

        Person bill = People.Employee("Bill", "Human Resources", 10);
        Person steven = People.Employee("Steve", "Plumber", 20);
        Person will = People.Employee("Will", "Computer Engineer", 12);
        Person chanel = People.Employee("Chanel", "Computer Engineer", 12);
        Person amelia = People.Employee("Amelia", "Project Manager", 7);

        will.AddFacet(new FHairAttributes("Dark Brown", 0.3F, true));
        chanel.AddFacet(new FHairAttributes("Black", 0.5F, false));

        Person nameless = new Person(new FHairAttributes("Brown", 1.5F, true));

        List<Person> people = new List<Person>() { laura, bill, steven, will, chanel, amelia, nameless };

        for (int i = 0; i < people.Count; i++)
        {
            if (people[i].HasFacet<FHairAttributes>())
            {
                Debug.Log((people[i].GetFacet<FName>()?.name ?? "No Name") + $" {people[i].GetID()}");
            }
        }
    }
}