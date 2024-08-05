using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolDanhMuc
{
    public class Library
    {
        /// <summary>
        /// codetime_14
        /// 
        /// </summary>
        private static object lockObject = new object();
        private static int counter = 1;
        private static string previousHour = "";
        private static string previousSecond = "";
        private static string previousMinute = "";
        private static List<string> sequenceNumbers = new List<string>();

        //End codetime_14

        public static string hConvertDate(string inputDate)
        {
            // Chuyển chuỗi ngày vào kiểu DateTime
            DateTime date = DateTime.Parse(inputDate);

            // Định dạng lại chuỗi ngày theo định dạng "yyyyMMdd"
            string convertedDate = date.ToString("yyyyMMdd");
            return convertedDate;
        }

        public static string hgetCodeTime_14()
        {
            lock (lockObject)
            {
                //Task.Delay(100);
                DateTime now = DateTime.Now;
                string currentHour = now.ToString("HH");
                string currentSecond = now.ToString("ss");
                string currentMinute = now.ToString("mm");

                // Kiểm tra xem giá trị HH đã thay đổi hay chưa
                if (currentMinute != previousMinute)
                {
                    // Xóa danh sách chuỗi số
                    sequenceNumbers.Clear();
                    counter = 1;
                    previousHour = currentHour;
                    previousSecond = currentSecond;
                    previousMinute = currentMinute;
                }
                string chuoi = "00" + counter.ToString();
                string haiChuSoCuoi = chuoi.Substring(chuoi.Length - 2);
                string sequenceNumber = now.ToString("yyMMddHHmmss") + haiChuSoCuoi;

                // Kiểm tra chuỗi số đã tồn tại trong danh sách hay chưa
                while (sequenceNumbers.Contains(sequenceNumber))
                {
                    counter = (counter + 1) % 100;
                    chuoi = "00" + counter.ToString();
                    haiChuSoCuoi = chuoi.Substring(chuoi.Length - 2);
                    sequenceNumber = now.ToString("yyMMddHHmmss") + haiChuSoCuoi;
                }

                // Thêm chuỗi số vào danh sách
                sequenceNumbers.Add(sequenceNumber);

                return sequenceNumber;
            }
        }

    }
}
