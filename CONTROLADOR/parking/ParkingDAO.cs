using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELO;
using System.Data.SqlClient;
using System.Data;


namespace CONTROLADOR.parking
{
    public class ParkingDAO
    {
        ClsDatos ClsDatos = null;
        ParkingDTO parkingDTO = null;
        DataTable listaDatos = null;

        public ParkingDAO(ParkingDTO parkingDTO)
        {
            this.parkingDTO = parkingDTO;
        }
        public DataTable ListarParking()
        {
            listaDatos = new DataTable();
            try
            {

                ClsDatos = new ClsDatos();
                SqlParameter[] parametros = null;

                if (this.parkingDTO==null) {
                    parametros = new SqlParameter[4];

                    parametros[0] = new SqlParameter();
                    parametros[0].ParameterName = "@idpark";
                    parametros[0].SqlDbType = SqlDbType.Int;
                    parametros[0].SqlValue = parkingDTO.getIdpark();

                    parametros[1] = new SqlParameter();
                    parametros[1].ParameterName = "@Nombre";
                    parametros[1].SqlDbType = SqlDbType.VarChar;
                    parametros[1].Size = 50;
                    parametros[1].SqlValue = parkingDTO.getNombre();

                    parametros[2] = new SqlParameter();
                    parametros[2].ParameterName = "@Placa";
                    parametros[2].SqlDbType = SqlDbType.Int;
                    parametros[2].SqlValue = parkingDTO.getPlaca();

                    parametros[3] = new SqlParameter();
                    parametros[3].ParameterName = "@Tipov";
                    parametros[3].SqlDbType = SqlDbType.VarChar;
                    parametros[3].Size = 50;
                    parametros[3].SqlValue = parkingDTO.getTipov();




                }
                else {

                    parametros = null;
                }
              
                
                

                listaDatos = ClsDatos.RetornaTabla(parametros, "spConsulta");
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return listaDatos;
        }

        public void Guardarvehiculo()
        {
            try
            {
                ClsDatos = new ClsDatos();
                SqlParameter[] parametros = new SqlParameter[3];

                parametros[0] = new SqlParameter();
                parametros[0].ParameterName = "@Nombre";
                parametros[0].SqlDbType = SqlDbType.VarChar;
                parametros[0].Size = 50;
                parametros[0].SqlValue = parkingDTO.getNombre();

                parametros[1] = new SqlParameter();
                parametros[1].ParameterName = "@Placa";
                parametros[1].SqlDbType = SqlDbType.Int;
                parametros[1].SqlValue = parkingDTO.getPlaca();

                parametros[2] = new SqlParameter();
                parametros[2].ParameterName = "@Tipov";
                parametros[2].SqlDbType = SqlDbType.VarChar;
                parametros[2].Size = 50;
                parametros[2].SqlValue = parkingDTO.getTipov();

                


                ClsDatos.EjecutarSP(parametros, "spNuevovehiculo");


            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void Guardarcambios()
        {
            try
            {
                ClsDatos = new ClsDatos();
                SqlParameter[] parametros = new SqlParameter[4];

                parametros[0] = new SqlParameter();
                parametros[0].ParameterName = "@idpark";
                parametros[0].SqlDbType = SqlDbType.Int;
                parametros[0].SqlValue = parkingDTO.getIdpark();

                parametros[1] = new SqlParameter();
                parametros[1].ParameterName = "@Nombre";
                parametros[1].SqlDbType = SqlDbType.VarChar;
                parametros[1].Size = 50;
                parametros[1].SqlValue = parkingDTO.getNombre();

                parametros[2] = new SqlParameter();
                parametros[2].ParameterName = "@Placa";
                parametros[2].SqlDbType = SqlDbType.Int;
                parametros[2].SqlValue = parkingDTO.getPlaca();

                parametros[3] = new SqlParameter();
                parametros[3].ParameterName = "@Tipov";
                parametros[3].SqlDbType = SqlDbType.VarChar;
                parametros[3].Size = 50;
                parametros[3].SqlValue = parkingDTO.getTipov();




                ClsDatos.EjecutarSP(parametros, "spGuardarCambios");


            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public void Eliminar()
        {
            try
            {
                ClsDatos = new ClsDatos();
                SqlParameter[] parametro = new SqlParameter[1];

                parametro[0] = new SqlParameter();
                parametro[0].ParameterName = "@idpark";
                parametro[0].SqlDbType = SqlDbType.Int;
                parametro[0].SqlValue = parkingDTO.getIdpark();

                ClsDatos.EjecutarSP(parametro, "spEliminar");


            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
