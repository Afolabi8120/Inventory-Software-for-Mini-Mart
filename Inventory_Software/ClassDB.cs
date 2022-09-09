using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Inventory_Software
{
    class ClassDB
    {
        public string getConnection()
        {
            string cn = "host = localhost;username=root;password=;database=ims_db";
            return cn;
        }
    }
}
