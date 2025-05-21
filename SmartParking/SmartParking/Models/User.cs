using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Usuario { get; set; }

        public string Nombre { get; set; }
        public string Email { get; set; }

    }
}
