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
            return "Data Source=cp3dbinstance.c4pxnpz4ojk8.us-east-1.rds.amazonaws.com;User ID=sw5;Password=sw5";
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
