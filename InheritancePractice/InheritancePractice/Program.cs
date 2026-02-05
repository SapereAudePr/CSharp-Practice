using System;
using System.Security.Cryptography.X509Certificates;

namespace InheritancePractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new();
            dog.MakeSound();

            WolfDog wolfDog = new();
            wolfDog.MakeSound();


            Console.ReadKey();
        }
    }

    class Animal
    {
        public void Eat()
        {
            Console.WriteLine("Eating...");
        }

        public virtual void MakeSound()
        {
            Console.WriteLine("A generic animal sound.");
        }
    }

    // Has property of the Animal class
    class Dog: Animal
    {
        public override void MakeSound()
        {
            base.MakeSound();
            Eat();
            Console.WriteLine("Dog Barking...");
            //Eat();
        }
    }


    // Has all the property of Animal and Dog classes
    class WolfDog: Dog
    {
        public override void MakeSound()
        {
            Console.WriteLine("WolfDog Barking...");
            //Eat();
            //Bark();
        }
    }

    // Has property of the Animal class
    class Cat : Animal
    { 
        public override void MakeSound()
        {
            Console.WriteLine("Cat Meow...");
        }
    }


    class ParentClass
    {
        public int publicField;
        protected int protectedField;
        private int privateField;


    }

    class ChildClass: ParentClass
    { 
        public void Fnc()
        {
            publicField = 0;
            protectedField = 0;
            // private is only accessible in the class where it's declared.
            // privateField = 0;
        }
    }

}
