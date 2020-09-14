using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Serial serial = new Serial();
            serial.Watch();
            SerialHistory s = new SerialHistory();

            s.History.Push(serial.SaveState());

            serial.Watch();

            serial.RestoreState(s.History.Pop());

            serial.Watch(); 

            Console.Read();
        }
    }


    class Serial
    {
        private int episodes = 23;

        private int count = 0;

        public void Watch()
        {
            if (count < 23)
            {
                count++;
                Console.WriteLine($"You are watching episode number {count}. {episodes - count} episodes left.");
            }
            else
                Console.WriteLine("There are no more episodes.");
        }

        public EpisodeMemento SaveState()
        {
            Console.WriteLine($"Serial saved: {episodes - count} episodes left.");
            return new EpisodeMemento(episodes);
        }


        public void RestoreState(EpisodeMemento memento)
        {
            this.episodes = memento.Episodes;
            Console.WriteLine($"You have {count} episodes watched.");
        }
    }

    class EpisodeMemento
    {
        public int Episodes { get; private set; }

        public EpisodeMemento(int episodes)
        {
            Episodes = episodes;
        }
    }

    class SerialHistory
    {
        public Stack<EpisodeMemento> History { get; private set; }
        public SerialHistory()
        {
            History = new Stack<EpisodeMemento>();
        }
    }
}
