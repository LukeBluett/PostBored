using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostBored
{
    class connection
    {

       OracleConnection conn = new OracleConnection();

       static public string GetConnection()
        {
            return "Data Source=;User ID=;Password=";
        }

       public void StartConnection()
       {
           conn.ConnectionString = GetConnection();
           conn.Open();
       }

       public void CloseConnection()
       {
           conn.Close();
       }
    }
}
