class DocumentWorker
{
    public virtual void OpenDocument()
    {
        Console.WriteLine("Document opened");
    }

    public virtual void EditDocument()
    {
        Console.WriteLine("Editing document is available in Pro version");
    }

    public virtual void SaveDocument()
    {
        Console.WriteLine("Saving document is available in Pro version");
    }
}

class ProDocumentWorker : DocumentWorker
{
    public override void EditDocument()
    {
        Console.WriteLine("Document edited");
    }

    public override void SaveDocument()
    {
        Console.WriteLine("Document saved in the old format, saving in other formats available in Expert version");
    }
}

class ExpertDocumentWorker : ProDocumentWorker
{
    public override void SaveDocument()
    {
        Console.WriteLine("Document saved in new format");
    }
}

class Programm
{
    static void Main()
    {
        Console.WriteLine("Enter the access key:");
        string key = Console.ReadLine();

        DocumentWorker documentWorker;

        if (key == "pro")
            documentWorker = new ProDocumentWorker();
        else if (key == "exp")
            documentWorker = new ExpertDocumentWorker();
        else
            documentWorker = new DocumentWorker();

        documentWorker.OpenDocument();
        documentWorker.EditDocument();
        documentWorker.SaveDocument();
    }
}