using System;
namespace Project
{
    public class KhuDat
    {
        protected string DiaDiem;
        protected double DienTich;
        protected int GiaTien;
        public KhuDat(string diaDiem = "", double dienTich = 0, int giaTien = 0)
        {
            DiaDiem = diaDiem;
            DienTich = dienTich;
            GiaTien = giaTien;
        }
        public virtual void Nhap()
        {
            Console.Write("Nhập địa điểm: ");
            DiaDiem = Console.ReadLine() ?? "";
            Console.Write("Nhập diện tích (m2): ");
            while (!double.TryParse(Console.ReadLine(), out DienTich) || DienTich < 0)
            {
                Console.WriteLine("Diện tích không hợp lệ, hãy nhập lại!");
            }
            Console.Write("Nhập giá tiền (VNĐ): ");
            while (!int.TryParse(Console.ReadLine(), out GiaTien) || GiaTien < 0)
            {
                Console.WriteLine("Giá tiền không hợp lệ, hãy nhập lại!");
            }
        }
        public virtual void Xuat()
        {
            Console.WriteLine($"Địa điểm: {DiaDiem}");
            Console.WriteLine($"Diện tích: {DienTich} m2");
            Console.WriteLine($"Giá tiền: {GiaTien} VNĐ");
        }
        public double GetGiaTien()
        {
            return GiaTien;
        }
        public double GetDienTich()
        {
            return DienTich;
        }
        public string GetDiaDiem()
        {
            return DiaDiem;
        }
    }
    class NhaPho : KhuDat
    {
        /// <summary></summary>
        private int NamXayDung;
        private int SoTang;
        public NhaPho(string diaDiem = "", double dienTich = 0, int giaTien = 0, int namXayDung = 0, int soTang = 0)
            : base(diaDiem, dienTich, giaTien)
        {
            NamXayDung = namXayDung;
            SoTang = soTang;
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập năm xây dựng: ");
            while (!int.TryParse(Console.ReadLine(), out NamXayDung) || NamXayDung < 0)
            {
                Console.WriteLine("Năm xây dựng không hợp lệ, hãy nhập lại!");
            }
            Console.Write("Nhập số tầng: ");
            while (!int.TryParse(Console.ReadLine(), out SoTang) || SoTang < 0)
            {
                Console.WriteLine("Số tầng không hợp lệ, hãy nhập lại!");
            }
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Năm xây dựng: {NamXayDung}");
            Console.WriteLine($"Số tầng: {SoTang}");
        }
        public int GetNamXayDung()
        {
            return NamXayDung;
        }
    }
    public class ChungCu : KhuDat
    {
        private int Tang;
        public ChungCu(string diaDiem = "", double dienTich = 0, int giaTien = 0, int tang = 0)
            : base(diaDiem, dienTich, giaTien)
        {
            Tang = tang;
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhập tầng: ");
            while (!int.TryParse(Console.ReadLine(), out Tang) || Tang < 0)
            {
                Console.WriteLine("Tầng không hợp lệ, hãy nhập lại!");
            }
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine($"Tầng: {Tang}");
        }
    }
    public class QuanLyDanhSach
    {
        private int soLuong;
        private List<KhuDat> kd;
        private List<ChungCu> cc;
        private List<NhaPho> np;
        public QuanLyDanhSach()
        {
            soLuong = 0;
            kd = new List<KhuDat>();
            cc = new List<ChungCu>();
            np = new List<NhaPho>();
        }

        public KhuDat KhuDat
        {
            get => default;
            set
            {
            }
        }

        public ChungCu ChungCu
        {
            get => default;
            set
            {
            }
        }

        public NhaPho NhaPho
        {
            get => default;
            set
            {
            }
        }

