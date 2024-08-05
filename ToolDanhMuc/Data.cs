using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolDanhMuc
{
    public   class Data
    {
        public class DanhMuc
        {
            public string Code { get; set; }
            public string Ma { get; set; }
            public string Ten { get; set; }
            public string IS_MN { get; set; }
            public string IS_C1 { get; set; }
            public string IS_C2 { get; set; }
            public string IS_C3 { get; set; }
            public string IS_GDTX { get; set; }
            public string MA_HUYEN { get; set; }
            public string MA_TINH { get; set; }
            public string TEN_HUYEN { get; set; }
        }
        public class JsonReader
        {
            public List<DanhMuc> ReadJsonFile(string filePath)
            {
                string jsonContent = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<DanhMuc>>(jsonContent);
            }
        }
        public static NpgsqlConnection hgetConnection(string databaseName)
        {
            //string _ConnectionString = $"Host=103.77.167.215;Port=5433; Username=postgres;Password=TITKul@@2020;Database={databaseName}";
            string _ConnectionString = $"Host=192.168.1.108;Port=9108; Username=postgres;Password=titkul@@devpg15;Database={databaseName}";
            NpgsqlConnection pgConnect = new NpgsqlConnection();
            //pgConnect.TypeMapper.UseJsonNet;
            NpgsqlConnection.GlobalTypeMapper.UseJsonNet();
            pgConnect.ConnectionString = _ConnectionString;
            try
            {
                pgConnect.Open();
                return pgConnect;
            }
            catch (NpgsqlException ex)
            {
                string error = "Lỗi từ hàm: hpgDataLib.hgetConnection:";
                throw new Exception(error);
            }
        }

        public static object hrunQuery(string databaseName, string queryCommand)
        {
            try
            {
                NpgsqlConnection con = hgetConnection(databaseName);
                NpgsqlCommand cmd = new NpgsqlCommand(queryCommand, con);
                cmd.CommandType = CommandType.Text;
                object obj = cmd.ExecuteScalar();
                if (obj == null) obj = "";
                con.Close();
                con.Dispose();
                cmd.Dispose();
                return obj;
            }
            catch (Exception ex)
            {
                string error = "Lỗi từ hàm: hrunQuery:";
                throw new Exception(error);
            }
        }



        public static object hgetObject(string databaseName, string selectCommand)
        {
            object ketqua;
            try
            {
                NpgsqlConnection con = hgetConnection(databaseName);
                NpgsqlCommand cmd = new NpgsqlCommand(selectCommand, con);
                ketqua = cmd.ExecuteScalar();
                //if (ketqua == null) ketqua = "";
                con.Close();
                con.Dispose();
                cmd.Dispose();
            }
            catch (NpgsqlException ex)
            {
                string error = "Lỗi từ hàm: hgetObject:";
                throw new Exception(error);
            }
            return ketqua;
        }


    }
}

