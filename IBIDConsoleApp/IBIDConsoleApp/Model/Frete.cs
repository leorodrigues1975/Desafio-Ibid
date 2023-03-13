using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBIDConsoleApp.Model
{
    public class Frete
    {
        public string codigoFrete { get; set; }
        public bool ativo { get; set; }
        public int permiteValor { get; set; }
        public bool necessitaTransportadora { get; set; }
        public string descricaoPortugues { get; set; }
        public string descricaoIngles { get; set; }
        public string descricaoEspanhol { get; set; }
    }
}
