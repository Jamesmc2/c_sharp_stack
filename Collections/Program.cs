using System;
using System.Collections.Generic;


namespace Collections

{
    class Program
    
    {
        static void Main(string[] args)
        {
            int[] arrayOne = {1,2,3,4,5,6,7,8,9};
            string[] arrayTwo = {"Tim", "Martin", "Nikki", "Sara"};
            bool[] arrayThree = {true,false,true,false,true,false,true,false,true,false};

            List<string> flavors = new List<string>();
            flavors.Add("Vanilla");
            flavors.Add("Chocolate");
            flavors.Add("Strawberry");
            flavors.Add("Mint Chocolate Chip");
            flavors.Add("Cookie Dough");
            Console.WriteLine($"There are {flavors.Count} flavors known!");
            Console.WriteLine($"The third flavor is {flavors[2]}");
            flavors.RemoveAt(2);
            Console.WriteLine($"The new number of known flavors is {flavors.Count}!");

            Dictionary<string,string> person = new Dictionary<string,string>();
            foreach(var name in arrayTwo)
            {
                person.Add(name, "Speros");
            }
        }

        
    }
}
