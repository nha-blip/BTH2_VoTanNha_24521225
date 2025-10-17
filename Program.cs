using System;
using System.Text;
namespace Project
{
    class MainProgram
    {
        static void Main()
        {
            int choice;
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            do
            {
                Console.WriteLine("Chương trình bao gồm các bài tập sau:");
                Console.WriteLine("0. Thoát chương trình");
                Console.WriteLine("1. Xử lý ngày tháng năm");
                Console.WriteLine("2. Quản lý thư mục");
                Console.WriteLine("3. Xử lý ma trận");
                Console.WriteLine("4. Quản lý phân số");
                Console.WriteLine("5. Quản lý khu đất");
                Console.WriteLine("Mời bạn chọn");
                
                while (!int.TryParse(Console.ReadLine(), out choice)) {
                    Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập lại!");
                }
                switch (choice)
                {
                    case 1:
                        Date.Run();
                        break;
                    case 2:
                        Bai02.Run();
                        break;
                    case 3:
                        Matrix.Run();
                        break;
                    case 4:
                        Arr.Run();
                        break;
                    case 5:
                        QuanLyDanhSach.Run();
                        break;
                }
            } while (choice != 0);
            
        }
    }
}
