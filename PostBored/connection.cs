using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostBored
{
    class connection
    {
       static public string GetConnection()
        {
            return "Data Source=cp3dbinstance.c4pxnpz4ojk8.us-east-1.rds.amazonaws.com:1521/cp3db;User ID=sw5;Password=sw5";
               // "Data Source=studentoracle.students.ittralee.ie:1521/orcl;User ID=;Password=";
        }
    }
}
