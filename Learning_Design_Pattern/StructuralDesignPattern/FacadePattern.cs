using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Design_Pattern.StructuralDesignPattern
{
    public class FacadePattern
    {
        DVDPlayer dvdPlayer = new DVDPlayer();  
        Projector projector = new Projector();  
        SoundSystem soundSystem = new SoundSystem();

        public void IntializeFacade()
        {
            HomeTheaterFacade homeTheater = new HomeTheaterFacade(dvdPlayer, projector, soundSystem);
            homeTheater.WatchMovie("Inception");
            homeTheater.EndMovie(); 

        }


    }

    public class HomeTheaterFacade      
    {
        private DVDPlayer? dvdPlayer;
        private Projector? projector;
        private SoundSystem? soundSystem;

        public HomeTheaterFacade(DVDPlayer dvd, Projector proj, SoundSystem sound)
        {
            dvdPlayer = dvd;
            projector = proj;
            soundSystem = sound;
        }

        public void WatchMovie(string movie)
        {
            Console.WriteLine("\n preparing to watch movie");
            projector?.On();
            projector?.ProjectorInput("DVD");
            soundSystem?.On();
            soundSystem?.SetVolume(10);
            dvdPlayer?.On();    
            dvdPlayer?.Play(movie);  
        }

        public void EndMovie()
        {
            Console.WriteLine("Shutting down home theater");
            dvdPlayer?.Off();
            soundSystem?.Off();
            projector?.Off();
        }
    }

    public class DVDPlayer
    {
        public void On() => Console.WriteLine("DVD Player is on");
        public void Play(string movie)=> Console.WriteLine($"Playing movie : {movie}");
        public void Off() => Console.WriteLine("DVD player is off");
    }

    public class Projector
    {
        public void On() => Console.WriteLine("Projector is On");
        public void ProjectorInput(string input) => Console.WriteLine($"Projector input set to {input}");

        public void Off() => Console.WriteLine("Projector is Off");
    }

    public class SoundSystem
    {
        public void On() => Console.WriteLine("Sound system is ON");
        public void SetVolume(int level) => Console.WriteLine($"Volume set to {level}");
        public void Off() => Console.WriteLine("Sound system is off");
    }


}
