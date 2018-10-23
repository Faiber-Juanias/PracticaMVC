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
        List<ServicioLogin.Cliente> listaClientes;
        ServicioLogin.ServiceLoginClassClient objServiceClient;
       
        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            /*
            objClienteModel = new ClienteModel();
            listaClientes = objClienteModel.TraeListaClientes();*/
            objServiceClient = new ServicioLogin.ServiceLoginClassClient();
            listaClientes = objServiceClient.TraeListaClientes();
            return View(listaClientes);
        }

        public ActionResult RegistraUsuario()
        {
            return View();
        }

        [HttpPost]
        public ContentResult RecibeRegistroUsuario(string documento, string nombre, string apellido, string celular, string correo, string usuario, string contrasena)
        {
            /*
            objClienteModel = new ClienteModel();
            bool insertado = objClienteModel.InsertaRegistroCliente(documento, nombre, apellido, celular, correo, usuario, contrasena);*/

            objServiceClient = new ServicioLogin.ServiceLoginClassClient();
            bool insertado = objServiceClient.RecibeRegistro(documento, nombre, apellido, celular, correo, usuario, contrasena);

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
            /*
            objClienteModel = new ClienteModel();
            bool eliminado = objClienteModel.EliminaRegistroCliente(doc);*/

            objServiceClient = new ServicioLogin.ServiceLoginClassClient();
            bool eliminado = objServiceClient.EliminaRegistro(doc);

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
            /*
            objClienteModel = new ClienteModel();
            bool actualizado = objClienteModel.ActualizaRegistroCliente(documento, nombre, apellido, celular, correo, usuario, contrasena);*/

            objServiceClient = new ServicioLogin.ServiceLoginClassClient();
            bool actualizado = objServiceClient.ActualizaRegistro(documento, nombre, apellido, celular, correo, usuario, contrasena);

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
            /*
            objClienteModel = new ClienteModel();
            DataTable objUsuario = objClienteModel.TraeClienteUnico(doc);*/

            objServiceClient = new ServicioLogin.ServiceLoginClassClient();
            ServicioLogin.Cliente objClienteService = objServiceClient.TraeActualizarRegistro(doc);

            //Cliente objCliente = new Cliente();
            //foreach (DataRow columna in objUsuario.Rows)
            //{
            //    objCliente.Documento = columna["Documento"].ToString();
            //    objCliente.Nombre = columna["Nombre"].ToString();
            //    objCliente.Apellido = columna["Apellido"].ToString();
            //    objCliente.Celular = columna["Celular"].ToString();
            //    objCliente.Correo = columna["Correo"].ToString();
            //    objCliente.Usuario = columna["Usuario"].ToString();
            //    objCliente.Contrasena = columna["Contrasena"].ToString();
            //}
            return View(objClienteService);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ContentResult RecibeLogin(string usuario, string contrasena)
        {
            objServiceClient = new ServicioLogin.ServiceLoginClassClient();
            bool siexiste = objServiceClient.traeLogin(usuario, contrasena);
            if (siexiste)
            {
                Session["usuario"] = usuario;
                return Content("<script>location.href='Index';</script>");
            }
            return Content("<script>alert('Usuario o contraseña incorrectos'); location.href='Login';</script>");
        }

        public ContentResult CierraSesion()
        {
            Session.Abandon();
            return Content("<script>location.href='Index';</script>");
        }
    }
}
