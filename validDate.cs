using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPro
{
    internal class Class4
    {
        public static bool Valid()
        {
            Console.WriteLine("enter th year Btw 2000 and 2050");
            int year =int.Parse(Console.ReadLine());
            Console.WriteLine("enter the Month Btw 1 and 12");
            int month =int.Parse(Console.ReadLine());
            Console.WriteLine("enter the days from 1 and 31");
            int day=int .Parse(Console.ReadLine());
            if(year <2000 || year > 2050)
            {
                Console.WriteLine("invalid year");
                return false;

            }
            if(month <1 || month > 12)
            {
                Console.WriteLine("invalid month");
                return false;
            }
            if(day <1 || day > 31) 
            {
                Console.WriteLine("invalid day");
                return false;
            }
            Console.WriteLine($"the date {month}/{day}/{year} is valid ");
            return true;
        }
    }
}

// sorry to infrom this sir i searched all the files and folders in the github but i couldent find the assignments of the web app 
