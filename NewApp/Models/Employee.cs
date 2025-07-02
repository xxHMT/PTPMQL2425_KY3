namespace NewApp.Models
{
    public class Employee
    {
        //Khai báo 4 thuộc tính
        public string EmployeeID { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int Luong { get; set; }

        //Khai báo phương thức nhập dữ liệu
        public void EnterData()
        {
            System.Console.Write("EmployeeID = ");
            EmployeeID = Console.ReadLine();
            System.Console.Write("FullName = ");
            FullName = Console.ReadLine();
            System.Console.Write("Age = ");
            Age = Convert.ToInt16(Console.ReadLine());
            System.Console.Write("Luong = ");
            Luong = Convert.ToInt16(Console.ReadLine());
        }

        //Khai báo phuong thức hiển thị dữ liệu
        public void ExitData()
        {
            System.Console.WriteLine("Nhan vien {0} - {1} - {2} tuoi, co muc luong {3}", EmployeeID, FullName, Age, Luong);
        }
    }
}