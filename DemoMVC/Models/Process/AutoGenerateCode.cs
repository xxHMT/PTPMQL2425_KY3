
namespace DemoMVC.Models.Process
{
    public class AutoGenerateCode
    {
        public string GenerateID(string inputID, int prefixLength)
        {
            string strOutput = "";
            //lay phan text cua inputid
            string prefix = inputID.Substring(0, prefixLength);
            //lay phan so cua inputid
            string numberPart = inputID.Substring(prefixLength);
            //chuyen so thanh so nguyen
            int number = int.Parse(numberPart);
            //tang so len 1 don vi
            number++;
            //chuyen so thanh chuoi
            strOutput = prefix + number.ToString();
            return strOutput;
        }
        public string GenerateID(string inputID)
        {
            var match = System.Text.RegularExpressions.Regex.Match(inputID, @"^(?<prefix>[A-Za-z]+)(?<number>\d+)$");
            if (!match.Success)
            {
                throw new ArgumentNullException("Invalid id format");
            }

            string prefix = match.Groups["prefix"].Value;
            //STD
            string numberPart = match.Groups["number"].Value;
            //007
            int number = int.Parse(numberPart) + 1;
            //8
            string newNumberPart = number.ToString().PadLeft(numberPart.Length, '0');
            //STD008
            return prefix + numberPart.ToString();  
        }
    }   
}
    