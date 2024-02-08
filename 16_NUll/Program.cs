using _16_NUll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_NUll
{
    public abstract class Creature
    {
        public string Name { get; set; }
        public abstract void Move();

        public void Eat()
        {
            Console.WriteLine("Creature is eating.");
        }
    }
    public class Animal : Creature
    {
        public override void Move()
        {
            Console.WriteLine("Animal is moving.");
        }

        public void MakeSound()
        {
            Console.WriteLine("Animal makes a sound.");
        }
    }

}
public class Reptile : Animal
{
    public bool IsColdBlooded { get; set; }

    public void Crawl()
    {
        Console.WriteLine("Reptile is crawling.");
    }
}
public class Mammal : Animal
{
    public bool HasFur { get; set; }
    public void GiveBirth()
    {
        Console.WriteLine("Mammal gives birth.");
    }
}
public class Bird : Animal
{
    public double Wingspan { get; set; }

    public void Fly()
    {
        Console.WriteLine("Bird is flying.");
    }
}
public class Fish : Animal
{
    public string Habitat { get; set; }

    public void Swim()
    {
        Console.WriteLine("Fish is swimming.");
    }
}
public class Bear : Mammal
{
    public bool Hibernates { get; set; }

    public void Roar()
    {
        Console.WriteLine("Bear roars.");
    }
}
public class Frog : Reptile
{
    public bool CanJump { get; set; }

    public void Croak()
    {
        Console.WriteLine("Frog croaks.");
    }
}
public class Dolphin : Mammal
{
    public bool IsSmart { get; set; }

    public void Click()
    {
        Console.WriteLine("Dolphin clicks.");
    }
}
public class Carp : Fish
{
    public bool IsBottomFeeder { get; set; }

    public void Suck()
    {
        Console.WriteLine("Carp sucks.");
    }
}
public class Eagle : Bird
{
    public bool IsPredator { get; set; }

    public void Hunt()
    {
        Console.WriteLine("Eagle hunts.");
    }
}

internal class Program
    {
        static void Main(string[] args)
        {
            Bear bear = new Bear { Name = "Brown Bear", HasFur = true, Hibernates = true };
            Frog frog = new Frog { Name = "Green Frog", IsColdBlooded = true, CanJump = true };
            Dolphin dolphin = new Dolphin { Name = "Bottlenose Dolphin", HasFur = false, IsSmart = true };
            Carp carp = new Carp { Name = "Common Carp", Habitat = "Freshwater", IsBottomFeeder = true };
            Eagle eagle = new Eagle { Name = "Bald Eagle", Wingspan = 7.5, IsPredator = true };
        Console.WriteLine("Zoo Check:");
        PerformCreatureActivities(bear);
        PerformCreatureActivities(frog);
        PerformCreatureActivities(dolphin);
        PerformCreatureActivities(carp);
        PerformCreatureActivities(eagle);

        Console.ReadLine();
    }
    static void PerformCreatureActivities(Creature creature)
    {
        Console.WriteLine($"Name: {creature.Name}");
        creature.Move();
        creature.Eat();

        if (creature is Animal animal)
        {
            animal.MakeSound();
        }

        if (creature is Reptile reptile)
        {
            reptile.Crawl();
        }

        if (creature is Mammal mammal)
        {
            mammal.GiveBirth();
        }

        if (creature is Bird bird)
        {
            bird.Fly();
        }

        if (creature is Fish fish)
        {
            fish.Swim();
        }

        Console.WriteLine();
    }
}
