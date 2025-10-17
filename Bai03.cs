using System;
//3.Xây dựng chương trình có chức năng
//a. Nhập / xuất ma trận hai chiều các số nguyên
//b. Tìm kiếm một phần tử trong ma trận
//c. Xuất các phần tử là số nguyên tố
//d. Cho biết dòng nào có nhiều số nguyên tố nhất
namespace Project
{
    class Matrix
    {
        int m, n;   // Số hàng và cột
        int[,] matrix;  //Ma trận 2 chiều 
        public Matrix()     //Contructor
        {
            m=0; n = 0;
            matrix = new int[0,0];
        }
        public void Input()   //hàm nhập ma trận
        {
            Console.WriteLine("Nhập số hàng của ma trận");
            while (!int.TryParse(Console.ReadLine(), out m)){
                Console.WriteLine("Số hàng không hợp lệ, hãy nhập lại");
            }
            Console.WriteLine("Nhập số cột của ma trận");
            while (!int.TryParse(Console.ReadLine(), out n)){
                Console.WriteLine("Số cột không hợp lệ, hãy nhập lại");
            }
            matrix = new int[m, n];
            Console.WriteLine("Nhập ma trận");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    while (!int.TryParse(Console.ReadLine(), out matrix[i,j]))
                    {
                        Console.Write("Phần tử không hợp lệ, hãy nhập lại");
                    }
                }
            }
        }
        public void Output() //hàm xuất ma trận
        {
            Console.WriteLine("Ma trận");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                   Console.Write(matrix[i,j]+" ");
                }
                Console.WriteLine();
            }
        }
        public void Search() // Hàm tìm kiếm phần tử trong ma trận
        {
            int x;
            Console.WriteLine("Nhập phần tử cần tìm kiếm");
            while(!int.TryParse(Console.ReadLine(),out x))
            {
                Console.WriteLine("Nhập sai định dạng, hãy nhập lại");
            }
            bool found = false;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == x)
                    {
                        Console.WriteLine($"Vị trí của {x} trong mảng là {i}, {j}");
                        found = true;
                    }
                        
                }
            }
            if(!found)
                Console.WriteLine($"Không tìm thấy phần tử {x} trong ma trận");
        }
        public bool isPrime(int x) // Hàm kiểm tra số nguyên tố
        {
            if (x < 2) return false;
            for (int i = 2; i <= Math.Sqrt(x); i++)
            {
                if (x % i == 0)
                    return false;
            }
            return true;
        }
        public void OutputPrimes() // Hàm xuất các phần tử là số nguyên tố
        {
            Console.WriteLine("Các phần tử là số nguyên tố trong ma trận:");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (isPrime(matrix[i, j]))
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                }
            }
            Console.WriteLine();
        }
        public void RowWithMostPrimes() // Hàm cho biết dòng nào có nhiều số nguyên tố nhất
        {
            int maxCount = 0;
            int rowIndex = -1;
            for (int i = 0; i < m; i++)
            {
                int count = 0;
                for (int j = 0; j < n; j++)
                {
                    if (isPrime(matrix[i, j]))
                    {
                        count++;
                    }
                }
                if (count > maxCount)
                {
                    maxCount = count;
                    rowIndex = i;
                }
            }
            if (rowIndex != -1)
            {
                Console.WriteLine($"Dòng {rowIndex} có nhiều số nguyên tố nhất với {maxCount} số nguyên tố.");
            }
            else
            {
                Console.WriteLine("Không có số nguyên tố trong ma trận");
            }
        }
        public static void Run()
        {
            Matrix matrix=new Matrix();
            Console.WriteLine("-------Chương trình xử lý ma trận-------\n" +                              
                              "Nhấn 0 để Thoát\n" +
                              "Nhấn 1 để nhập ma trận\n" +
                              "Nhấn 2 để xuất ma trận\n" +
                              "Nhấn 3 để tìm kiếm một phần tử trong ma trận\n" +
                              "Nhấn 4 để xuất các phần tử là số nguyên tố\n" +
                              "Nhấn 5 để biết dòng nào chứa nhiều số nguyên tố nhất\n"+
                              "Mời bạn chọn chức năng");
            int choice;
            do
            {
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Bạn nhập sai định dạng, hãy nhập lại");
                }
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bạn đã thoát chương trình");
                        break;
                    case 1:
                        matrix.Input();
                        break;
                    case 2:
                        matrix.Output();
                        break;
                    case 3:
                        matrix.Search();
                        break;
                    case 4:
                        matrix.OutputPrimes();
                        break;
                    case 5:
                        matrix.RowWithMostPrimes();
                        break;
                    default:
                        Console.WriteLine("Chức năng không hợp lệ, hãy chọn lại");
                        break;
                }
            } while (choice != 0);
        }
    }
}