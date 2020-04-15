using System;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**Day Predictor**");

            Console.Write("Enter year:");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter month:");
            int month = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter day:");
            int day = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(year + "/" + month + "/" + day + " is a " + GetDay(year, month, day));
        }

        static string GetDay(int year, int month, int day)
        {
            int yearIndex, monthIndex = 0, dayIndex;

            //calculating number of days till the previous year
            yearIndex = (year - 1) * 365 + (year - 1) / 4 - (year - 1) / 100 + (year - 1) / 400;
            
            for(int i = 1; i < month; i++)
            {
                monthIndex += 30;

                if((i <= 7 && i % 2 == 1) || (i > 7 && i % 2 == 0)) //months with 31 days
                {
                    monthIndex++;
                }

                if(i == 2)                      //february
                {
                    monthIndex -= 2;

                    if(year % 4 == 0)
                    {
                        monthIndex++;
                        if(year % 100 == 0)
                        {
                            monthIndex--;

                            if(year % 400 == 0)
                            {
                                monthIndex++;
                            }
                        }
                    }
                    
                }
            }
            
            dayIndex = (yearIndex + monthIndex + day) % 7;

            string dayName = "this";    //not assigning a value leads to error

            switch (dayIndex)
            {
                case 0:
                dayName = "Sunday";
                break;

                case 1:
                dayName = "Monday";
                break;

                case 2:
                dayName = "Tueday";
                break;

                case 3:
                dayName = "Wednesday";
                break;

                case 4:
                dayName = "Thursday";
                break;

                case 5:
                dayName = "Friday";
                break;

                case 6:
                dayName = "Satday";
                break;
            }

            return dayName;
        }
    }
}
