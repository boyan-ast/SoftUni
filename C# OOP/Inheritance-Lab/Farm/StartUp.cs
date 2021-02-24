using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog doggy = new Dog();
            doggy.Eat();
            doggy.Bark();

            Puppy scooby = new Puppy();
            scooby.Bark();
            scooby.Eat();
            scooby.Weep();

            Cat macy = new Cat();
            macy.Eat();
            macy.Meow();
        }
    }
}
