using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using PracticaMVC.Models;

namespace ServiceLogin
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class ServiceLoginClass : IServiceLoginClass
    {

        ClienteModel objClienteModel;

        public List<Cliente> TraeListaClientes()
        {
            objClienteModel = new ClienteModel();
            return objClienteModel.TraeListaClientes();
        }

        public bool RecibeRegistro(string documento, string nombre, string apellido, string celular, string correo, string usuario, string contrasena)
        {
            objClienteModel = new ClienteModel();
            return objClienteModel.InsertaRegistroCliente(documento, nombre, apellido, celular, correo, usuario, contrasena);
        }

        public bool EliminaRegistro(string documento)
        {
            objClienteModel = new ClienteModel();
            return objClienteModel.EliminaRegistroCliente(documento);
        }

        public bool ActualizaRegistro(string documento, string nombre, string apellido, string celular, string correo, string usuario, string contrasena)
        {
            objClienteModel = new ClienteModel();
            return objClienteModel.ActualizaRegistroCliente(documento, nombre, apellido, celular, correo, usuario, contrasena);
        }

        public Cliente TraeActualizarRegistro(string documento)
        {
            objClienteModel = new ClienteModel();
            DataTable objUsuario = objClienteModel.TraeClienteUnico(documento);

            Cliente objCliente = new Cliente();
            foreach (DataRow columna in objUsuario.Rows)
            {
                objCliente.Documento = columna["Documento"].ToString();
                objCliente.Nombre = columna["Nombre"].ToString();
                objCliente.Apellido = columna["Apellido"].ToString();
                objCliente.Celular = columna["Celular"].ToString();
                objCliente.Correo = columna["Correo"].ToString();
                objCliente.Usuario = columna["Usuario"].ToString();
                objCliente.Contrasena = columna["Contrasena"].ToString();
            }
            return objCliente;
        }

        public bool traeLogin(string usuario, string contrasena)
        {
            objClienteModel = new ClienteModel();
            return objClienteModel.TraeLoginCliente(usuario, contrasena);
        }
    }
}
