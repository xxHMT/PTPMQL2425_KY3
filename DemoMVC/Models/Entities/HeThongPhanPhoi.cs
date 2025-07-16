using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoMVC.Models.Entities
{
    public class HeThongPhanPhoi
    {
        [Key]
        [Display(Name = "Mã HTPP")]
        public string MaHTPP { get; set; }
        [Display(Name = "Tên HTPP")]
        public string TenHTPP { get; set; }
        public ICollection<DaiLy>? DaiLy { get; set; }
    }
}