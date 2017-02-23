using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Examples
{
    class Program
    {
        #region Class Definitions
        public class Customer
        {
            public string First { get; set; }
            public string Last { get; set; }
            public string State { get; set; }
            public double Price { get; set; }
            public string[] Purchases { get; set; }
        }

        public class Distributor
        {
            public string Name { get; set; }
            public string State { get; set; }
        }

        public class CustDist
        {
            public string custName { get; set; }
            public string distName { get; set; }
        }

        public class CustDistGroup
        {
            public string custName { get; set; }
            public IEnumerable<string> distName { get; set; }
        }
        #endregion

        #region Create data sources

        static List<Customer> customers = new List<Customer>
        {
            new Customer {First = "Cailin", Last = "Alford", State = "GA", Price = 930.00, Purchases = new string[] {"Panel 625", "Panel 200"}},
            new Customer {First = "Theodore", Last = "Brock", State = "AR", Price = 2100.00, Purchases = new string[] {"12V Li"}},
            new Customer {First = "Jerry", Last = "Gill", State = "MI", Price = 585.80, Purchases = new string[] {"Bulb 23W", "Panel 625"}},
            new Customer {First = "Owens", Last = "Howell", State = "GA", Price = 512.00, Purchases = new string[] {"Panel 200", "Panel 180"}},
            new Customer {First = "Adena", Last = "Jenkins", State = "OR", Price = 2267.80, Purchases = new string[] {"Bulb 23W", "12V Li", "Panel 180"}},
            new Customer {First = "Medge", Last = "Ratliff", State = "GA", Price = 1034.00, Purchases = new string[] {"Panel 625"}},
            new Customer {First = "Sydney", Last = "Bartlett", State = "OR", Price = 2105.00, Purchases = new string[] {"12V Li", "AA NiMH"}},
            new Customer {First = "Malik", Last = "Faulkner", State = "MI", Price = 167.80, Purchases = new string[] {"Bulb 23W", "Panel 180"}},
            new Customer {First = "Serena", Last = "Malone", State = "GA", Price = 512.00, Purchases = new string[] {"Panel 180", "Panel 200"}},
            new Customer {First = "Hadley", Last = "Sosa", State = "OR", Price = 590.20, Purchases = new string[] {"Panel 625", "Bulb 23W", "Bulb 9W"}},
            new Customer {First = "Nash", Last = "Vasquez", State = "OR", Price = 10.20, Purchases = new string[] {"Bulb 23W", "Bulb 9W"}},
            new Customer {First = "Joshua", Last = "Delaney", State = "WA", Price = 350.00, Purchases = new string[] {"Panel 200"}}
        };

        static List<Distributor> distributors = new List<Distributor>
        {
            new Distributor {Name = "Edgepulse", State = "UT"},
            new Distributor {Name = "Jabbersphere", State = "GA"},
            new Distributor {Name = "Quaxo", State = "FL"},
            new Distributor {Name = "Yakijo", State = "OR"},
            new Distributor {Name = "Scaboo", State = "GA"},
            new Distributor {Name = "Innojam", State = "WA"},
            new Distributor {Name = "Edgetag", State = "WA"},
            new Distributor {Name = "Leexo", State = "HI"},
            new Distributor {Name = "Abata", State = "OR"},
            new Distributor {Name = "Vidoo", State = "TX"}
        };

        static double[] exchange = { 0.89, 0.65, 120.29 };

        static double[] ExchangedPrices = {827.70, 604.50, 111869.70,
                                        1869.00, 1,365.00, 252609.00,
                                        521.36, 380.77, 70465.88,
                                        455.68, 332.80, 61588.48,
                                        2018.34, 1474.07, 272793.66,
                                        920.26, 672.10, 124379.86,
                                        1873.45, 1368.25, 253210.45,
                                        149.34, 109.07, 20184.66,
                                        455.68, 332.80, 61588.48,
                                        525.28, 383.63, 70995.16,
                                        9.08, 6.63, 1226.96,
                                        311.50, 227.50, 42101.50};

        static string[] Purchases = {  "Panel 625", "Panel 200",
                                    "12V Li",
                                    "Bulb 23W", "Panel 625",
                                    "Panel 200", "Panel 180",
                                    "Bulb 23W", "12V Li", "Panel 180",
                                    "Panel 625",
                                    "12V Li", "AA NiMH",
                                    "Bulb 23W", "Panel 180",
                                    "Panel 180", "Panel 200",
                                    "Panel 625", "Bulb 23W", "Bulb 9W",
                                    "Bulb 23W", "Bulb 9W",
                                    "Panel 200"
                                 };
        #endregion

        static void Main(string[] args)
        {
            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5();
            //Exercise6();
            Exercise7();
            Console.ReadKey();
            
        }
        private static void Exercise1()
        {
            Console.WriteLine("Prices less that 1 000:\n");
            foreach (double price in ExchangedPrices)
            {
                if (price < 1000)
                {
                    Console.WriteLine(price);
                }
            }
            Console.WriteLine("\n");

            Console.WriteLine("Customers from Georgia (GA) and their purchases:\n");
            foreach (Customer customer in customers)
            {
                if (customer.State == "GA")
                {
                    Console.WriteLine(customer.First);
                    foreach (string purchase in customer.Purchases)
                    {
                        Console.WriteLine("\t" + purchase);
                    }
                }
            }
        }
        private static void Exercise2()
        {
            Console.WriteLine("First names of the customers:\n");
            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer.First);
            }
            Console.WriteLine("\n");

            Console.WriteLine("Customers' first and last names:\n");
            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer.First + " " + customer.Last);
            }
            Console.WriteLine("\n");

            Console.WriteLine("State abreviations that are the same for customers and distributors:\n");
            foreach (Customer customer in customers)
            {
                foreach (Distributor distributor in distributors)
                {
                    if (customer.State == distributor.State)
                    {
                        Console.WriteLine(customer.State);
                    }
                }
            }
        }
        private static void Exercise3()
        {
            List<Customer> listOfCustFromOR = new List<Customer>();
            Console.WriteLine("First 3 customers in our list:\n");
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine(customers[i].First);
            }
            Console.WriteLine("\n");

            Console.WriteLine("First 3 customers from Oregon (OR) in our list:\n");
            foreach (Customer customer in customers)
            {
                if (customer.State == "OR")
                {
                    listOfCustFromOR.Add(customer);
                }
            }
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine(listOfCustFromOR[i].First);
            }

        }
        private static void Exercise4()
        {
            List<string> listOfFirst = new List<string>();
            Console.WriteLine("Customers' first names sorted alphabetically:\n");
            foreach (Customer customer in customers)
            {
                listOfFirst.Add(customer.First);
                listOfFirst.Sort();
            }
            foreach (string name in listOfFirst)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("\n");

            Console.WriteLine("Customers' last names sorted by length:\n");
            customers.Sort(delegate (Customer one, Customer two)
            {
                return one.Last.Length.CompareTo(two.Last.Length);
            }
            );
            foreach (Customer c in customers)
            {
                Console.WriteLine(c.Last);
            }
            Console.WriteLine("\n");

            Console.WriteLine("Customers' prices sorted descending:\n");
            customers.Sort(delegate (Customer one, Customer two)
            {
                return two.Price.CompareTo(one.Price);
            }
            );
            foreach (Customer c in customers)
            {
                Console.WriteLine(c.Price);
            }
            Console.WriteLine("\n");

            Console.WriteLine("Customers' first names sorted by length and last names alphabetically:\n");
            customers.Sort(delegate (Customer one, Customer two)
            {
                return one.Last.CompareTo(two.Last);
            }
            );
            customers.Sort(delegate (Customer one, Customer two)
            {
                return one.First.Length.CompareTo(two.First.Length);
            }
            );
            foreach (Customer c in customers)
            {
                Console.WriteLine(c.First + " " + c.Last);
            }
        }
        private static void Exercise5()
        {
            char currentLetter = 'A';
            string currentState = "";
            bool firstTime = true;
            List<string> listOfFirst = new List<string>();
            Console.WriteLine("Customers grouped by first letter:\n");
            foreach (Customer customer in customers)
            {
                listOfFirst.Add(customer.First);
                listOfFirst.Sort();
            }
            foreach (string name in listOfFirst)
            {
                if(currentLetter != name[0] || firstTime)
                {
                    Console.WriteLine(name[0]);
                    currentLetter = name[0];
                    firstTime = false;
                }
                Console.WriteLine(name);
            }
            Console.WriteLine("\n");

            Console.WriteLine("Customers grouped by state:\n");
            customers.Sort(delegate (Customer one, Customer two)
            {
                return one.State.CompareTo(two.State);
            }
            );
            foreach (Customer customer in customers)
            {
                if (currentState != customer.State || firstTime)
                {
                    Console.WriteLine(customer.State);
                    currentState = customer.State;
                    firstTime = false;
                }
                Console.WriteLine(customer.First);
            }
        }
        private static void Exercise6()
        {
            Console.WriteLine("Customers' names that have different starting letter in their first and last name:\n");
            foreach (Customer customer in customers)
            {
                if(customer.First[0] != customer.Last[0])
                {
                    Console.WriteLine(customer.First + " " + customer.Last);
                }
            }
        }
        private static void Exercise7()
        {
            Console.WriteLine("Customers that contain \"ed\" in their first name:\n ");
            foreach(Customer customer in customers)
            {
                if(customer.First.Contains("ed"))
                {
                    Console.WriteLine(customer.First);
                }
            }
        }
    }
}
