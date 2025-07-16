using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.WebRequestMethods;

namespace DemoMVC.Models.Entities
{
    public class DaiLy
    {
        [Key]
        [Display(Name = "Mã Đại Lý")]
        public string MaDaiLy { get; set; }
        [Display(Name = "Tên Đại Lý")]
        public string TenDaiLy { get; set; }
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }
        [Display(Name = "Người Đại Diện")]
        public string NguoiDaiDien { get; set; }
        [Display(Name = "Số Điện Thoại")]
        public string DienThoai { get; set; }
        [ForeignKey("MaHTPP")]
        [Display(Name = "Mã HTPP")]
        public string? MaHTPP { get; set; }
        [ForeignKey("MaHTPP")]
        public HeThongPhanPhoi? HTPP { get; set; }
    }
}