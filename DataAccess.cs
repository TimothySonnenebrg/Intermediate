using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TJS.AutoRepair.PL
{
    public static class DataAccess
    {
        //DatabaseStuff
            private static SqlConnection connection;


            public static string ConnectionString {private get; set; }

        

        private static void connect()
        {
            if(connection == null)
            {
                connection = new SqlConnection();
                connection.ConnectionString = ConnectionString;
            }

            if(ConnectionString == "")
            {
                throw new Exception("Forgot to set connection string");
            }
            

            if (connection.State != ConnectionState.Open)
            { 
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {

                throw ex;
            }
          }
        }

        public static void CloseConnection()
        {
            if(connection != null)
            {
                connection.Close();
            }
        }

        public static DataTable Select(string sql, 
            SqlParameter[] sqlParams = null, bool close = true)
        {
            try
            {
                connect();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
             
            finally
            {
                if (close)
                { 
                CloseConnection();
               }
            }

        }

        /// <summary>
        /// Runs Insert, Update, And Delete Statements
        /// </summary>
        /// <param name="sql">The sql statement to run</param>
        /// <param name="sqlParams">Sql filter params</param>
        /// <param name="close">Close connection</param>
        /// <returns>retuns number of rows affected</returns>
 public static int RunSql(string sql, 
            SqlParameter[] sqlParams = null, bool close = true)
        {
            try
            {
                connect();
                SqlCommand command = new SqlCommand(sql, connection);
                return command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
             
            finally
            {
                if (close) { 
                CloseConnection();
               }
            }

        }







        //XmlStuff
        public static void SaveToXML(string filename, Type type, object obj)
        {
            try
            {
            StreamWriter writer = new StreamWriter(filename);
            XmlSerializer serializer = new XmlSerializer(type);
            serializer.Serialize(writer, obj);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
             }




        public static object LoadFromXML(string filename, Type type)
        {

            try
            {
                StreamReader reader = new StreamReader(filename);
                XmlSerializer serializer = new XmlSerializer(type);
                object obj = serializer.Deserialize(reader);
                reader.Close();
                return obj;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
