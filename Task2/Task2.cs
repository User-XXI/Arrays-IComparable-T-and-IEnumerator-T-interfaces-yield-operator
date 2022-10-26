using System.Collections;
using System.Collections.Generic;
class Car
{
    public string Name { get; set; }
    public int ProductionYear { get; set; }
    public int MaxSpeed { get; set; }
    public Car( string name, int productionYear, int maxSpeed )
    {
        Name = name;
        ProductionYear = productionYear;
        MaxSpeed = maxSpeed;
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
    static void Main()
    {
        Car[] mas ={
           new Car("Mercedes", 2005, 200),
           new Car("Volvo", 2000, 180),
           new Car("Audi", 2010, 190),
           new Car("BMW", 2015, 195),
           new Car("Honda", 2008, 175)};

        Console.WriteLine( "Исходный массив" );
        CarComparer carCom = new CarComparer();
        foreach (var pos in mas)
            pos.Print();

        carCom.Mode = 0;
        Console.WriteLine( "\nСортировка по имени" );
        Array.Sort( mas, carCom );
        foreach (var pos in mas)
            pos.Print();

        carCom.Mode = 1;
        Console.WriteLine( "\nСортировка по скорости" );
        Array.Sort( mas, carCom );
        foreach (var pos in mas)
            pos.Print();

        carCom.Mode = 2;
        Console.WriteLine( "\nСортировка по году выпуска" );
        Array.Sort( mas, carCom );
        foreach (var pos in mas)
            pos.Print();
    }
}
