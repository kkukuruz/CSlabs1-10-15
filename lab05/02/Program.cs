using System;

class MyList<T>
{
    private T[] items;
    private int count;

    public MyList()
    {
        items = new T[0];
        count = 0;
    }

    public void Add(T item)
    {
        Array.Resize(ref items, count + 1);
        items[count] = item;
        count++;
    }

    public T this[int index]
    {
        get { return items[index]; }
        set { items[index] = value; }
    }

    public int Count
    {
        get { return count; }
    }
}
class Programm
{
    public static void Main(string[] args)
    {
        MyList<int> myList = new MyList<int>();

        Console.WriteLine("Добавление элементов в MyList:");

        myList.Add(1);
        myList.Add(2);
        myList.Add(3);

        Console.WriteLine("Элементы MyList:");

        for (int i = 0; i < myList.Count; i++)
        {
            Console.WriteLine(myList[i]);
        }
    }
}
