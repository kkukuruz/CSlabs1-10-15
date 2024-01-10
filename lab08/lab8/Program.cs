﻿using System.Xml;
using System.Reflection;
using System.Xml.Serialization;

namespace AnimalClasses;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum)]
public class CommentAttribute : Attribute
{
    public string Comment { get; }

    public CommentAttribute(string comment)
    {
        Comment = comment;
    }
}

[Comment("Types of animals enumeration")]
public enum eClassificationAnimal
{
    Herbivores,
    Carnivores,
    Omnivores
}

[Comment("Favorite food enumeration")]
public enum eFavoriteFood
{
    Meat,
    Plants,
    Everything
}

[Comment("Abstract class for creating animals")]
public abstract class Animal
{
    public string? Country { get; set; }
    public bool HideFromOtherAnimals { get; set; }
    public string? Name { get; set; }
    private eClassificationAnimal Classification { get; set; }

    // constructors
    protected Animal(string country, bool hideFromOtherAnimals, string name, eClassificationAnimal classification)
    {
        this.Country = country;
        this.HideFromOtherAnimals = hideFromOtherAnimals;
        this.Name = name;
        this.Classification = classification;

    }

    protected Animal()
    {
        this.Country = "";
        this.HideFromOtherAnimals = false;
        this.Name = "";
        this.Classification = eClassificationAnimal.Omnivores;
    }

    // deconstructor
    public void Deconstruct(out string country, out bool hideFromOtherAnimals, out string name,
        out eClassificationAnimal classification)
    {
        country = Country;
        hideFromOtherAnimals = HideFromOtherAnimals;
        name = Name;
        classification = Classification;
    }

    public eClassificationAnimal GetClassificationAnimal
    {
        get { return Classification; }
        set { Classification = value; }
    }

    // abstract methods
    public abstract eFavoriteFood GetFavoriteFood();
    public abstract void SayHello();

}

[Comment("Class for cow")]
public class Cow : Animal
{
    public override eFavoriteFood GetFavoriteFood()
    {
        return eFavoriteFood.Plants;
    }

    public override void SayHello()
    {
        Console.WriteLine("MUUU");
    }
}

[Comment("Class for lion")]
public class Lion : Animal
{
    public override eFavoriteFood GetFavoriteFood()
    {
        return eFavoriteFood.Meat;
    }

    public override void SayHello()
    {
        Console.WriteLine("RAAAR");
    }
}

[Comment("Class for pig")]
public class Pig : Animal
{
    public override eFavoriteFood GetFavoriteFood()
    {
        return eFavoriteFood.Everything;
    }

    public override void SayHello()
    {
        Console.WriteLine("OOINK");
    }
}

public class Program
{
    public static void Main()
    {
        Animal cow = new Cow();
        cow.Country = "India";
        cow.HideFromOtherAnimals = false;
        cow.Name = "Burenkajhan"; 
        cow.GetClassificationAnimal = eClassificationAnimal.Herbivores;

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Cow));

        using (FileStream fs = new FileStream("/Users/maximkukuruz/Projects/lab8/ser/animal.xml", FileMode.OpenOrCreate))
        {
            xmlSerializer.Serialize(fs, cow);
            Console.WriteLine("Serialized");
        }
    }
}