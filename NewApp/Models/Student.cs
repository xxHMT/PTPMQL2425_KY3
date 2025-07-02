namespace NewApp.Models
{
    public class Student : Person
    {
        public string StudentCode { get; set; }

        public void EnterData()
        {
            //Kế thừa lại phương thức ở class Person
            base.EnterData();
            //Thêm phương thức nhập mã sinh viên
            System.Console.Write("StudentCode = ");
            StudentCode = Console.ReadLine();
        }
        public void Display()
        {
            //Kế thừa phương thức
            base.Display();
            System.Console.Write("- Ma sinh vien: {0}", StudentCode);
        }
    }
    }