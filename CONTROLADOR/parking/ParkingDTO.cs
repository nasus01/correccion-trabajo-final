using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CONTROLADOR.parking
{
    public class ParkingDTO
    {
        private int idpark;
        private string nombre;
        private int placa;
        private string tipov;
        
        public void setIdpark(int valor) {
            this.idpark = valor;
        }
        public int getIdpark() {
            return this.idpark;
        }

        public void setNombre(string valor)
        {
            this.nombre = valor;
        }
        public string getNombre()
        {
            return this.nombre;
        }
        public void setPlaca(int valor)
        {
            this.placa = valor;
        }
        public int getPlaca()
        {
            return this.placa;
        }
        public void setTipov(string valor)
        {
            this.tipov= valor;
        }
        public string getTipov()
        {
            return this.tipov;
        }
      
    }
}
