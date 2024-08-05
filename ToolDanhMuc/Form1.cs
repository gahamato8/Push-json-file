using hDataLibraryNF;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static ToolDanhMuc.Data;
using static ToolDanhMuc.Library;
using hUltiLibraryNF;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace ToolDanhMuc
{
    public partial class Form1 : Form
    {
        private Data.JsonReader jsonReader;
        private static readonly string LoginID_School_Dev = PN_LoginService.LoginID_Index;
        public Form1()
        {
            InitializeComponent();
            jsonReader = new Data.JsonReader();
        }

        private void btnTool_Click(object sender, EventArgs e)
        {
            try
            {
                string jsonFilePath = @"D:\Cty_Funa_Titkul\tailieucty\DANHMUC\Get_DMHuyen.json";
                //string jsonFilePath = @"D:\Cty_Funa_Titkul\tailieucty\DANHMUC\Get_DMKhuVuc.json";
                string jsonString = File.ReadAllText(jsonFilePath);

                JObject jsonObject = JObject.Parse(jsonString);
                JArray jArray = (JArray)jsonObject["DATA"];
                List<DanhMuc> dataList = jArray.ToObject<List<DanhMuc>>();
                //int j = 1;
                //SaveDanhMuc(dataList);
                SaveDataDanhMuc(dataList);
                int j = 1;
                //foreach (var item in dataList)
                //{
                txtTool.Text = j.ToString();
                j++;
                Application.DoEvents();
                //}
                MessageBox.Show("Data successfully inserted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private void SaveDataDanhMuc(List<DanhMuc> dataList)
        {
            var batchSize = 200;
            int rowCounter = 0;
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO public.l_dmhuyen(code, ma_huyen, ma_tinh, ten_huyen)VALUES");
            for (int i = 0; i < dataList.Count; i++)
            {
                if (rowCounter > 0)
                {
                    sql.Append(",");
                }
                sql.Append($"('{hgetCodeTime_14()}','{dataList[i].MA_HUYEN}','{dataList[i].MA_TINH}','{dataList[i].TEN_HUYEN}')");
                rowCounter++;
                if (rowCounter > 0 && (rowCounter % batchSize == 0))
                {
                    hdataLib.hrunQuery(LoginID_School_Dev, sql.ToString());
                    sql.Clear();
                    sql.Append("INSERT INTO public.l_dmhuyen(code, ma_huyen, ma_tinh, ten_huyen)VALUES");
                    rowCounter = 0;
                }
            }
            if (rowCounter > 0)
            {
                hdataLib.hrunQuery(LoginID_School_Dev, sql.ToString());
            }
            Console.WriteLine("Dữ liệu đã được lưu vào bảng DanhMuc trong cơ sở dữ liệu PostgreSQL.");

            //sql.Append("INSERT INTO public.l_dmkhuvuc(code, ma, ten)VALUES");

        }
        //Cơ Bản
        private void SaveDanhMuc(List<DanhMuc> dataList)
        {
            //string sql = "INSERT INTO public.l_dmhuyen(code, ma_huyen, ma_tinh, ten_huyen)VALUES(@Code,@MA_HUYEN,@MA_TINH,@TEN_HUYEN)";
            string sql = "INSERT INTO public.l_dmkhuvuc(code, ma, ten)VALUES(@Code,@Ma,@Ten)";
            using (var connection = Data.hgetConnection("hd_index"))
            {
                using (var cmd = new NpgsqlCommand(sql, connection))
                {
                    foreach (var data in dataList)
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("code", hgetCodeTime_14());
                        cmd.Parameters.AddWithValue("ma", data.Ma);
                        cmd.Parameters.AddWithValue("ten", data.Ten);
                        //cmd.Parameters.AddWithValue("ma_huyen", data.MA_HUYEN);
                        //cmd.Parameters.AddWithValue("ma_tinh", data.MA_TINH);
                        //cmd.Parameters.AddWithValue("ten_huyen", data.TEN_HUYEN);
                        // Add other parameters as needed
                        cmd.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }
            Console.WriteLine("Dữ liệu đã được lưu vào bảng DanhMuc trong cơ sở dữ liệu PostgreSQL.");
        }
    }
}
