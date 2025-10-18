using System;
namespace Project
{
    // Lớp phân số
    public class PhanSo
    {
        protected int tu, mau;
        // Contructor
        public PhanSo(int t = 0, int m = 1)
        {
            tu = t;
            mau = m;
        }
        //Hàm nhập 1 phân số
        public void Nhap()
        {
            Console.Write("Nhập tử số: ");
            while (!int.TryParse(Console.ReadLine(),out tu)){
                Console.WriteLine("Tử phải là số nguyên, hãy nhập lại!");
            }            
            Console.Write("Nhập mẫu số (≠ 0): ");
            while(!int.TryParse(Console.ReadLine(),out mau) || mau == 0) { 
                Console.WriteLine("Mẫu phải là số nguyên khác 0, hãy nhập lại!");
            }
            RutGon();
        }
        // Hàm xuất phân số
        public void Xuat()
        {
            if (mau == 0)
                Console.WriteLine("Phân số không hợp lệ (mẫu = 0)");
            else if (tu == 0)
                Console.WriteLine("0");
            else if (mau == 1)
                Console.WriteLine(tu.ToString());
            else if (mau < 0)
                Console.WriteLine($"{-tu}/{-mau}");
            else
                Console.WriteLine($"{tu}/{mau}");

        }

        // Hàm tìm ước chung lớn nhất
        static int Gcd(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            return b == 0 ? a : Gcd(b, a % b);
        }
        public double GiaTri()
        {
            return (double)tu / mau;
        }
        // Hàm rút gọn phân số
        public PhanSo RutGon()
        {
            int a = Gcd(tu, mau);
            tu /= a; mau /= a;
            return this;
        }
        //  Toán tử cộng
        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tu * b.mau + b.tu * a.mau, a.mau * b.mau).RutGon();
        }

        //  Toán tử trừ
        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tu * b.mau - b.tu * a.mau, a.mau * b.mau).RutGon();
        }

        //  Toán tử nhân
        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            return new PhanSo(a.tu * b.tu, a.mau * b.mau).RutGon();
        }

        //  Toán tử chia
        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
                if (b.tu == 0)
                {
                    throw new DivideByZeroException("Lỗi: Chia cho phân số bằng 0");
                }
                return new PhanSo(a.tu * b.mau, a.mau * b.tu).RutGon();
        }
    }
    public class Arr : PhanSo
    {
        private int n;
        private PhanSo[] arr;

        public Arr()
        {
            n = 0;
            arr = new PhanSo[0];
        }
        public void InputArr()
        {
            Console.Write("Nhập số lượng phân số: ");
            while (!int.TryParse(Console.ReadLine(),out n) || n<1){
                Console.WriteLine("Số lượng phải là số nguyên dương, nhập lại!");
            }

            arr = new PhanSo[n];

            Console.WriteLine("Nhập các phân số");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Phân số thứ {i + 1}:");
                arr[i] = new PhanSo();
                arr[i].Nhap();
            }
        }
        public void MaxPhanSo()
        {
            PhanSo max = arr[0];
            for (int i = 1; i < n; i++)
            {
                if (arr[i].GiaTri() > max.GiaTri())
                    max = arr[i];
            }
            Console.Write("Phân số lớn nhất là: ");
            max.Xuat();
        }
        public void OutputArr()
        {
            for (int i = 0; i < n; i++)
            {
                arr[i].Xuat();
            }
        }
        public void Arrange()
        {
            Array.Sort(arr, (a, b) => a.GiaTri().CompareTo(b.GiaTri()));
        }
        public static void Run()
        {
            Console.WriteLine("--------Chương trình quản lý phân số--------");
            Arr arr = new Arr();
            Console.WriteLine("Nhập 2 phân số: ");
            PhanSo a=new PhanSo();
            a.Nhap();
            PhanSo b=new PhanSo();
            b.Nhap();
            Console.WriteLine("Phân số thứ nhất: ");
            a.Xuat();
            Console.WriteLine("Phân số thứ hai: ");
            b.Xuat();
            Console.Write("Tổng 2 phân số là: ");
            (a + b).Xuat();
            Console.Write("Hiệu 2 phân số là: ");
            (a - b).Xuat();
            Console.Write("Tích 2 phân số là: ");
            (a * b).Xuat();
            Console.Write("Thương 2 phân số là: ");
            try
            {
                (a / b).Xuat();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine();
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Nhập mảng phân số:");
            arr.InputArr();
            Console.WriteLine("Mảng phân số vừa nhập:");
            arr.OutputArr();
            arr.MaxPhanSo();
            Console.WriteLine("Mảng phân số sau khi sắp xếp:");
            arr.Arrange();
            arr.OutputArr();
        }
    }




}
