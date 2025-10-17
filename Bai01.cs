using System;
namespace Project
{
    // Lớp ngày tháng năm
    public class Date
    {
        // thuộc tính tháng, năm
        protected int month, year;
        // contructor
        public Date(int m = 1, int y = 2025)
        {
            month = m;
            year = y;
        }
        // Hàm đếm số ngày trong tháng
        public int Count()
        {
            if (month < 1 || month > 12) return -1;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                    {
                        return 29;
                    }
                    else
                    {
                        return 28;
                    }
            }
            return -1;
        }
        //Hàm kiểm trả ngày hợp lệ
        public bool check()
        {
            return (month > 0 && month < 13);
        }

        //Hàm tính thứ trong tuần theo công thức zeller
        public int DayInWeekZeller()
        {
            int mon = month;
            int yr = year;
            // Nếu là tháng 1 hoặc 2 thì tính thành tháng 13, 14 của năm trước
            if (mon == 1)
            {
                mon = 13;
                yr--;
            }
            else if (mon == 2)
            {
                mon = 14;
                yr--;
            }

            int q = 1;
            int m = mon;
            int K = yr % 100;   // năm trong thế kỷ
            int J = yr / 100;   // thế kỷ

            int h = (q + (13 * (m + 1)) / 5 + K + K / 4 + J / 4 + 5 * J) % 7;


            return h;
        }
        // Hàm in lịch
        public void Print()
        {
            Console.WriteLine("Sun\tMon\tTue\tWed\tThu\tFri\tSat");
            int day = DayInWeekZeller();
            if (day == 0) day = 7;
            for (int i = 1; i < day; i++)
            {
                Console.Write("\t");
            }
            for (int i = 1; i <= this.Count(); i++)
            {
                Console.Write(i + "\t");
                if (day % 7 == 0)
                {
                    Console.WriteLine();
                }
                day++;
            }
            Console.WriteLine();
        }
        // Hàm nhập
        public void Input()
        {
            Console.WriteLine("Nhập vào một tháng trong năm");
            while (!int.TryParse(Console.ReadLine(), out month))
            {
                Console.WriteLine("Bạn nhập sai định dạng, hãy nhập lại");
            }
            Console.WriteLine("Nhập vào một năm");
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.WriteLine("Bạn nhập sai định dạng, hãy nhập lại");
            }
        }

        public static void Run()
        {
            Console.WriteLine("Chương trình xử lý ngày tháng năm");
            Date date = new Date();
            date.Input();
            if (date.check())
            {
                date.Print();
            }
            else
            {
                Console.WriteLine("Bạn nhập không hợp lệ");
            }
        }
    }
}
