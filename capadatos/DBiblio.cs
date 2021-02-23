using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;


namespace capadatos
{
    public class DBiblio
    {
        private int _biblionumber;
        private string _author;
        private string _title;
        private string _isbn;
        private string _publishercode;
        private string _editionstatement;
        private DateTime _timestamp;

        public int Biblionumber { get => _biblionumber; set => _biblionumber = value; }
        public string Author { get => _author; set => _author = value; }
        public string Title { get => _title; set => _title = value; }
        public string Isbn { get => _isbn; set => _isbn = value; }
        public string Publishercode { get => _publishercode; set => _publishercode = value; }
        public string Editionstatement { get => _editionstatement; set => _editionstatement = value; }
        public DateTime Timestamp { get => _timestamp; set => _timestamp = value; }

        public DBiblio()
        {
            
        }

        public DBiblio(int biblionumber, string author, string title, string isbn, string publishercode, string editionstatement, DateTime timestamp)
        {
            Biblionumber = biblionumber;
            Author = author;
            Title = title;
            Isbn = isbn;
            Publishercode = publishercode;
            Editionstatement = editionstatement;
            Timestamp = timestamp;
        }

        public string insertarbiblio(DBiblio biblio)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@idcliente";
                ParIdcliente.SqlDbType = SqlDbType.Int;
                ParIdcliente.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdcliente);
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "no se ingreso";
                return rpta;
            }
            catch (Exception ex)
            {
                rpta = ex.Message;

            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        public DataTable mostrarlibros()
        {
            DataTable dtresultado = new DataTable("biblio");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexion.cn;
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "cabecera";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqladat = new SqlDataAdapter(SqlCmd);
                sqladat.Fill(dtresultado);

            }
            catch (Exception ex)
            {
                dtresultado = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return dtresultado;
        }
    }
}
