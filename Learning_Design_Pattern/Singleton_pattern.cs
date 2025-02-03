using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Design_Pattern
{
    //Singleton class should be sealed. Not static.
    //A static class cannot implement an interface, while a Singleton class can.
    //This is important for dependency injection and unit testing.
    //Singleton supports interfaces, allowing flexibility in design.Static classes do not allow this.
    //In ASP.NET Core, Singleton objects can be registered and injected using DI containers,
    //but static classes cannot.
    //Static classes cannot be inherited, whereas Singleton classes can be extended or mocked for unit testing.
    //Singletons allow inheritance and can be mocked for testing.
    //A static class lives as long as the application and is initialized once at startup.
    //A Singleton can be disposed and recreated when necessary
    //Static classes cannot be reset or reinitialized.

    /// <summary>
    /// Singleton Class used to prevent external creation of object.
    /// </summary>
    public sealed class Singleton_pattern
    {
        public static  Singleton_pattern singleton_Pattern =null;
        static Singleton_pattern()
        {
            Console.WriteLine($"Single constructor invoked");
        }

        public static Singleton_pattern GetInstance()
        {
            if (singleton_Pattern == null)
                return new Singleton_pattern();
            else
              return   singleton_Pattern;
              
        }
    }
}
