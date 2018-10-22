using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PracticaMVC.Models
{
    public class ClienteModel
    {
        SqlConnection conexion;
        Cliente objCliente;
        DataTable objDataTable;
        SqlCommand objCommand;
        List<Cliente> listaClientes;

        public ClienteModel()
        {
            Conecta();
        }

        public void Conecta()
        {
            conexion = new SqlConnection();
            conexion.ConnectionString = "Password=18426483;Persist Security Info=True;User ID=sa;Initial Catalog=datosclientes;Data Source=localhost";
            conexion.Open();
        }

        public DataTable TraeCliente()
        {
            objDataTable = new DataTable();
            objCommand = new SqlCommand();
            objCommand.Connection = conexion;
            objCommand.CommandText = "dbo.traeCliente";
            objCommand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(objCommand);
            adapter.Fill(objDataTable);
            return objDataTable;
        }

        public List<Cliente> TraeListaClientes()
        {
            listaClientes = new List<Cliente>();
            objCliente = new Cliente();
            TraeCliente();
            if (TraeCliente() != null)
            {
                foreach (DataRow fila in objDataTable.Rows)
                {
                    objCliente = new Cliente();
                    objCliente.Documento = fila["Documento"].ToString();
                    objCliente.Nombre = fila["Nombre"].ToString();
                    objCliente.Apellido = fila["Apellido"].ToString();
                    objCliente.Celular = fila["Celular"].ToString();
                    objCliente.Correo = fila["Correo"].ToString();
                    objCliente.Usuario = fila["Usuario"].ToString();
                    objCliente.Contrasena = fila["Contrasena"].ToString();
                    listaClientes.Add(objCliente);
                }
            }
            return listaClientes;
        }

        public bool InsertaRegistroCliente(string documento, string nombre, string apellido, string celular, string correo, string usuario, string contrasena)
        {
            objCommand = new SqlCommand();
            objCommand.Connection = conexion;
            objCommand.CommandText = "dbo.InsertaRegistro";
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.Add("@Documento", SqlDbType.VarChar, 20).Value = documento;
            objCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 30).Value = nombre;
            objCommand.Parameters.Add("@Apellido", SqlDbType.VarChar, 30).Value = apellido;
            objCommand.Parameters.Add("@Celular", SqlDbType.VarChar, 30).Value = celular;
            objCommand.Parameters.Add("@Correo", SqlDbType.VarChar, 30).Value = correo;
            objCommand.Parameters.Add("@Usuario", SqlDbType.VarChar, 30).Value = usuario;
            objCommand.Parameters.Add("@Contrasena", SqlDbType.VarChar, 30).Value = contrasena;
            int filasAfectadas = objCommand.ExecuteNonQuery();
            if(filasAfectadas != 0){
                return true;
            }
            return false;
        }

        public bool EliminaRegistroCliente(string documento)
        {
            objCommand = new SqlCommand();
            objCommand.Connection = conexion;
            objCommand.CommandText = "dbo.EliminaCliente";
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.Add("@Documento", SqlDbType.VarChar, 20).Value = documento;
            int filasAfectadas = objCommand.ExecuteNonQuery();
            if (filasAfectadas != 0)
            {
                return true;
            }
            return false;
        }

        public bool ActualizaRegistroCliente(string documento, string nombre, string apellido, string celular, string correo, string usuario, string contrasena)
        {
            objCommand = new SqlCommand();
            objCommand.Connection = conexion;
            objCommand.CommandText = "dbo.ActualizaCliente";
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.Add("@Documento", SqlDbType.VarChar, 20).Value = documento;
            objCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 30).Value = nombre;
            objCommand.Parameters.Add("@Apellido", SqlDbType.VarChar, 30).Value = apellido;
            objCommand.Parameters.Add("@Celular", SqlDbType.VarChar, 30).Value = celular;
            objCommand.Parameters.Add("@Correo", SqlDbType.VarChar, 30).Value = correo;
            objCommand.Parameters.Add("@Usuario", SqlDbType.VarChar, 30).Value = usuario;
            objCommand.Parameters.Add("@Contrasena", SqlDbType.VarChar, 30).Value = contrasena;
            int filasAfectadas = objCommand.ExecuteNonQuery();
            if (filasAfectadas != 0)
            {
                return true;
            }
            return false;
        }

        public DataTable TraeClienteUnico(string documento)
        {
            objDataTable = new DataTable();
            objCommand = new SqlCommand();
            objCommand.Connection = conexion;
            objCommand.CommandText = "dbo.traeClienteUnico";
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.Add("@Documento", SqlDbType.VarChar, 20).Value = documento;
            SqlDataAdapter adapter = new SqlDataAdapter(objCommand);
            adapter.Fill(objDataTable);
            return objDataTable;
        }
    }
}