using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static Learning_Design_Pattern.Delegates;

namespace Learning_Design_Pattern
{
    public static class Delegates
    {
        //Defining a delagate.
        //Delegates store method references, unlike raw C++ pointers storing memory addresses.it can hold multiple method.and you can 
        //inovke thoes multiple method by adding them.
        public delegate void VidoeMetaDataChange(string id);

        static void VidoeID(string id)
        {
            Console.WriteLine($"Metadata is changed for the vidoe ID {id}");
        }

        static void VideoUpdated(string id)
        {
            Console.WriteLine($"Vidoe is updated for the video ID {id}");
        }

        public static void Intialize()
        {
            //creating a delegate instance
            VidoeMetaDataChange vidoeMeta = VidoeID;
            vidoeMeta("12345");

            //adding a delgate instance.
            vidoeMeta += VideoUpdated; //this line is only adding the refrence of method.it will not call for calling
            vidoeMeta("234");          //you need to call videoMeta("argument") then method will invoke its business logic.
            

            vidoeMeta -= VideoUpdated;
            vidoeMeta("567");

            //for better understanding...
            //in this scenarion first we have added all the method which we want to invoke.at the 
            //end i am calling videoMeta1 it will fire all at once.like videoID and vidoeUpdateMethod.
            //if i run this two console statment will come simultaneously. if we remove one then one 
            //one console statment you will see.
            VidoeMetaDataChange vidoeMeta1 = VidoeID;
            vidoeMeta1 += VideoUpdated;
            vidoeMeta1("123");

            vidoeMeta1 -= VideoUpdated; //if this pieace of code will then you only see one statment.
            vidoeMeta1("123");

        }

    }

     //Types of Delegates
     //Use Func<T> → When a method returns a value.
     //Use Action<T> → When a method does not return anything.
     //Use Predicate<T> → When the method returns true or false.
     //Use EventHandler → When creating events
     //Use delegates when you need to pass methods as parameters dynamically, such as in callbacks and LINQ operations
}
