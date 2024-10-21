using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public interface IAnimal
    {
        void MakeSound();
        void Eat();
    }
    public abstract class Animal : IAnimal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public abstract void MakeSound();
        public void Eat()
        {
            Console.WriteLine($"{Name} je");
        }
        public class Dog : Animal
        {
            public Dog(string name, int age) : base(name, age) { }
            public override void MakeSound()
            {
                Console.WriteLine("Gau!");
            }
        }

        public class Cat : Animal
        {
            public Cat(string name, int age) : base(name, age) { }
            public override void MakeSound()
            {
                Console.WriteLine("Meow!");
            }
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                Dog dog = new Dog("Azor", 3);
                Cat cat = new Cat("Mruczek", 2);

                dog.MakeSound();
                cat.MakeSound();

                dog.Eat();
                cat.Eat();
                Console.Clear();

                var Animal = new List<Animal>()
                {
                    dog,cat,
                    new Dog("Azor", 3),
                    new Cat("Mruczek", 2),
                };
                foreach (var animal in Animal)
                {
                    animal.MakeSound();
                    animal.Eat();
                }
                Console.ReadKey();
            }
        }
    }
}
