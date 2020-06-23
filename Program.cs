using Npgsql;
using System;
using System.IO;
using System.Text;

namespace DatabaseSaveFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Arquivo teste = new Arquivo();

            byte[] ImgByteA = File.ReadAllBytes("booksData.xml");

            //INSERT:

            //using (var conn = new NpgsqlConnection("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres"))
            //{
            //    string sQL = "insert into public.\"FILE\" VALUES(1, 'booksData', 'xml', @Image)";
            //    using (var command = new NpgsqlCommand(sQL, conn))
            //    {
            //        NpgsqlParameter param = command.CreateParameter();
            //        param.ParameterName = "@Image";
            //        param.NpgsqlDbType = NpgsqlTypes.NpgsqlDbType.Bytea;
            //        param.Value = ImgByteA;
            //        command.Parameters.Add(param);

            //        conn.Open();
            //        command.ExecuteNonQuery();
            //    }
            //}

            //RETRIEVE:

            using (var conn = new NpgsqlConnection("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres"))
            {
                string sQL = "SELECT * from public.\"FILE\" WHERE public.\"FILE\".\"ID\" = 1";
                using (var command = new NpgsqlCommand(sQL, conn))
                {
                    byte[] productImageByte = null;
                    conn.Open();
                    var rdr = command.ExecuteReader();
                    if (rdr.Read())
                    {
                        productImageByte = (byte[])rdr[3];
                    }
                    rdr.Close();
                    if (productImageByte != null)
                    {
                        using (MemoryStream productImageStream = new System.IO.MemoryStream(productImageByte))
                        {
                            string my_string = Encoding.UTF8.GetString(productImageByte, 0, productImageByte.Length);
                            Console.WriteLine(my_string);
                        }
                    }
                }
            }

            //Console.WriteLine(Encoding.UTF8.GetString(ImgByteA, 0, ImgByteA.Length));


        }
    }
}