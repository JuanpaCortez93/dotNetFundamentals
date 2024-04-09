
//var sales = new();
//INSTANCIAR
//var sales = new Sales(15);

//Console.WriteLine(sales.Total);

//var message = sales.GetInfo();
//Console.WriteLine(message);

SaleWTaxes cerveza = new SaleWTaxes(10m, 13m);
Console.WriteLine(cerveza.GetInfo());

interface ISales
{
    string GetInfo();
}

interface ISave
{
    public void Save();
}


class Sales : ISales, ISave
{
    public Sales (decimal total)
    {
        _total = total;
    }

    public virtual string GetInfo()
    {
        return $"Total is {_total}USD";
    }

    public virtual void Save()
    {
        Console.WriteLine("Se grabó en base de datos");
    }

    public decimal Total { get {return _total;} set {_total = value;} }
    private decimal _total;

}


class SaleWTaxes : Sales, ISales, ISave
{
    public SaleWTaxes(decimal total, decimal tax) : base(total)
    {
        _tax = tax;
        _total = total * (1 + (_tax / 100));
    }

    public override string GetInfo()
    {
        return $"Total: {_total}USD";
    }

    public override void Save()
    {
        Console.WriteLine("Se grabó en base de datos con impuestos");
    }

    public decimal Tax { get { return _tax; } set { _tax = value; } }
    private decimal _tax;
    private decimal _total;
}