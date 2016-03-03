using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Globalization;
using System.Windows.Forms;
using System.Threading;

namespace Algorithm
{
    class Algorithm
    {

        //Searching Algorithms
        public static int Linear_Search(double searchNumber, double[] searchArray)
        {
            int position = 0;

            foreach (double i in searchArray)
            {
                position++;
                if (i == searchNumber)
                {
                    Console.WriteLine("\n\nDATE        OPEN       CLOSE       DIFFERENCE       VOLUME");
                    Console.WriteLine("────────────────────────────────────────────────────────────────");
                    int location = Convert.ToInt32(position);
                    var myValue = dayToDouble.FirstOrDefault(x => x.Value == Days[location]).Key;
                    
                    
                    Console.Write("{0}", Dates[location].ToString("dd/MM/yyyy"));
                    Console.Write("  {0}", SH1_Open[location]);
                    Console.Write("      {0}", SH1_Close[location]);
                    Console.Write("        {0}", SH1_Diff[location]);
                    Console.Write("            {0}", SH1_Volume[location]);
                    
                }
            }
                        
            return position;
        }

        public static int Linear_Search_Dates(DateTime searchDate, DateTime[] searchArray)
        {
            int position = -1;

            for (int i = 0; i < (searchArray.Length - 1); i++)
            {
                if (searchDate == searchArray[i])
                {
                    position = i;
                    break;
                }
            }
            return position;
        }

