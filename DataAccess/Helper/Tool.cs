using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Helper
{
    public partial class Tool
    {
        public string RandomText(int length)
        {

            // Dãy ký tự chứa tất cả các ký tự a-z và các chữ số 0-9
            string characters = "abcdefghijklmnopqrstuvwxyz0123456789";

            // Khởi tạo đối tượng ngẫu nhiên
            Random random = new Random();

            // Sử dụng StringBuilder để tạo chuỗi ngẫu nhiên hiệu quả hơn
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                // Chọn một ký tự ngẫu nhiên từ dãy ký tự
                int index = random.Next(characters.Length);

                // Thêm ký tự đã chọn vào chuỗi kết quả
                result.Append(characters[index]);
            }

            string randomString = result.ToString();
            return randomString;
        }
    }
}
