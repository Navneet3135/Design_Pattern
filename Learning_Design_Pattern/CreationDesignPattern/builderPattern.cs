using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Learning_Design_Pattern.CreationDesignPattern
{

    //When dealing with configuration objects, we often have multiple optional parameters.
    //The Builder Pattern helps in constructing these objects step-by-step while keeping 
    //the code readable and flexible.

    //Why Use Builder for Configuration Objects?
    //Avoid constructor overloads: Instead of multiple constructors with different parameters, the builder provides a clear way to construct objects.
    //Improved readability: The step-by-step approach makes the code more readable.
    //Flexibility: Easily allows setting only the required configuration values.

    //Let’s say we have a class builderPattern that stores database connection settings.
    //Some parameters are required(e.g., Server), while others are optional(e.g., Port,
    //Username, Password, Timeout).
    public class builderPattern
    {
        public string? Server { get; set; }
        public int Port { get; set; }
        public string? DatabaseName { get; private set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int Timeout { get; set; }

        private builderPattern() { }

        public class Builder
        {
            private builderPattern config = new builderPattern();

            public Builder SetServer(string server)
            {
                config.Server = server;
                return this;
            }

            public Builder SetPort(int port)
            {
                config.Port = port;
                return this;
            }

            public Builder SetDatabaseName(string database)
            {
                config.DatabaseName = database;
                return this;
            }

            public Builder SetUserName(string username)
            {
                config.Username = username;
                return this;
            }

            public Builder SetPassword(string password)
            {
                config.Password = password;
                return this;
            }

            public Builder SetTimeout(int timeout)
            {
                config.Timeout = timeout;
                return this;
            }

            public builderPattern Build()
            {
                return config;
            }

        }
            public void ShowConfig()
            {
                Console.WriteLine($"Server: {Server}, Port: {Port}, Database: {DatabaseName}, Username: {Username}, Timeout: {Timeout} seconds");
            }
        

    }

    public class MainMethod
    {
        public static void  Initialize()
        {

            builderPattern dbconfig = new builderPattern.Builder()
                .SetServer("localhost")
                .SetPort(123)
                .SetDatabaseName("MyDatabase")
                .SetUserName("admin")
                .SetPassword("password@123")
                .SetTimeout(10)
                .Build();
            dbconfig.ShowConfig();

            //we can use optional parameter also...
            builderPattern dbconfig1 = new builderPattern.Builder()
               .SetServer("localhost")
               .SetPort(123)
               .Build();

            dbconfig1.ShowConfig();


        }
    }
}