        public void NhapDanhSach()
        {
            Console.Write("Nhập số lượng khu đất: ");
            while (!int.TryParse(Console.ReadLine(), out soLuong) || soLuong < 0)
            {
                Console.WriteLine("Số lượng không hợp lệ, hãy nhập lại!");
            }
            for (int i = 0; i < soLuong; i++)
            {
                Console.WriteLine($"Nhập thông tin khu đất thứ {i + 1}:");
                Console.WriteLine("Chọn loại khu đất (0 - Khu đất, 1 - Nhà phố, 2 - Chung cư): ");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2 && choice!=0))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập lại!");
                }
                if (choice == 0)
                {
                    KhuDat khuDat = new KhuDat();
                    khuDat.Nhap();
                    kd.Add(khuDat);
                }
                else if (choice == 1)
                {
                    NhaPho nhaPho = new NhaPho();
                    nhaPho.Nhap();
                    np.Add(nhaPho);
                }
                else
                {
                    ChungCu chungCu = new ChungCu();
                    chungCu.Nhap();
                    cc.Add(chungCu);
                }
            }
        }
        public void TongGiaBan3Loai()
        {
            Console.WriteLine("Tổng giá bán của 3 loại khu đất:");
            int tongKhuDat = 0;
            int tongNhaPho = 0;
            int tongChungCu = 0;
            foreach (var item in kd)
            {
                tongKhuDat += (int)item.GetGiaTien();
            }
            foreach (var item in np)
            {
                tongNhaPho += (int)item.GetGiaTien();
            }
            foreach (var item in cc)
            {
                tongChungCu += (int)item.GetGiaTien();
            }
            Console.WriteLine($"Tổng giá bán khu đất: {tongKhuDat} VNĐ");
            Console.WriteLine($"Tổng giá bán nhà phố: {tongNhaPho} VNĐ");
            Console.WriteLine($"Tổng giá bán chung cư: {tongChungCu} VNĐ");
        }
        public void XuatTheoYeuCau()
        {
            bool flag = true;
            Console.WriteLine("Khu đất có diện tích trên 100m2");
            foreach (var item in kd)
            {
                if (item.GetDienTich() > 100)
                {
                    flag = false;
                    item.Xuat();
                }
            }
            if (flag) Console.WriteLine("Không có khu đất nào");
            flag = true;
            Console.WriteLine("Nhà phố có diện tích trên 60m2 và xây dựng từ năm 2019");
            foreach (var item in np)
            {
                if (item.GetDienTich()  > 60 && item.GetNamXayDung()>=2019)
                {
                    item.Xuat();
                    flag = false;
                }
            }
            if (flag) Console.WriteLine("Không có nhà phố nào");
        }
        public void Search()
        {
            string diaDiemSearch;
            Console.Write("Nhập địa điểm cần tìm: ");
            diaDiemSearch = Console.ReadLine() ?? "";
            int GiaTienSearch;
            Console.Write("Nhập giá tiền cần tìm (VNĐ): ");
            while (!int.TryParse(Console.ReadLine(), out GiaTienSearch) || GiaTienSearch < 0)
            {
                Console.WriteLine("Giá tiền không hợp lệ, hãy nhập lại!");
            }
            int DienTichSearch;
            Console.Write("Nhập diện tích cần tìm (m2): ");
            while (!int.TryParse(Console.ReadLine(), out DienTichSearch) || DienTichSearch < 0)
            {
                Console.WriteLine("Diện tích không hợp lệ, hãy nhập lại!");
            }
            bool flag = true;
            Console.WriteLine("Danh sách chung cư tìm được: ");
            foreach (var item in cc)
            {
                if (item.GetDiaDiem() == diaDiemSearch && item.GetGiaTien() <= GiaTienSearch && item.GetDienTich() >= DienTichSearch)
                {
                    item.Xuat();
                    flag = false;
                }
            }
            if (flag) Console.WriteLine("Không tìm thấy chung cư nào");
            flag = true;
            Console.WriteLine("Danh sách nhà phố tìm được: ");
            foreach (var item in np)
            {
                if (item.GetDiaDiem() == diaDiemSearch && item.GetGiaTien() <= GiaTienSearch && item.GetDienTich() >= DienTichSearch)
                {
                    item.Xuat();
                    flag = false;
                }
            }
            if (flag) Console.WriteLine("Không tìm thấy nhà phố nào");
        }
        public static void Run()
        {
            Console.WriteLine("----- Quản Lý Danh Sách Khu Đất -----");
            QuanLyDanhSach ql = new QuanLyDanhSach();
            ql.NhapDanhSach();
            ql.TongGiaBan3Loai();
            ql.XuatTheoYeuCau();
            ql.Search();
            Console.WriteLine();
        }

    }
}