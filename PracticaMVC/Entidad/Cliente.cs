using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticaMVC.Models
{
    public class Cliente
    {
        private string documento;
        private string nombre;
        private string apellido;
        private string celular;
        private string correo;
        private string usuario;
        private string contrasena;

        public string Documento
        {
            get { return documento; }
            set { documento = value; }
        }
        
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        
        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }
        
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }
    }
}