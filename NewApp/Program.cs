// See https://aka.ms/new-console-template for more information
using NewApp.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        ///VD 1:
        // Console.Write("Nhập vào dữ liệu: ");
        // int a = Console.Read();
        // Console.WriteLine("Dữ liệu vừa nhập vào là " + a);

        ///VD 2:
        // Console.Write("Nhap vao du lieu: ");
        // string str = Console.ReadLine();
        // Console.WriteLine("Du lieu vua nhap vao la: " + str);

        ///VD 3:
        //Khai báo biến họ tên kiểu string và gán giá trị
        // string HoTen = "Hoang Van A";
        //Khai báo biến tuổi kiểu int và gán giá trị
        // int Tuoi = 22;
        // Console.WriteLine("Thi sinh {0} - {1} tuoi?", HoTen, Tuoi);

        ///VD 4:
        // const string HoTen = "Hoang Van A";
        // const int namHoc = 4;
        // Console.WriteLine("Sinh vien {0} la sinh vien nam {1}", HoTen, namHoc);

        ///VD 5: Chuyển đổi kiểu dữ liệu
        // string str = "123";
        // int a = Convert.ToInt32(str); // Chuyển đổi kiểu dữ liệu string sang kiểu int
        // System.Console.WriteLine("a = " + a);

        ///VD 6: 
        /// Khởi tạo 2 đối tượng từ class person
        // Person ps1 = new Person();
        // Person ps2 = new Person();
        // Person ps = new Person();
        //Gán giá trị cho thuộc tính đối tượng person 1
        // string name = "Hoang Van A";
        // string adrs = "HN";
        // int a = 22;

        //Gọi phương thức hiển thị thông tin
        // ps1.Display();

        // Console.WriteLine("{0} - {1} sinh nam {2}", name, adrs, ps.GetYearOfBirth(a));

        Student std = new Student();
        std.EnterData();
        std.Display();
    }
}
