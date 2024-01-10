using System.Xml;
using System.Reflection;

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
abstract class Animal
{
    public string? Country { get; set; }
    public bool HideFromOtherAnimals { get; set; }
    public string? Name { get; set; }
    private eClassificationAnimal Classification { get; set; }

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
    }

    public abstract eFavoriteFood GetFavoriteFood();
    public abstract void SayHello();

}

[Comment("Class for cow")]
class Cow : Animal
{
    public override eFavoriteFood GetFavoriteFood()
    {
        return eFavoriteFood.Plants;
    }

    public override void SayHello()
    {
        Console.WriteLine("муууу)");
    }
}

[Comment("Class for lion")]
class Lion : Animal
{
    public override eFavoriteFood GetFavoriteFood()
    {
        return eFavoriteFood.Meat;
    }

    public override void SayHello()
    {
        Console.WriteLine("раурррвр");
    }
}
[Comment("Class for pig")]
class Pig : Animal
{
    public override eFavoriteFood GetFavoriteFood()
    {
        return eFavoriteFood.Everything;
    }

    public override void SayHello()
    {
        Console.WriteLine("хрю-хрю");
    }
}

class Program
{
    static void Main()
    {
        XmlDocument xmlDoc = new XmlDocument();

        XmlElement rootElement = xmlDoc.CreateElement("ClassDiagram"); //sozdanie kornevogo elementa v xml doccument'e
        xmlDoc.AppendChild(rootElement);

        Assembly assembly = Assembly.GetExecutingAssembly(); //poluchenie sborki v kotoroy vipolnyaetsya programm'a
        Type[] types = assembly.GetTypes(); 

        foreach (Type type in types)
        {
            string t;
            if (type.IsClass)
            {
                t = "Class";
            }
            else
            {
                t = "Enum";
            }

            if (type.Namespace.Contains("AnimalClasses"))
            {
                XmlElement element = xmlDoc.CreateElement(t);
                rootElement.AppendChild(element);

                element.SetAttribute("name", type.Name);

                CommentAttribute comment = (CommentAttribute)type.GetCustomAttribute(typeof(CommentAttribute));

                if (comment != null)
                {
                    XmlElement commentElement = xmlDoc.CreateElement("Comment");
                    commentElement.InnerText = comment.Comment;
                    element.AppendChild(commentElement);
                }

                object[] properties = type.GetProperties();

                foreach (var prop in properties)
                {
                    XmlElement propertyElement = xmlDoc.CreateElement("Property");
                    propertyElement.InnerText = prop.ToString();
                    element.AppendChild(propertyElement);
                }

                object[] methods = type.GetMethods(BindingFlags.DeclaredOnly);

                foreach (var method in methods)
                {
                    XmlElement methodElement = xmlDoc.CreateElement("Method");
                    methodElement.InnerText = method.ToString();
                    element.AppendChild(methodElement);
                }
            }

        }

        xmlDoc.Save("/Users/maximkukuruz/Projects/lab7/lab7/ClassDiagram.xml");
    }
}