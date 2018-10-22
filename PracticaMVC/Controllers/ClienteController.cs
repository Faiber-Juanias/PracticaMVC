using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticaMVC.Models;
using System.Data;

namespace PracticaMVC.Controllers
{
    public class ClienteController : Controller
    {
        ClienteModel objClienteModel;
        List<Cliente> listaClientes;
       
        //
        // GET: /Cliente/

        public ActionResult Index()
        {
          
            objClienteModel = new ClienteModel();
            listaClientes = objClienteModel.TraeListaClientes();
            return View(listaClientes);

            //Consumiendo el web service

            
            
        }

        public ActionResult RegistraUsuario()
        {
            return View();
        }

        [HttpPost]
        public ContentResult RecibeRegistroUsuario(string documento, string nombre, string apellido, string celular, string correo, string usuario, string contrasena)
        {
            ServicioLogin.ServiceLoginClassClient objCliente = new ServicioLogin.ServiceLoginClassClient();
            List<ServicioLogin.Cliente> listaClientes = new List<ServicioLogin.Cliente>();
            listaClientes = objCliente.traeClientes();

            objClienteModel = new ClienteModel();
            bool insertado = objClienteModel.InsertaRegistroCliente(documento, nombre, apellido, celular, correo, usuario, contrasena);
            if (insertado)
            {
                return Content("<script>alert('Registro insertado'); location.href='Index';</script>");
            }
            else
            {
                return Content("<script>alert('Error al insertar'); location.href='Index';</script>");
            }            
        }

        [HttpGet]
        public ContentResult EliminaRegistroUsuario(string doc)
        {
            
            objClienteModel = new ClienteModel();
            bool eliminado = objClienteModel.EliminaRegistroCliente(doc);
            if (eliminado)
            {
                return Content("<script>alert('Registro eliminado'); location.href='Index';</script>");
            }
            else
            {
                return Content("<script>alert('Error al eliminar'); location.href='Index';</script>");
            }
        }

        [HttpPost]
        public ContentResult ActualizaRegistroUsuario(string documento, string nombre, string apellido, string celular, string correo, string usuario, string contrasena)
        {

            objClienteModel = new ClienteModel();
            bool actualizado = objClienteModel.ActualizaRegistroCliente(documento, nombre, apellido, celular, correo, usuario, contrasena);
            if (actualizado)
            {
                return Content("<script>alert('Registro actualizado'); location.href='Index';</script>");
            }
            else
            {
                return Content("<script>alert('Error al actualizar'); location.href='Index';</script>");
            }
        }

        public ActionResult ActualizaUsuario(string doc)
        {
            objClienteModel = new ClienteModel();
            DataTable objUsuario = objClienteModel.TraeClienteUnico(doc);
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
            return View(objCliente);
        }
    }
}
