using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    class Generator
    {
        public enum SupriseTypes : byte { One, Two, Three }

        public static dynamic GetSurprise()
        {
            Array values = Enum.GetValues(typeof(SupriseTypes));
            Random rand = new Random();
            SupriseTypes type = (SupriseTypes)values.GetValue(rand.Next(values.Length));

            switch (type)
            {
                case SupriseTypes.One:
                    return new Person() { Name = "John" };
                case SupriseTypes.Two:
                    return new { Id = 2, Name = "Ivan", Age = 30 };
                case SupriseTypes.Three:
                    return new { Data = new Person() { Name = "Yurii" }, Process = new Action(Generator.PrintAPerson) };
            }
            return null;
        }

        public static void PrintAPerson()
        {
            Console.WriteLine("Stub");
        }
    }
}
