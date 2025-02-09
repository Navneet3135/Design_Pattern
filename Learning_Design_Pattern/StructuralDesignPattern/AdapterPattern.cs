using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Design_Pattern.StructuralDesignPattern
{
    public class AdapterPattern
    {
        /*
         The Adapter Pattern is a structural design pattern that allows two incompatible interfaces 
        to work together. It acts as a bridge between two different interfaces, enabling a class to 
        be used in a system without modifying its existing code.

        Where is the Adapter Pattern Used?

        Third-Party Integrations

        Suppose you integrate a third-party API that provides data in XML, but your application works with JSON. An Adapter converts XML to JSON.
        Legacy Code Compatibility

        If your old system outputs data in CSV, but your new system expects JSON, an adapter can bridge the gap.
        Hardware and Software Interfaces

        Connecting old USB devices to a new Type-C port via a USB-to-Type-C adapter.
        Drivers for different operating systems (e.g., Windows vs. Linux).
        Working with Different Databases

        Suppose your application initially uses SQL Server, but now you need to switch to MongoDB.
        Instead of changing all the code, an Adapter can convert SQL queries to MongoDB queries.
         */
        public static void InitializeAdapter()
        {
            Console.WriteLine("Using Sql Server");
            IDatabase sqlDatabase = new SqlServerDatabaseAdapter(new SQLServerDatabase());
            sqlDatabase.Insert("Sql Server");
            Console.WriteLine(sqlDatabase.GetData());

            Console.WriteLine("\n switching to mongodb using Adapter");
            IDatabase mongodb = new MongoDBAdapter(new MongoDB());
            mongodb.Insert("Mongo db");
            Console.WriteLine(mongodb.GetData());   

        }
    }

    public interface IDatabase
    {
        void Insert(string data);
        string GetData();
    }

    public class SQLServerDatabase
    {
        public void InsertData(string data)
        {
            Console.WriteLine("[SQL server ] Inserting : {data}");
           
        }

        public string FetchData()
        {
            return "[SQL server] Returning Data";
        }
    }

    public class MongoDB
    {
        public void SavingDocument(string json)
        {
            Console.WriteLine($"[MongoDB] Saving document: {json}");
        }
        public string RetrieveDocument()
        {
            return "[Mongo DB Returning Document]";
        }
    }

    public class MongoDBAdapter : IDatabase
    {
        private MongoDB? _mongoDB;

        public MongoDBAdapter(MongoDB db)
        {
            _mongoDB = db;   
        }

        public void Insert(string data)
        {
            Console.WriteLine("Adapter converting SQL Insert to MongoDB saveDocument");
            _mongoDB?.SavingDocument(data);
        }

        public string GetData()
        {
            Console.WriteLine("Adapter converting SQL FetchData to MongoDB RetrieveDocument...");
            return _mongoDB.RetrieveDocument();
        }
    }

    public class SqlServerDatabaseAdapter : IDatabase
    {
        private SQLServerDatabase? _sqlServerDatabase;

        public SqlServerDatabaseAdapter(SQLServerDatabase sqlServerDatabase)
        {
            _sqlServerDatabase = sqlServerDatabase; 
        }
        public string GetData()
        {
          return  _sqlServerDatabase.FetchData();
        }

        public void Insert(string data)
        {
            _sqlServerDatabase?.InsertData(data);
        }
    }
}
