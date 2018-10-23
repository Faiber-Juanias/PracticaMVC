using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using PracticaMVC.Models;
using System.Data;

namespace ServiceLogin
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceLoginClass
    {
        [OperationContract]
        List<Cliente> TraeListaClientes();

        [OperationContract]
        bool RecibeRegistro(string documento, string nombre, string apellido, string celular, string correo, string usuario, string contrasena);

        [OperationContract]
        bool EliminaRegistro(string documento);

        [OperationContract]
        bool ActualizaRegistro(string documento, string nombre, string apellido, string celular, string correo, string usuario, string contrasena);

        [OperationContract]
        Cliente TraeActualizarRegistro(string documento);

        [OperationContract]
        bool traeLogin(string usuario, string contrasena);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
