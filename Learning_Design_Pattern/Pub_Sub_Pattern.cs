using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Design_Pattern
{
    public static class Pub_Sub_Pattern
    {
        static Pub_Sub_Pattern()
        {
        }

        public static async void IntializeEvents()
        {
            Event events = new Event();

            //creating subscriber 
            Subscriber subscriber1 = new Subscriber("subscriber 1");
            Subscriber subscriber2 = new Subscriber("subscriber 2");

            //subscribe to the event 
            events.AddSubscriber(subscriber1);
            events.AddSubscriber(subscriber2);

            //publishing message
            events.Publish("Chanel subscribed 1");
            await Task.Delay(1000);
            events.Publish("Chanel subscribed 2");

            //unsubscriber a subcriber
            events.RemoveSubscriber(subscriber1);
            events.Publish("Final events");

            Console.ReadLine(); 

        }
    }

    public class Event
    {
        public List<Subscriber> subscribers = new List<Subscriber>();

        public Subscriber AddSubscriber(Subscriber subscriber)
        {
            subscribers.Add(subscriber);
            return subscriber;

        }

        public Subscriber RemoveSubscriber(Subscriber subscriber)
        {
            subscribers.Remove(subscriber);
            return subscriber;
        }

        public void Publish(string message)
        {
            foreach(var sub in subscribers)
            {
                Console.WriteLine($"[Publisher] Published: {message}");
                sub.ReciveMessage(message);
            }
        }
    }

    public class Subscriber
    {
        private readonly string _name;
        public Subscriber(string name) 
        {
            _name = name;   
        }

        public void ReciveMessage(string message)
        {
            Console.WriteLine($"[{_name}] Recived : {message}");
        }
    }
}
