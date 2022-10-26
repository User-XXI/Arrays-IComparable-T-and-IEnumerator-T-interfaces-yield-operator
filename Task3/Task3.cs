using System.Collections;
using System.Collections.Generic;
class Car
{
    public string Name { get; set; }
    public int MaxSpeed { get; set; }
    public int ProductionYear { get; set; }
    public Car( string name, int productionYear, int maxSpeed )
    {
        Name = name;
        MaxSpeed = maxSpeed;
        ProductionYear = productionYear;
    }
    public void Print()
    {
        Console.WriteLine( Name +
            " MaxSpeed: " + MaxSpeed +
            " ProductionYear: " + ProductionYear );
    }

}
class CarComparer : IComparer<Car>
{
    public int Mode = 0;
    public int Compare( Car x, Car y )
    {
        switch (Mode)
        {
            case 0: return x.Name.CompareTo( y.Name );
            case 1: return x.MaxSpeed.CompareTo( y.MaxSpeed );
            case 2: return x.ProductionYear.CompareTo( y.ProductionYear );
        }
        return 0;
    }

}

class CarCatalog : IEnumerable
{
    Car[] mas;
    public CarCatalog( params Car[] m )
    {
        mas = new Car[m.Length];
        for (int i = 0; i < m.Length; i++)
            mas[i] = m[i];
    }
    // Implementation for the GetEnumerator method.
    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }

    public CarEnum GetEnumerator()
    {
        return new CarEnum( mas );
    }

    public void Print()
    {
        foreach (var pos in mas)
            pos.Print();
    }
}

class CarEnum : IEnumerator
{
    Car[] mas;

    //  Прямой обход
    int position = -1;

    //  Обратный обход
    //int position;

    public CarEnum( Car[] inp )
    {

        this.mas = new Car[inp.Length];
        for (int i = 0; i < inp.Length; i++)
            this.mas[i] = new Car( inp[i].Name, 
                                   inp[i].MaxSpeed, 
                                   inp[i].ProductionYear );

        //  Обратный обход :
        //position = mas.Length;
        //this.position = mas.Length;

        //  Обход с  фильртом 
        CarComparer comp = new CarComparer();
        comp.Mode = 0;
        Array.Sort( mas, comp );
    }

    public bool MoveNext()
    {
        //  Прямой обход
        position++;
        return (position < mas.Length);

        //  Обратный обход
        //position--;
        //return (position > -1 && position < mas.Length);
    }

    public void Reset()
    {
        //  Прямой обход
        position = -1;

        //  Обратный обход
        //position = mas.Length;
    }

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public Car Current
    {
        get
        {
            try
            {
                return mas[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

}

class MyMain
{
    static void Main()
    {
        CarCatalog cars = new CarCatalog(
            new Car("Mercedes", 2005, 200),
            new Car("Volvo", 2000, 180),
            new Car("Audi", 2010, 190),
            new Car("BMW", 2005, 195));

        foreach (Car car in cars)
            car.Print();


    }
}
