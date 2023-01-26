using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Quiz_game_design_and_coded_solution
{
    public static class DatabaseConnect
    {
        public static DataSet dataConnect(string sql)
        {
            OleDbConnection con = Connect();

            OleDbDataAdapter customerAdapter = new OleDbDataAdapter(sql, con);

            DataSet dataSet = new DataSet();

            customerAdapter.Fill(dataSet, "DATA");

            return dataSet;
        }
        public static OleDbConnection Connect()
        {
            try
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0;" +
                    "Data Source=WorldCities.accdb");
                con.Open();
                return con;
            }
            catch (Exception ex) {
                return null;
            }
        }
        static void ManipulateData(string database, string SQL)
        {
            OleDbConnection con = Connect();
            try
            {
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandText = SQL;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data Inserted!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Insert Failed!");
            }
            con.Close();
        }
    }
}
