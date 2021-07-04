using System;
using System.Collections.Generic;
using System.Text;

namespace BookingRoomSystem
{
    class Resident:User
    {
        private string name;
        public Resident(string name,string username,string password):base(username,password)
        {
            this.name = name;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


    }
}
