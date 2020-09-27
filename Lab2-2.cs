using System;
using System.Globalization;
using System.Threading;
namespace ConsoleApp36
{
   class MyTime
    {
        private static int sec;
        public static string lesson;
        public MyTime(int h, int m, int s)
        {


            hour = h;
            minute = m;
            second = s;


        }
        private int hour, minute, second;


        public int GetHour()
        {
            return hour;
        }
        public int GetMin()
        {
            return minute;
        }
        public int GetSecond()
        {
            return second;
        }
        public void SetHour(int value)
        {
            hour = value;
        }
        public void SetMin(int value)
        {
            minute = value;
        }
        public void SetSecond(int value)
        {
            second = value;
        }

        public override string ToString()
        {

            return String.Format("{0:00}:{1:00}:{2:00}", GetHour(), GetMin(), GetSecond());
        }
        private int SinceMidnight()
        {
            sec = GetHour() * 3600 + GetMin() * 60 + GetSecond();
            return sec;
        }
        private static MyTime TimeSinceMidnight()
        {
            int secPerDay = 60 * 60 * 24;
            int mysec;
            mysec = ((sec % secPerDay) + secPerDay) % secPerDay;
            int h = mysec / 3600;
            int m = (mysec / 60) % 60;
            int s = mysec % 60;
            MyTime mytime = new MyTime(h, m, s);
            return mytime;
        }
        private MyTime AddOneSecond()
        {

            if (GetSecond() == 59)
            {

                SetMin(GetMin() + 1);
                SetSecond(0);

            }
            MyTime time = new MyTime(hour,minute,second);
            return time;
        }
        private MyTime AddOneMinute()
        {
            if (GetMin() == 60)
            {
                SetHour(GetHour() + 1);
                SetMin(0);


            }
            MyTime time = new MyTime(hour, minute, second);
            return time;
        }
        private MyTime AddOneHour()
        {
            if (GetHour() == 24)
            {
                SetHour(0);
                SetMin(0);

            }
            MyTime time = new MyTime(hour, minute, second);
            return time;
        }
        private void AddSeconds()
        {
            AddOneSecond();
            AddOneMinute();
            AddOneHour();
            SetSecond(GetSecond() + 1);
        }
        public void Timer()
        {
            while (sec < 60 * 60 * 24)
            {

                Thread.Sleep(20);

                AddSeconds();

                SinceMidnight();
                TimeSinceMidnight();
                Console.Clear();
                Console.WriteLine(ToString());
                Console.WriteLine("sec " + sec);
                Console.WriteLine(WhatLesson());

            }
            Console.WriteLine("день закінчився");
        }
       private static string WhatLesson()
        {
            int slesson1 = 28800;
            int slesson2 = 35400;
            int slesson3 = 41400;
            int slesson4 = 46800;
            int slesson5 = 52800;
            int slesson6 = 58200;
            int ends = 63000;
            int sbreakten = 600;
            int sbreaktwenty = 1200;
            if (sec < slesson1)
            {
                lesson = "пари ще не почалися";

            }
            else if (sec >= slesson1 && sec < slesson2 - sbreakten)
            {
                lesson = "1 пара";

            }
            else if (sec >= slesson2 - sbreakten && sec < slesson2)
            {
                lesson = "перерва між 1 та 2 парою";

            }
            else if (sec >= slesson2 && sec < slesson3 - sbreaktwenty)
            {
                lesson = "2 пара";

            }
            else if (sec >= slesson3 - sbreaktwenty && sec < slesson3)
            {
                lesson = "перерва між 2 та 3 парою";

            }
            else if (sec >= slesson3 && sec < slesson4 - sbreakten)
            {
                lesson = "3 пара";

            }
            else if (sec >= slesson4 - sbreakten && sec < slesson4)
            {
                lesson = "перерва між 3 та 4 парою";

            }
            else if (sec >= slesson4 && sec < slesson5 - sbreaktwenty)
            {
                lesson = "4 пара";

            }
            else if (sec >= slesson5 - sbreaktwenty && sec < slesson5)
            {
                lesson = "перерва між 4 та 5 парою";

            }
            else if (sec >= slesson5 && sec < slesson6 - sbreakten)
            {
                lesson = "5 пара";

            }
            else if (sec >= slesson6 - sbreakten && sec < slesson6)
            {
                lesson = "перерва між 5 та 6 парою";

            }
            else if (sec >= slesson6 && sec < ends)
            {
                lesson = "6 пара";

            }
            else if (sec >= ends)
            {
                lesson = "пари закінчилися";

            }


            return lesson;
        }


    };
   public class Program
    {
     
        


        static void Main()
        {

            Console.WriteLine("Введіть години");
            int hours = int.Parse(Console.ReadLine());
           
            Console.WriteLine("Введіть хвилини");
            int minutes = int.Parse(Console.ReadLine());
           
            Console.WriteLine("Введіть секунди");
            int seconds = int.Parse(Console.ReadLine());
            MyTime time=new MyTime(hours,minutes,seconds);

            time.Timer();
            
        }
    }
}