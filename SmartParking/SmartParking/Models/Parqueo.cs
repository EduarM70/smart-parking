using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Models
{
    public class Parqueo
    {
        public int idIgreso {  get; set; }
        public string codigo { get; set; }
        public DateTime fechaIngreso {  get; set; }
        public DateTime fechaSalida { get; set; }
        public TimeSpan tiempoEstacionado { get; set; }
        public double tarifaAplicada { get; set; }
        public double totalPago { get; set; }
        public string zona {  get; set; }
        public int fila {  get; set; }
        public int parqueo { get; set; }

    }
}
