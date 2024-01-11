using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PersonUtility
{
    public interface Facet
    {
        public Facet Clone();
    }

    public class FName : Facet
    {
        public FName(string name)
        {
            this.name = name;
        }

        public string name;

        public Facet Clone()
        {
            return new FName(name);
        }
    }

    public class FMarried : Facet
    {
        public FMarried(int year, string ringMetal)
        {
            this.year = year;
            this.ringMetal = ringMetal;
        }

        public int year;
        public string ringMetal;

        public Facet Clone()
        {
            return new FMarried(year, ringMetal);
        }
    }

    public class FHairAttributes : Facet
    {
        public FHairAttributes(string color, float length, bool curly)
        {
            this.color = color;
            this.length = length;
            this.curly = curly;
        }

        public string color;
        public float length;
        public bool curly;

        public Facet Clone()
        {
            return new FHairAttributes(color, length, curly);
        }
    }

    public class FEmployed : Facet
    {
        public FEmployed(string jobTitle, int yearsExperience)
        {
            this.jobTitle = jobTitle;
            this.yearsExperience = yearsExperience;
        }

        public string jobTitle;
        public int yearsExperience;

        public Facet Clone()
        {
            return new FEmployed(jobTitle, yearsExperience);
        }
    }

    public class Person
    {
        private readonly string id;

        public string GetID()
        {
            return id;
        }

        public Person(params Facet[] facets) : this(facets.ToList()) { }

        public Person(List<Facet> facets)
        {
            this.facets = facets;
            this.id = Guid.NewGuid().ToString();
        }

        List<Facet> facets;

        public void AddFacet(Facet facet)
        {
            facets.Add(facet);
        }

        public bool HasFacet<T>() where T : Facet
        {
            return GetFacet<T>() != null;
        }

        public T GetFacet<T>() where T : Facet
        {
            foreach(var facet in facets)
            {
                if(typeof(T).IsInstanceOfType(facet))
                {
                    return (T)facet;
                }
            }

            return default;
        }

        public Person Clone()
        {
            List<Facet> facetsCopy = new List<Facet>();

            foreach(var facet in facets) 
            {
                facetsCopy.Add(facet);
            }

            Person clone = new Person(facetsCopy);

            return clone;
        }
    }

    public static class People
    {
        public static Person Employee(string name, string jobTitle, int yearsExperience)
        {
            return new Person(new FName(name), new FEmployed(jobTitle, yearsExperience));
        }
    }
}