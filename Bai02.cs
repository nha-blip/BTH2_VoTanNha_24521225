using System;
using System.IO;
namespace Project 
{ 
    public class Bai02
    {
        public static void Run()
        {
            // Nhâp tên thưu mục
            Console.WriteLine("Nhập đường dẫn thư mục");
            string Path = Console.ReadLine() ?? "";
            while(string.IsNullOrEmpty(Path))
            {
                Console.WriteLine("Đường dẫn không được để trống, vui lòng nhập lại!");
                Path = Console.ReadLine() ?? "";
            }
            DirectoryInfo Dir = new DirectoryInfo(Path); // Tạo đối tượng thư mục
            if (Path != "" && Directory.Exists(Path))        //Kiểm tra đường dẫn không rỗng và tồn tại
            {
                FileInfo[] str = Dir.GetFiles();    // Lấy file trong đường dẫn
                DirectoryInfo[] dic = Dir.GetDirectories();  //Lấy thư mục con
                if (str.Length != 0)                        // Nếu số lượng file lớn hơn 0
                {
                    foreach (FileInfo str2 in str)            // In danh sách file
                    {
                        Console.WriteLine($"{str2.CreationTime}\t\t{str2.Name}{str2.Extension}");
                    }
                }
                else
                    Console.WriteLine("Không có file nào trong thư mục");
                if (dic.Length != 0)                        // In danh sách thư mục con
                {
                    foreach (DirectoryInfo str3 in dic)
                        Console.WriteLine($"{str3.CreationTime}\t<dir>\t{str3.Name}");
                }
                else
                    Console.WriteLine("Không có thư mục con trong thư mục");
            }
            else
                Console.WriteLine("Không tìm thấy thư mục");
        }
    }
}
