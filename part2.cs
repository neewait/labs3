using System;

using System.Collections.Generic;

class Car : IEquatable<Car>
{
    public string Name { get; set; }
    public string Engine { get; set; }
    public int MaxSpeed { get; set; }

    public override string ToString()
    {
        return Name;
    }

    public bool Equals(Car other)
    {
        if (other == null)
            return false;

        return Name == other.Name && Engine == other.Engine && MaxSpeed == other.MaxSpeed;
    }
}

class CarsCatalog
{
    private List<Car> cars = new List<Car>();

    public string this[int index]
    {
        get { return $"{cars[index].Name} - {cars[index].Engine}"; }
        set { cars[index] = new Car { Name = value, Engine = "", MaxSpeed = 0 }; }
    }

    public void AddCar(Car car)
    {
        cars.Add(car);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car car1 = new Car { Name = "Toyota", Engine = "V6", MaxSpeed = 200 };
        Car car2 = new Car { Name = "Honda", Engine = "V4", MaxSpeed = 180 };

        Console.WriteLine(car1); // выводит "Toyota"
        Console.WriteLine(car2); // выводит "Honda"

        Console.WriteLine(car1.Equals(car2)); // выводит "False"

        CarsCatalog catalog = new CarsCatalog();
        catalog.AddCar(car1);
        catalog.AddCar(car2);

        Console.WriteLine(catalog[0]); // выводит "Toyota - "
        Console.WriteLine(catalog[1]); // выводит "Honda - "

        catalog[0] = "Mazda";
        Console.WriteLine(catalog[0]); // выводит "Mazda - "
    }
}

