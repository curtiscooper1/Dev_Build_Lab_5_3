using System;
using System.Collections.Generic;

namespace Lab_5_3
{
    class Car 
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }

        public int Id { get; set; }

        public Car()
        {
        }

        public Car(string carmake, string carmodel, int caryear, double carprice, int carid)
        {
            Make = carmake;
            Model = carmodel;
            Year = caryear;
            Price = carprice;
            Id = carid;
        }

        public virtual string ToString() //prints new car details
        {
            return Year.ToString() + " " + Model.ToString() + " " + Make.ToString() + " for $" + Price.ToString() + " Car ID: " + Id.ToString();
        }
    }

    class UsedCar : Car
    {
        public double Mileage { get; set; }

        public UsedCar()
        {

        }

        public UsedCar(string carmake, string carmodel, int caryear, double carprice, int carid, double carmileage)
            : base(carmake, carmodel, caryear, carprice, carid)
        {
            Mileage = carmileage;
        }

        public override string ToString() //prints used car details
        {
            return Year.ToString() + " " + Make.ToString() + " " + Model.ToString() + " (Used) with " + Mileage.ToString() + " miles for $" + Price.ToString() + " Car ID: " + Id.ToString();
        }
    }

    class Carlot
    {
        public void PrintList(List<Car> carinventory) // prints full inventory list
        {
            foreach (Car auto in carinventory)
            {
                Console.WriteLine(auto.ToString());
            }

        }

        public void RemoveCar(List<Car> carinventory) //removes car from inventory
        {
            Console.Write("Enter the Car Id number to remove from inventory: ");
            int num = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < carinventory.Count; i++)
            {
                if (carinventory[i].Id == num)
                {

                    carinventory.RemoveAt(i);

                }
            }

        }

        public void AddCar(List<Car> carinventory) 
        {
            Console.Write("Would you like to add a new or used car to the invetory? new- enter N / used - enter U: ");
            string addauto = Console.ReadLine().ToLower();

            if (addauto == "n")
            {
                Car newCar = new Car();
                Console.Write("Enter the Make of the car: ");
                newCar.Make = Console.ReadLine();
                Console.Write("Enter the Model of the car: ");
                newCar.Model = Console.ReadLine();
                Console.Write("Enter the Year of the car: ");
                newCar.Year = Int32.Parse(Console.ReadLine());
                Console.Write("Enter the List Price of the car: ");
                newCar.Price = Double.Parse(Console.ReadLine());
                Console.Write("Enter the ID number of the car: ");
                newCar.Id = Int32.Parse(Console.ReadLine());
                carinventory.Add(newCar);
                Console.WriteLine(newCar.ToString());
            }
            else
            {
                UsedCar tradeIn = new UsedCar();
                Console.Write("Enter the Make of the car: ");
                tradeIn.Make = Console.ReadLine();
                Console.Write("Enter the Model of the car: ");
                tradeIn.Model = Console.ReadLine();
                Console.Write("Enter the Year of the car: ");
                tradeIn.Year = Int32.Parse(Console.ReadLine());
                Console.Write("Enter the List Price of the car: ");
                tradeIn.Price = Double.Parse(Console.ReadLine());
                Console.Write("Enter the Mileage of the car: ");
                tradeIn.Mileage = double.Parse(Console.ReadLine());
                Console.Write("Enter the ID number of the car");
                tradeIn.Id = Int32.Parse(Console.ReadLine());
               

                carinventory.Add(tradeIn);
                Console.WriteLine(tradeIn.ToString());


            }
        }



    }

    class Program
    {
        static void BuyCar(List<Car> carinventory) //allows customers to buy car and removes from inventory
        {
            
            Console.Write("Which car would you like to buy? Enter the car ID number: ");
            int choice = Int32.Parse(Console.ReadLine());

            for (int i = 0; i < carinventory.Count; i++)
            {
                if (carinventory[i].Id == choice)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{carinventory[i].ToString()} is a nice choice!");
                    Console.WriteLine();
                    carinventory.RemoveAt(i);

                }
            }
        }

        static void SellCar(List<Car> carinventory) //allows customer to sell car and adds to inventory
        {
            
            UsedCar tradeIn = new UsedCar();
            Console.Write("Enter the Make of the car: ");
            tradeIn.Make = Console.ReadLine();
            Console.Write("Enter the Model of the car: ");
            tradeIn.Model = Console.ReadLine();
            Console.Write("Enter the Year of the car: ");
            tradeIn.Year = Int32.Parse(Console.ReadLine());
            Console.Write("Enter the List Price of the car: ");
            tradeIn.Price = Double.Parse(Console.ReadLine());
            Console.Write("Enter the Mileage of the car: ");
            tradeIn.Mileage = Double.Parse(Console.ReadLine());
            Console.Write("Enter the ID number of the car: ");
            tradeIn.Id = Int32.Parse(Console.ReadLine());
            carinventory.Add(tradeIn);
            Console.WriteLine(tradeIn.ToString());
            Console.WriteLine();
        }


        static void Main(string[] args)
        {

            List<Car> carinventory = new List<Car>();
            Carlot dealer = new Carlot();
            carinventory.Add(new Car("Kia", "Forte", 2019, 20000.00, 1));
            carinventory.Add(new Car("Kia", "Optima", 2021, 250000, 2));
            carinventory.Add(new Car("Kia", "Sportage", 2021, 280000, 3));
            carinventory.Add(new UsedCar("Honda", "Civic", 2015, 12000, 4, 60000));
            carinventory.Add(new UsedCar("Chevy", "Cruze", 2018, 100000, 5, 300000));
            carinventory.Add(new UsedCar("Ford", "Focus", 2018, 130000, 6, 25000));
            
            Console.WriteLine("Welcome to Summit Place Kia! You should be drivin a Kia at Summit Place Kia!");
            Console.WriteLine();
            bool valid = false; //validates user input to buy, sell, or leave
            while (!valid)
            {
                dealer.PrintList(carinventory);
                Console.WriteLine();
                Console.Write("Would you like to buy a car, sell a car, or leave the the Car Lot? Enter (buy, sell, or leave): ");
                string action = Console.ReadLine().ToLower();
                if (action != "buy" && action != "sell" && action != "leave")
                {
                    Console.WriteLine("That is not a valid option. Enter Buy, Sell, or Leave");
                }
                switch (action) //runs buy, sell , and leave application options
                {
                    case "buy":
                        BuyCar(carinventory);
                        break;
                    case "sell":
                        SellCar(carinventory);
                        break;
                    case "leave":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Not a valid option");
                        break;
                }




            }

        }
    }
}


