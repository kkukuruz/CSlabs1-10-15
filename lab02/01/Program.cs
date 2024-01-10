class Pupil
{
    public virtual void Study()
    {
        Console.WriteLine("Pupil is studying.");
    }

    public virtual void Read()
    {
        Console.WriteLine("Pupil is reading.");
    }

    public virtual void Write()
    {
        Console.WriteLine("Pupil is writing.");
    }

    public virtual void Relax()
    {
        Console.WriteLine("Pupil is relaxing.");
    }

}

class ExcellentPupil : Pupil
{
    public override void Study()
    {
        Console.WriteLine("Excellent pupil is studying.");
    }

    public override void Read()
    {
        Console.WriteLine("Excellent pupil is reading.");
    }

    public override void Write()
    {
        Console.WriteLine("Excellent pupil is writing.");
    }

    public override void Relax()
    {
        Console.WriteLine("Excellent pupil is relaxing.");
    }
}

class GoodPupil : Pupil
{
    public override void Study()
    {
        Console.WriteLine("Good pupil is studying.");
    }

    public override void Read()
    {
        Console.WriteLine("Good pupil is reading.");
    }

    public override void Write()
    {
        Console.WriteLine("Good pupil is writing.");
    }

    public override void Relax()
    {
        Console.WriteLine("Good pupil is relaxing.");
    }
}

class BadPupil : Pupil
{
    public override void Study()
    {
        Console.WriteLine("Bad pupil is studying.");
    }

    public override void Read()
    {
        Console.WriteLine("Bad pupil is reading.");
    }

    public override void Write()
    {
        Console.WriteLine("Bad pupil is writing.");
    }

    public override void Relax()
    {
        Console.WriteLine("Bad pupil is relaxing.");
    }
}

class ClassRoom
{
    private Pupil[] pupils;

    public ClassRoom(params Pupil[] pupils)
    {
        if (pupils.Length < 2 || pupils.Length > 4)
        {
            throw new ArgumentException("ClassRoom should have 2 to 4 pupils.");
        }

        this.pupils = pupils;
    }

    public void Study()
    {
        foreach (var pupil in pupils)
        {
            pupil.Study();
        }
    }

    public void Read()
    {
        foreach (var pupil in pupils)
        {
            pupil.Read();
        }
    }

    public void Write()
    {
        foreach (var pupil in pupils)
        {
            pupil.Write();
        }
    }

    public void Relax()
    {
        foreach (var pupil in pupils)
        {
            pupil.Relax();
        }
    }
}

class Program
{
    static void Main()
    {
        Pupil pupil1 = new ExcellentPupil();
        Pupil pupil2 = new GoodPupil();
        Pupil pupil3 = new BadPupil();
        Pupil pupil4 = new ExcellentPupil();

        ClassRoom classRoom = new ClassRoom(pupil1, pupil2, pupil3, pupil4);

        classRoom.Study();
        classRoom.Read();
        classRoom.Write();
        classRoom.Relax();
    }
}