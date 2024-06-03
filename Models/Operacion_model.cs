using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace excelASPX.Models
{
    public class Operacion_model
    {
        public string Cliente { get; set; }
        public string ClavePedimento { get; set; }
        public string TipoOperacion { get; set; }
        public string Referencia { get; set; }
        public string Pedimento { get; set; }
        public string Remesa { get; set; }
        public string Caja { get; set; }
        public string Sello { get; set; }
        public string DODA { get; set; }
        public string CPfolios { get; set; }
        public string CruceSOIA { get; set; }
        public string Usuario { get; set; }
        public string TiempoReciboBGTS { get; set; }
        public string TiempoACGConfirmado { get; set; }
        public string FechaCartaPorte { get; set; }
        public string FechaRemesa { get; set; }

    }
}