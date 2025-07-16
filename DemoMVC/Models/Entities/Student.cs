using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models.Entities
{
    public class Student
    {
        [Display(Name = "Mã sinh viên")]
        public string StudentID { get; set; }
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; }
        [Display(Name ="Địa chỉ")]
        public string Address { get; set; }
    }
}