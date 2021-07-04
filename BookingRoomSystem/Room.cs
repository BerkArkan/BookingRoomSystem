using System;
using System.Collections.Generic;
using System.Text;

namespace BookingRoomSystem
{
    class Room
    {
        private int number;
        private double price;
        private string bookedby;
        public Room(int number, double price)
        {
            this.number = number;
            this.price = price;
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }
        public string Bookedby
        {
            get { return bookedby; }
            set { bookedby = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
