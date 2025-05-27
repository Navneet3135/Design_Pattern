using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Design_Pattern.BehavioralDesignPattern
{

    /// <summary>
    /// This class implements command pattern.
    /// The Command design pattern consists of the Invoker class, Command class/interface, Concrete command classes, and the Receiver class.
    /// The Command Pattern is a behavioral design pattern that turns a request into an object.
    /// Parameterize methods with different requests.
    /// Queue or log requests.
    /// Support undo/redo operations.
    /// </summary>
    public class CommandPattern
    {
       public void Run()
       {
            // Setup commands
            ICommand applyBrakes = new ApplyBrakes();
            ICommand showWarning = new StartShowWarning();

            // Inject into panel
            Panel panel = new Panel(applyBrakes, showWarning);

            // Simulate operation
            panel.Operation(301); 
            panel.Operation(400);
        }

    }

    public interface ICommand
    {
        void Execute();
    }

    /// <summary>
    /// Invoker Class.
    /// This panel class is acting as an client.which has the actuall business logic.
    /// This is the method which is receving the command query.
    /// </summary>
    public class Panel
    {
        private readonly ICommand _applyBrakes;
        private readonly ICommand _warning;

        public Panel(ICommand applybrake,ICommand startShowWarning)
        {
            _applyBrakes = applybrake;
            _warning = startShowWarning;    
            
        }

        public void Operation(int errorCode)
        {
            if (errorCode == 301)
            {
                _applyBrakes.Execute();
            }
            else
            {
                _warning.Execute();
            }
        }

    }

    /// <summary>
    /// Concreate Class.
    /// This is the Concrete class which will implement the interface method and provide the business logic.
    /// </summary>
    public class ApplyBrakes : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Applying brakes");
        }
    }

    /// <summary>
    /// Concreate Class.
    /// This is the Concrete class which will implement the interface method and provide the business logic.
    /// </summary>
    public class StartShowWarning : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Some issue in ECU");
        }

    }

}