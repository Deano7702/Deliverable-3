using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Deliverable2
{   
    //Dean Mason
    //1574783
    class SQL
    {
        //generates the connection to the database       
        //Make sure that in the Database connection you put your Database connection here:
        public static SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-Q8H2DIOC\SQLEXPRESS;Database=DeliverableThree;Integrated Security=True"); //The SQL connection to the database
        public static SqlCommand cmd = new SqlCommand(); 
        public static SqlDataReader read;

        /// <summary>
        /// Generates an SQL query based on the input
        /// query e.g. "SELECT * FROM staff"
        /// </summary>
        /// <param name="query"></param>
        public static void selectQuery(string query)
        {
            try
            {
                con.Close();
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;
                read = cmd.ExecuteReader();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                //put a message box in here if you are recieving errors and see if you can find out why?
                MessageBox.Show(ex.Message);
                return;
            }
        }

        public static void executeQuery(string query, SqlParameter[] parameters)
        {
            try
            {
                con.Close();
                cmd.Connection = con;

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;
                cmd.Parameters.AddRange(parameters);

                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void executeQueryProcedure(string query)
        {
            try
            {
                con.Close();
                cmd.Connection = con;
                con.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = query;
                read = cmd.ExecuteReader();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                //put a message box in here if you are recieving errors and see if you can find out why?
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }


}
