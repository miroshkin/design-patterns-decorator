using System;

namespace DesignPatterns_Decorator
{

    class Program
    {
        ///Original source https://metanit.com/sharp/patterns/4.1.php
        static void Main(string[] args)
        {
            Console.WriteLine("Design Patterns - Decorator!");

            Pizza pizza1 = new ItalianPizza();
            pizza1 = new TomatoPizza(pizza1);
            pizza1.PrintDescription();

            Pizza pizza2 = new BulgarianPizza();
            pizza2 = new TomatoPizza(pizza2);
            pizza2 = new CheesePizza(pizza2);
            pizza2.PrintDescription();
        }
    }

    abstract class Pizza
    {
        public Pizza(string name)
        {
            this.Name = name;
        }

        public string Name { get; protected set; }
        public abstract int GetCost();

        public void PrintDescription()
        {
            Console.WriteLine($"{this.Name} ${this.GetCost()}");
        }
    }

    class ItalianPizza : Pizza
    {
        public ItalianPizza() : base("Italian pizza")
        {

        }

        public override int GetCost()
        {
            return 10;
        }
    }

    class BulgarianPizza : Pizza
    {
        public BulgarianPizza() : base("Bulgarian pizza")
        {

        }

        public override int GetCost()
        {
            return 8;
        }
    }

    abstract class PizzaDecorator : Pizza
    {
        protected Pizza pizza;

        public PizzaDecorator(string name, Pizza pizza) : base (name)
        {
            this.pizza = pizza;
        }
    }

    class TomatoPizza : PizzaDecorator
    {
        public TomatoPizza(Pizza pizza) : base(pizza.Name + ", with tomato", pizza)
        {

        }

        public override int GetCost()
        {
            return pizza.GetCost() + 3;
        }
    }

    class CheesePizza : PizzaDecorator
    {
        public CheesePizza (Pizza pizza) : base(pizza.Name + ", with cheese", pizza)
        {

        }

        public override int GetCost()
        {
            return pizza.GetCost() + 3;
        }
    }


}
