using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Design_Pattern
{

    //Note:  public event EventHandler<string>? OnClick;
    //Use for standard .NET event patterns where sender & event args are needed.
    /// <summary>
    /// This is also a pub-sub model but with the help of Events and delegates.Here events are helping us
    /// to Notify the subsciber all at once.
    /// </summary>
    public static class Events_Delegates
    {
        public static void Intialize()
        {
            
            Publisher publisher = new Publisher();

            //creating subscriber
            Subscribers subscriber1 = new Subscribers("Subscriber1",publisher);
            Subscribers subscriber2 = new Subscribers("Subscriber2", publisher);

            //publish event
            publisher.SendMessage("New vidoe came");
        }
    }

    public class Publisher
    {
        public delegate void Notify(string message);

        public event Notify? OnMessageSent;

        public void SendMessage(string message)
        {
            Console.WriteLine($"[publisher sending msg {message}]"); 
            //when program control flow comes on below line it will goes to ReciveMessage and publish the 
            //events.for all the subscriber at once because it is added all the subscriber in Subscribers constructor.
            OnMessageSent?.Invoke(message);
        }

    }

    class Subscribers
    {
        private readonly string? _name;
        public Subscribers(string name , Publisher publisher)
        {
            _name = name;
            //adding all the subsciber here.
            publisher.OnMessageSent += ReceiveMessage;

        }

        public void ReceiveMessage(string message)
        {
            Console.WriteLine($"[{_name}] Received: {message}");
        }
    }
}
