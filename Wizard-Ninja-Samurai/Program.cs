using System;

namespace Wizard_Ninja_Samurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard James = new Wizard("James");
            James.Stats();
            Human Bob = new Human("Bob");
            James.Attack(Bob);
            James.Stats();
        }
    }
    class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;

        public int Health{
            get {return health;}
            set {health = value;}
        }
        public Human(string name){
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }
        public Human(string name, int str, int intel, int dex, int hp){
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            health = hp;}
        public void Stats()
        {
            Console.WriteLine($"Name: {Name}, Strength: {Strength}, Intelligence: {Intelligence}, Dexterity: {Dexterity}, Health: {Health}");
        }
        public virtual int Attack(Human target)
        {
            target.health = target.health -(3*Strength);
            return target.health;
        }
    }
    class Ninja : Human
    {
        public Ninja(string name): base(name)
        {
            Dexterity = 175;
        }
        public int crit = 0;
        public override int Attack(Human target)
        {
            Random rand = new Random();
            if(rand.Next(1,5)==1)
            {
                crit = 10;
                Console.WriteLine("Critical Strike!");
            }
            else
            {
                crit = 0;
            }
            int dmg = (5*Intelligence) + crit;
            Console.WriteLine($"{Name} hit {target.Name} for {dmg} hp!");
            return target.Health;
        }
        public void Steal(Human target)
        {
            target.Health -= 5;
            Health += 5;
            Console.WriteLine($"{Name} stole 5 hp from {target.Name}!");
        }
        
    }
    class Wizard : Human
    {
        public Wizard(string name): base(name)
        {
            Health = 50;
            Intelligence = 25;
        }
        public override int Attack(Human target)
        {
            int dmg = 5*Intelligence;
            target.Health -= dmg;
            Health += dmg;
            Console.WriteLine($"{Name} strikes {target.Name} for {dmg} hp! {Name} heals for {dmg} hp!");

            return target.Health;
        }
        public void Heal(Human target)
        {
            int healz = 10*Intelligence;
            target.Health += healz;
            Console.WriteLine($"{Name} heals {target.Name} for {healz} hp!");
        }
    }
    class Samurai : Human
    {
        public Samurai(string name): base(name)
        {
            Health = 200;
        }
        public override int Attack(Human target)
        {
            if(target.Health<50)
            {
                target.Health=0;
                Console.WriteLine($"{Name} executes {target.Name}!");
            }
            else
            {
                base.Attack(target);
            }
            return target.Health;
        }
        public void Meditate()
        {
            Health = 200;
        }
    }
}
