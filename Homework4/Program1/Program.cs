using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Test
{
    class Clock
    {
        public event EventHandler ring;

        protected virtual void OnRing()
        {
            EventHandler temp = ring;
            if (temp != null) temp(this, EventArgs.Empty);
        }

        public void Ring()
        {
            OnRing();
        }
    }

    class Program
    {
        public static void Ringing(object sender, EventArgs e)
        {
            Console.WriteLine("到点了");
        }
        static void Main(string[] args)
        {
            Clock myClock = new Clock();
            myClock.ring += Ringing;

            myClock.Ring();
        }
    }
}
