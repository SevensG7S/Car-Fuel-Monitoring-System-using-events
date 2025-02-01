using System;

class Car
{
    public delegate void FuelHandlerDelegate(int fuelLevel);
    public event FuelHandlerDelegate FuelHandlerEvent;

    private int fuel;
    public int Fuel
    {
        get => fuel;
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Fuel can't be negative!");
                return;
            }
            fuel = value;
            Console.WriteLine($"Fuel's been changed: {fuel}L");

            if (fuel < 10)
            {
                FuelHandlerEvent?.Invoke(fuel);
            }
        }
    }
}

class Program
{
    public static void Main()
    {
        Car corvet = new Car();


        corvet.FuelHandlerEvent += fuel => Console.WriteLine($"Warning! Fuel is low! Current level: {fuel}L");

        while (true)
        {
            Console.WriteLine("\nFuel Tank");
            Console.WriteLine("Choose option");
            Console.WriteLine("1. Write Fuel");
            Console.WriteLine("2. Exit");
            Console.Write("Choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Type count of fuel: ");
                        if (int.TryParse(Console.ReadLine(), out int fuelInput))
                        {
                            corvet.Fuel = fuelInput;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Bye");
                        return;
                    default:
                        Console.WriteLine("Try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Write correct number");
            }
        }
    }
}