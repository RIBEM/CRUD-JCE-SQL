using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_JCE_SQL.Model
{
    public class Cedula
    {
        public int Id { get; set; }
        public string NumeroCed { get; set; }
        public string Nombre { get; set; }
        public string LugarNac { get; set; }
        public DateTime FechaNac { get; set; }
        public string Nacionalidad { get; set; }
        public string Sexo { get; set; }
        public string Sangre { get; set; }
        public string EstadoCivil { get; set; }
        public string Ocupacion { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public byte[] Foto { get; set; }
    }
}
