using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionDemo
{
    class Program
    {

        static void Main(string[] args)
        {
            var result = Generator.GetSurprise();

            Type type = result.GetType();

            foreach (FieldInfo fInfo in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine(fInfo.Name + " = " + fInfo.GetValue(result));
            }
            Type temp = new object().GetType();
            MethodInfo[] ObjectMethods = temp.GetMethods();
            foreach (var item in type.GetMethods())
            {
                bool x = false;
                foreach (var it in ObjectMethods)
                {
                    if (it.ToString() == item.ToString())
                    {
                        x = true;
                        break;
                    }
                }
                if (!x)
                {
                    Console.WriteLine(item);
                    Console.Write("Invoke: ");

                }
                try
                {
                    object myObj = item.Invoke(result, new object[item.GetParameters().Length]);
                    Console.WriteLine(myObj + "\n");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                foreach (var m in type.GetMethods())
                {
                    if (m.Name == "PrintPerson")
                    {
                        m.Invoke(result, null);
                    }

                }
            }

        }
    }
}
