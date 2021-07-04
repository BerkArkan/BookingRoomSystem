using System;
using System.Collections.Generic;
using System.Text;

namespace BookingRoomSystem
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Admin> adminlist = new List<Admin>();
            List<Resident> residentlist = new List<Resident>();
            List<Hotel> hotellist = new List<Hotel>();

            bool isAdmin = false;
            bool loggedIn = false;

            adminlist.Add(new Admin("admin", "12345"));
            residentlist.Add(new Resident("Berk Arkan","berk123","12345"));

            while (true)
            {
                if (!loggedIn){
                    Console.WriteLine("--Booking a Room System--");
                    login();
                }
                else
                {
                    if (isAdmin) 
                    {
                        while (loggedIn) { adminops(); }
                    }
                    if (!isAdmin) 
                    {
                        while (loggedIn) { userops(); }
                    }
                }
                
            }
            
            //operations that an admin can do
            void adminops()
            {
                string hotelid = null, hotelname = null, city = null;
                int numofrooms = 0, stars = 0;
                double roomprice = 0.0;
                int index = 0;

                Console.WriteLine("press 1 to create a hotel");
                Console.WriteLine("press 2 to remove a hotel");
                Console.WriteLine("press 3 to search a hotel");
                Console.WriteLine("press 4 to edit hotel info");
                Console.WriteLine("press 5 to show all hotels info");
                Console.WriteLine("press 6 to display residents in specific hotel");
                Console.WriteLine("press 7 to display all residents in all hotels");
                Console.WriteLine("press 8 to print all residents in all hotels to txt");
                Console.WriteLine("press 9 to logout from admin account");
                int i = Int32.Parse(Console.ReadLine());
                switch (i)
                {
                    
                    case 1:
                        Console.WriteLine("Hotel ID:");
                        hotelid = Console.ReadLine();
                        Console.WriteLine("Hotel name:");
                        hotelname = Console.ReadLine();
                        Console.WriteLine("Location:");
                        city = Console.ReadLine();
                        Console.WriteLine("Number of rooms:");
                        numofrooms = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Room price:");
                        roomprice = Double.Parse(Console.ReadLine());
                        Console.WriteLine("Stars:");
                        stars = Int32.Parse(Console.ReadLine());

                        hotellist.Add(new Hotel(hotelid, hotelname, city, numofrooms,roomprice, stars));                        
                        break;
                    case 2:
                        Console.WriteLine("Enter hotel index");
                        index = Int32.Parse(Console.ReadLine());
                        hotellist.RemoveAt(index);
                        break;
                    case 5:
                        foreach (var Hotel in hotellist)
                        {
                            Hotel.Info();
                        }
                        break;
                    case 6:
                        Console.WriteLine("Enter hotel index");
                        index = Int32.Parse(Console.ReadLine());
                        hotellist[index].PrintOccupiedRooms();
                        break;
                    case 7:
                        foreach (var Hotel in hotellist)
                        {
                            Hotel.PrintAllInfoOccupied();
                        }
                        break;
                    case 8:
                        foreach (var Hotel in hotellist)
                        {
                            Hotel.PrintAllInfoOccupiedtotxt();
                        }
                        break;
                    case 9:
                        loggedIn = false;
                        isAdmin = false;
                        break;
                }

            }
            //operations that a resident can do
            void userops()
            {
                int index=0, roomnum=0;
                string occupantname;
                Console.WriteLine("press 1 to reserve room");
                Console.WriteLine("press 5 to view all available rooms");
                Console.WriteLine("press 6 to view all hotels");
                Console.WriteLine("press 9 to logout from resident account");
                int i=Int32.Parse(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        Console.WriteLine("Enter hotel index");
                        index = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter room number");
                        roomnum = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Enter name of occupant");
                        Console.WriteLine("For multiple occupants spearate by comma");
                        occupantname = Console.ReadLine();
                        hotellist[index].BookRoom(roomnum,occupantname);
                        break;
                    case 5:
                        foreach (var Hotel in hotellist)
                        {
                            Hotel.PrintAvailableRooms();
                        }
                        break;
                    case 6:
                        foreach (var Hotel in hotellist)
                        {
                            Hotel.Info();
                        }
                        break;
                    case 9:
                        loggedIn = false;
                        break;
                }
            }
            //allows the user to login
            void login()
            {
                string uname, pass;
                Console.WriteLine("Please enter username");
                uname = Console.ReadLine();
                Console.WriteLine("Please enter password");
                pass = Console.ReadLine();

                foreach (var Admin in adminlist)
                {
                    if (Admin.Username == uname &&
                        Admin.Password == pass)
                    {
                        Console.WriteLine("Admin logged in");
                        loggedIn = true;
                        isAdmin = true;
                    }
                }
                foreach (var User in residentlist)
                {
                    if (User.Username == uname &&
                        User.Password == pass)
                    {
                        Console.WriteLine("User logged in");
                        loggedIn = true;
                    }
                }
                if (loggedIn == false)
                {
                    Console.WriteLine("Wrong username or password");
                }
            }
        }
    }
}