        // Sorting Algorithms
        public static void Quick_Sort<T>(T[] data, int left, int right)
        where T : IComparable<T>
        {
            T temp;
            int i, j;
            T pivot;
            i = left;
            j = right;
            pivot = data[(left + right) / 2];
            do
            {
                while ((data[i].CompareTo(pivot) < 0) && (i < right)) i++;
                while ((pivot.CompareTo(data[j]) < 0) && (j > left)) j--;
                if (i <= j)
                {
                    temp = data[i];
                    data[i] = data[j];
                    data[j] = temp;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (left < j) Quick_Sort(data, left, j);
            if (i < right) Quick_Sort(data, i, right);
        }

        //Day sorting
        public static Dictionary<string, double> dayToDouble = new Dictionary<string, double>()
          
            {

    { "Monday", 0.0 },
    { "Tuesday", 1.0 },
    { "Wednesday", 2.0 },
    { "Thursday", 3.0 },
    { "Friday", 4.0 },
    { "Saturday", 5.0 },
    { "Sunday", 6.0 }
            
            };
        public static double[] Days = new double[999];
        public static DateTime[] Dates = new DateTime[999];
        public static double[] SH1_Open = new double[999];
        public static double[] SH1_Close = new double[999];
        public static double[] SH1_Diff = new double[999];
        public static double[] SH1_Volume = new double[999];


        // Main Sections
        static void Main()
        {

            //Read text files 
            string[] Day = System.IO.File.ReadAllLines("Day.txt");
            string[] Date = System.IO.File.ReadAllLines("Date.txt");
            string[] _Open = System.IO.File.ReadAllLines("SH1_Open.txt");
            string[] _Close = System.IO.File.ReadAllLines("SH1_Close.txt");
            string[] _Diff = System.IO.File.ReadAllLines("SH1_Diff.txt");
            string[] _Volume = System.IO.File.ReadAllLines("SH1_Volume.txt");

            Dictionary<double, string> doubleToDay =
            dayToDouble.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);

            //Conversions
            Days = Day.Select(day => dayToDouble[day]).ToArray();
            Dates = Array.ConvertAll(Date, s => DateTime.Parse(s));
            SH1_Open = Array.ConvertAll(_Open, s => double.Parse(s));
            SH1_Close = Array.ConvertAll(_Close, s => double.Parse(s));
            SH1_Diff = Array.ConvertAll(_Diff, s => double.Parse(s));
            SH1_Volume = Array.ConvertAll(_Volume, s => double.Parse(s));

            //Start of Application
            Console.WriteLine("\nWelcome to Shane Porter's Algorithms and Complexity Assingment!\n\nWhat would you like to do?");
            Console.WriteLine("\n1. Select an individual array to analyse\n\n2. View by a Date\n\n3. View by a Day");

            int Choice = Convert.ToInt32(Console.ReadLine());

            //Option 1. Individual Array
            if (Choice == 1)
            {
                Console.WriteLine("\nYou have chosen to select an individual array to analyse");
                Console.WriteLine("\nPlease select the array that you wish to analyse");
                Console.WriteLine("\n1. Day\n2. Date\n3. SH1_Open\n4. SH1_Close\n5. SH1_Diff\n6. SH1_Volume ");

                int ArrayChoice = Convert.ToInt32(Console.ReadLine());


                //Day
                if (ArrayChoice == 1)
                {
                    Quick_Sort(Days, 0, 143);
                    foreach (double dayValue in Days)
                    {
                        Console.WriteLine(doubleToDay[dayValue]);
                    }

                    Console.WriteLine("\n\nPress R to restart!");
                    System.ConsoleKeyInfo Restart = Console.ReadKey();
                    if ((Restart.KeyChar == 'r') || (Restart.KeyChar == 'R'))
                    {
                        Application.Restart();
                    }
                }

               //Dates
                else if (ArrayChoice == 2)
                {
                    Quick_Sort(Dates, 0, 143);
                    for (int i = 0; i < Dates.Length; i++)
                    {
                        Console.WriteLine(Dates[i].ToString("dd/MM/yyyy"));
                    }

                    Console.WriteLine("\n\nPress R to restart!");
                    System.ConsoleKeyInfo Restart = Console.ReadKey();
                    if ((Restart.KeyChar == 'r') || (Restart.KeyChar == 'R'))
                    {
                        Application.Restart();
                    }
                }

                //SH1_Open
                else if (ArrayChoice == 3)
                {
                    Quick_Sort(SH1_Open, 0, 143);
                    for (int i = 0; i < SH1_Open.Length; i++)
                    {
                        Console.WriteLine(SH1_Open[i]);
                    }

                    Console.WriteLine("\n\nPress R to restart!");
                    System.ConsoleKeyInfo Restart = Console.ReadKey();
                    if ((Restart.KeyChar == 'r') || (Restart.KeyChar == 'R'))
                    {
                        Application.Restart();
                    }

                }

                //SH1_Close
                else if (ArrayChoice == 4)
                {
                    Quick_Sort(SH1_Close, 0, 143);
                    for (int i = 0; i < SH1_Close.Length; i++)
                    {
                        Console.WriteLine(SH1_Close[i]);
                    }

                    Console.WriteLine("\n\nPress R to restart!");
                    System.ConsoleKeyInfo Restart = Console.ReadKey();
                    if ((Restart.KeyChar == 'r') || (Restart.KeyChar == 'R'))
                    {
                        Application.Restart();
                    }

                }

               //SH1_Diff
                else if (ArrayChoice == 5)
                {
                    Quick_Sort(SH1_Diff, 0, 143);
                    for (int i = 0; i < SH1_Diff.Length; i++)
                    {
                        Console.WriteLine(SH1_Diff[i]);
                    }

                    Console.WriteLine("\n\nPress R to restart!");
                    System.ConsoleKeyInfo Restart = Console.ReadKey();
                    if ((Restart.KeyChar == 'r') || (Restart.KeyChar == 'R'))
                    {
                        Application.Restart();
                    }

                }

                //SH1_Volume
                else if (ArrayChoice == 6)
                {
                    Quick_Sort(SH1_Volume, 0, 143);
                    for (int i = 0; i < SH1_Volume.Length; i++)
                    {
                        Console.WriteLine(SH1_Volume[i]);
                    }

                    Console.WriteLine("\n\nPress R to restart!");
                    System.ConsoleKeyInfo Restart = Console.ReadKey();
                    if ((Restart.KeyChar == 'r') || (Restart.KeyChar == 'R'))
                    {
                        Application.Restart();
                    }

                }

            }
            // Option 2. Search for a Date
            else if (Choice == 2)
            {
                Console.WriteLine("\nYou have chosen to view by date");
                Console.WriteLine("\n\nPlease enter the date that you wish to search for in this format\ndd/MM/yyyy");
                Console.WriteLine("──────────");


                DateTime enteredDate = Convert.ToDateTime(Console.ReadLine());
                int location = Linear_Search_Dates(enteredDate, Dates);
                var myValue = dayToDouble.FirstOrDefault(x => x.Value == Days[location]).Key;
                Console.WriteLine("\n\nDAY       DATE        OPEN       CLOSE       DIFFERENCE       VOLUME");
                Console.WriteLine("───────────────────────────────────────────────────────────────────────");
                Console.Write(myValue);
                Console.Write("  {0}", Dates[location].ToString("dd/MM/yyyy"));
                Console.Write("  {0}", SH1_Open[location]);
                Console.Write("      {0}", SH1_Close[location]);
                Console.Write("        {0}", SH1_Diff[location]);
                Console.Write("            {0}", SH1_Volume[location]);
                Console.ReadLine();
            }

             // Option 2. Search for a Day
            else if (Choice == 3)
            {
                Console.WriteLine("\nYou have chosen to view by day");
                Console.WriteLine("\nPlease enter the day that you wish to search for");
                Console.WriteLine("Enter 1 for Monday\nEnter 2 for Tuesday\nEnter 3 for Wednesday\nEnter 4 for Thursday\nEnter 0 for Friday\nEnter 6 for Saturday");
                Console.WriteLine("\nIf only one result displays\npress ENTER after the each result displays to display the next result");

                double enteredDays = Convert.ToDouble(Console.ReadLine());
                int location = Linear_Search(enteredDays, Days);
                Console.ReadLine();
                

            }
        }
    }
}

