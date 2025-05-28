using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Design_Pattern.BehavioralDesignPattern
{

    /// <summary>
    /// This class implements command pattern.This is the client class.
    /// The Command design pattern consists of the Invoker class, Command class/interface, Concrete command classes, and the Receiver class.
    /// The Command Pattern is a behavioral design pattern that turns a request into an object.
    /// Parameterize methods with different requests.
    /// Queue or log requests.
    /// Support undo/redo operations.
    /// Understand commands ->  Commands should represent specific business tasks instead of low-level data updates.
    /// For example, in a hotel-booking app, use the command "Book hotel room" instead of "Set ReservationStatus to Reserved."
    /// This approach better captures the intent of the user and aligns commands with business processes.
    /// To help ensure that commands are successful, you might need to refine the user interaction flow and server-side logic and consider asynchronous processing.
    /// </summary>
    public class CommandPattern
    {
       public void Run()
       {
            // Setup commands
            ICommand addData = new AddData();   
            ICommand deleteData = new DeleteData(); 

            // Inject into panel
            Panel panel = new Panel(addData, deleteData);

            // Simulate operation
            panel.Operation("addData"); 
            panel.Operation("deleteData");

            panel.UndoLast();
            panel.UndoLast();
            panel.UndoLast();
        }

    }

    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    /// <summary>
    /// This is Invoker Class.it does not know what the command does it is just invoking them.
    /// This is the method which is receving the command query.
    /// This is main which is decoupling the logic.
    /// </summary>
    public class Panel
    {
        private readonly ICommand _addData;
        private readonly ICommand _deleteData;
        private readonly Stack<ICommand> _history = new();
        public Panel(ICommand addData, ICommand deleteData)
        {
            _addData = addData;
            _deleteData = deleteData;    
            
        }

        public void Operation(string requestObject)
        {
            if (requestObject == "addData")
            {
                _addData.Execute();
                _history.Push(_addData);
            }
            else if(requestObject=="deleteData")
            {
                _deleteData.Execute();
                _history.Push(_deleteData);
            }
        }

        public void UndoLast()
        {
            if (_history.Count == 0)
            {
                Console.WriteLine("No command to Undo");
            }
            if(_history.Count > 0)
            {
                ICommand undoLast = _history.Pop();
                undoLast.Undo();    
            }
        }

    }

    /// <summary>
    /// Concreate Class. or Reciver class
    /// This is the Concrete class which will implement the interface method and provide the business logic.
    /// </summary>
    public class AddData : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Data Added Sucessfully to write DB");
        }

        public void Undo()
        {
            Console.WriteLine("Removing the Data added to write DB ");    
        }
    }

    /// <summary>
    /// Concreate Class or Reciver class.
    /// This is the Concrete class which will implement the interface method and provide the business logic.
    /// </summary>
    public class DeleteData : ICommand
    {
        bool transaction = true; // it means you are inside the transaction and delete is still not yet commited.
        public void Execute()
        {
            Console.WriteLine("Deleted the Data Successfully");
        }

        public void Undo()
        {
            if (transaction)
                Console.WriteLine("Your deleted data is roll backed");
            else
                Console.WriteLine("Cannot roll back your deleted data");
        }
    }


}