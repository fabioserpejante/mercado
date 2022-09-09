using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoZe.Classes
{
    public class Pedido
    {
        public int Numero { get; set; }
        public Double ValorTotal { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataHora { get; set; }
        public Produto Produto { get; set; }
        public Cliente Cliente { get; set; }       

        public Pedido()
        {
            this.Produto = new Produto();
            this.Cliente = new Cliente();
            //this.DataHora = DateTime.Now();
        } 
    }
}