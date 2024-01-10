class Currency
{
    public double Value { get; set; }

    public Currency(double value)
    {
        Value = value;
    }
}

class CurrencyUSD : Currency
{
    public CurrencyUSD(double value) : base(value) { }

    public static implicit operator CurrencyUSD(CurrencyRUB rub)
    {
        double rate = 0.01;
        return new CurrencyUSD(rub.Value * rate);
    }
}

class CurrencyEUR : Currency
{
    public CurrencyEUR(double value) : base(value) { }

    public static implicit operator CurrencyEUR(CurrencyUSD usd)
    {
        double rate = 0.85;
        return new CurrencyEUR(usd.Value * rate);
    }
}

class CurrencyRUB : Currency
{
    public CurrencyRUB(double value) : base(value) { }

    public static explicit operator CurrencyRUB(CurrencyUSD usd)
    {
        double rate = 100.0; 
        return new CurrencyRUB(usd.Value * rate);
    }
}



class Program
{
    static void Main()
    {
        CurrencyUSD usd = new CurrencyUSD(100.0);
        CurrencyRUB rub = new CurrencyRUB(5000.0);

        CurrencyRUB convertedRub = (CurrencyRUB)usd;
        Console.WriteLine("100 USD в RUB: " + convertedRub.Value);

        CurrencyEUR eur = usd;
        Console.WriteLine("100 USD в EUR: " + eur.Value);

        CurrencyUSD convertedUsd = rub;
        Console.WriteLine("5000 RUB в USD: " + convertedUsd.Value);

    }
}
