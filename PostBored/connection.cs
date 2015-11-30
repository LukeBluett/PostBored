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
            return "Data Source=:1521/;User ID=;Password=";
               // "Data Source=studentoracle.students.ittralee.ie:1521/orcl;User ID=;Password=";
        }
    }
}
