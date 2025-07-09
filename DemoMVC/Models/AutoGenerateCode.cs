using DemoMvc.Data;

namespace DemoMVC.Models
{
    public class AutoGenerateCode
    {
        private readonly ApplicationDbContext _context;
        public AutoGenerateCode(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public string GenerateCode(string lastcode)
        {
            //kiem tra xem db co ban ghi nao lastcode chua neu chua bat dau tu 001
            if (string.IsNullOrEmpty(lastcode))
            {
                return "001";
            }
            //chuyen doi chuoi thanh so nguyen va + 1
            int num = Convert.ToInt32(lastcode.Substring(4)) + 1;
            //tra ve mahtpp theo dinh dang HTPP+ 3so
            return "HTTP" + num.ToString("D3");
        }
        
    }
}