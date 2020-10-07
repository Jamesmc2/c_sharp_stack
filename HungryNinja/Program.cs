using System;
using System.Collections.Generic;


namespace HungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    class Food
    {
        public string Name;
        public int Calories;
        // Foods can be Spicy and/or Sweet
        public bool IsSpicy;
        public bool IsSweet;
        public Food(string name, int cal, bool spicy, bool sweet)
        {
            Name = name;
            Calories = cal;
            IsSpicy = spicy;
            IsSweet = sweet;
        }
    }
    class Buffet
    {
        public static List<Food> Menu;
        //constructor
        public Buffet()
        {
            Menu = new List<Food>()
        {
            new Food("Chicken", 500, false, false),
            new Food("Steak", 600,false,false),
            new Food("Burger", 1000,false,false),
            new Food("Sushi", 120,true,false),
            new Food("Ribs", 800,false,true),
            new Food("Turkey", 600,false,false),
            new Food("Corn", 400,false,true)
        };
        }
        public static Food Serve()
        {
            Random rand = new Random();
            int index = rand.Next(0, 6);
            return Menu[index];

        }
    }
    class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;

        public Food CurrentFood;

        public Ninja()
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>();
        }
        public bool IsFull{
            get{
                if(calorieIntake>1200){
                    return true;
                }
                else{
                    return false;
                }
            }
        }

        public void Eat(){
            if(IsFull){
                Console.WriteLine("Ninja is too full too eat anymore!");
            }
            else{
                CurrentFood = Buffet.Serve();
                calorieIntake =+ CurrentFood.Calories;
                FoodHistory.Add(CurrentFood);
                Console.WriteLine($"Ninja just ate a {CurrentFood.Name}! ");
                if(CurrentFood.IsSpicy==true){
                    Console.Write("It was Spicy!");
                }
                else if(CurrentFood.IsSweet==true){
                    Console.Write("It was sweet!");
                }
            }
        }
    }
}
