namespace NewApp.Models
{
    public class Person
    {
        //Khai báo thuộc tính
        public string FullName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

        //Khai báo phương thức (Nhập dữ liệu)
        public void EnterData()
        {
            System.Console.Write("FullName = ");
            FullName = Console.ReadLine();
            System.Console.Write("Address = ");
            Address = Console.ReadLine();
            System.Console.Write("Age = ");
            Age = Convert.ToInt16(Console.ReadLine());
        }
        //Khai báo phương thức tính năm sinh
        public int GetYearOfBirth(int age)
        {
            int yearOfBirth = 2023 - age;
            return yearOfBirth;
        }
        //Khai báo phương thức (Hiển thị dữ liệu)
        public void Display()
        {
            System.Console.WriteLine("{0} - {1} - {2} tuoi", FullName, Address, Age);
        }

    }
}