using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BookingRoomSystem
{
    class Hotel
    {
        private string hotelid, hotelname, city;

        private int numofrooms, stars;

        List<Room> roomlist = new List<Room>();

        public Hotel(string hotelid,string hotelname,string city,int numofrooms,double roomprice, int stars)
        {
            this.hotelid = hotelid;
            this.hotelname = hotelname;
            this.city = city;
            this.numofrooms = numofrooms;
            this.stars = stars;

            for (int i=0;i<numofrooms;i++)
            {
                roomlist.Add(new Room(i, roomprice));
            }
            
        }
        public string Hotelid
        {
            get { return hotelid; }
            set { hotelid = value; }
        }

        //prints hotel info
        public void Info()
        {
            Console.WriteLine("Hotel name:"+hotelname);
            Console.WriteLine("City:" + city);
            Console.WriteLine("Stars:"+stars);
            Console.WriteLine("Room price:" + roomlist[0].Price);
            Console.WriteLine("Number of rooms:"+numofrooms);
        }        
        //prints all occupied rooms in the hotel
        public void PrintOccupiedRooms()
        {
            foreach (var Room in roomlist)
            {
                if (Room.Bookedby != null)
                {
                    Console.WriteLine("Room " + Room.Number + " booked by: " + Room.Bookedby);
                }

            }
        }
        //prints rooms which are empty
        public void PrintAvailableRooms()
        {
            Console.WriteLine("Hotel name: " + hotelname + " id " + hotelid + " available rooms:");
            foreach (var Room in roomlist)
            {
                if (Room.Bookedby == null)
                {
                    Console.WriteLine("Room " + Room.Number);
                }
            }
        }
        //prints all info regarding the hotel with occupied rooms to a text file
        
        public void PrintAllInfoOccupiedtotxt()
        {
            StreamWriter sw = new StreamWriter("C://Users/berko/Desktop/info.txt");
            sw.WriteLine("Hotel name:" + hotelname);
            sw.WriteLine("City:" + city);
            sw.WriteLine("Stars:" + stars);
            sw.WriteLine("Room price:" + roomlist[0].Price);
            sw.WriteLine("Number of rooms:" + numofrooms);
            foreach (var Room in roomlist)
            {
                if (Room.Bookedby != null)
                {
                    sw.WriteLine("Room " + Room.Number + " booked by: " + Room.Bookedby);
                }
            }
        }
        public void PrintAllInfoOccupied()
        {
            Info();
            PrintOccupiedRooms();
        }
        public void BookRoom(int roomnum, string name)
        {
            bool booked = false;
            while (!booked)
            {
                if (roomlist[roomnum].Bookedby == null) 
                {
                    roomlist[roomnum].Bookedby = name;
                    Console.WriteLine("Room "+roomnum+" at "+hotelname+" successfully booked for "+name);
                    booked = true;
                }
                else
                {
                    Console.WriteLine("Unable to book, please enter a valid or unoccupied room.");
                }
                
            }
        }
    }
}