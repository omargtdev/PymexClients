﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pymex.MVC.ClienteProxy {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseDataContract", Namespace="http://schemas.datacontract.org/2004/07/Pymex.Services.Contracts")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Pymex.MVC.ClienteProxy.ResponseWithDataDataContractOfClienteDCXmnxQzc5))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(Pymex.MVC.ClienteProxy.ResponseWithDataDataContractOfArrayOfClienteDCXmnxQzc5))]
    public partial class ResponseDataContract : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool EsCorrectoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MensajeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool EsCorrecto {
            get {
                return this.EsCorrectoField;
            }
            set {
                if ((this.EsCorrectoField.Equals(value) != true)) {
                    this.EsCorrectoField = value;
                    this.RaisePropertyChanged("EsCorrecto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Mensaje {
            get {
                return this.MensajeField;
            }
            set {
                if ((object.ReferenceEquals(this.MensajeField, value) != true)) {
                    this.MensajeField = value;
                    this.RaisePropertyChanged("Mensaje");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseWithDataDataContractOfClienteDCXmnxQzc5", Namespace="http://schemas.datacontract.org/2004/07/Pymex.Services.Contracts")]
    [System.SerializableAttribute()]
    public partial class ResponseWithDataDataContractOfClienteDCXmnxQzc5 : Pymex.MVC.ClienteProxy.ResponseDataContract {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Pymex.MVC.ClienteProxy.ClienteDC DataField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Pymex.MVC.ClienteProxy.ClienteDC Data {
            get {
                return this.DataField;
            }
            set {
                if ((object.ReferenceEquals(this.DataField, value) != true)) {
                    this.DataField = value;
                    this.RaisePropertyChanged("Data");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ResponseWithDataDataContractOfArrayOfClienteDCXmnxQzc5", Namespace="http://schemas.datacontract.org/2004/07/Pymex.Services.Contracts")]
    [System.SerializableAttribute()]
    public partial class ResponseWithDataDataContractOfArrayOfClienteDCXmnxQzc5 : Pymex.MVC.ClienteProxy.ResponseDataContract {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Pymex.MVC.ClienteProxy.ClienteDC[] DataField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Pymex.MVC.ClienteProxy.ClienteDC[] Data {
            get {
                return this.DataField;
            }
            set {
                if ((object.ReferenceEquals(this.DataField, value) != true)) {
                    this.DataField = value;
                    this.RaisePropertyChanged("Data");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ClienteDC", Namespace="http://schemas.datacontract.org/2004/07/Pymex.Services.Contracts")]
    [System.SerializableAttribute()]
    public partial class ClienteDC : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Pymex.MVC.ClienteProxy.TipoDocumento TipoDocumentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NumeroDocumentoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreCompletoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Pymex.MVC.ClienteProxy.HistorialSeguimientoDC HistorialSeguimientoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsuarioAccionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Pymex.MVC.ClienteProxy.TipoDocumento TipoDocumento {
            get {
                return this.TipoDocumentoField;
            }
            set {
                if ((this.TipoDocumentoField.Equals(value) != true)) {
                    this.TipoDocumentoField = value;
                    this.RaisePropertyChanged("TipoDocumento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string NumeroDocumento {
            get {
                return this.NumeroDocumentoField;
            }
            set {
                if ((object.ReferenceEquals(this.NumeroDocumentoField, value) != true)) {
                    this.NumeroDocumentoField = value;
                    this.RaisePropertyChanged("NumeroDocumento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public string NombreCompleto {
            get {
                return this.NombreCompletoField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreCompletoField, value) != true)) {
                    this.NombreCompletoField = value;
                    this.RaisePropertyChanged("NombreCompleto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public Pymex.MVC.ClienteProxy.HistorialSeguimientoDC HistorialSeguimiento {
            get {
                return this.HistorialSeguimientoField;
            }
            set {
                if ((object.ReferenceEquals(this.HistorialSeguimientoField, value) != true)) {
                    this.HistorialSeguimientoField = value;
                    this.RaisePropertyChanged("HistorialSeguimiento");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public string UsuarioAccion {
            get {
                return this.UsuarioAccionField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuarioAccionField, value) != true)) {
                    this.UsuarioAccionField = value;
                    this.RaisePropertyChanged("UsuarioAccion");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="HistorialSeguimientoDC", Namespace="http://schemas.datacontract.org/2004/07/Pymex.Services.ValueObjects")]
    [System.SerializableAttribute()]
    public partial class HistorialSeguimientoDC : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime FechaRegistroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsuarioRegistroField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> FechaModificacionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UltimoUsuarioModificacionField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime FechaRegistro {
            get {
                return this.FechaRegistroField;
            }
            set {
                if ((this.FechaRegistroField.Equals(value) != true)) {
                    this.FechaRegistroField = value;
                    this.RaisePropertyChanged("FechaRegistro");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UsuarioRegistro {
            get {
                return this.UsuarioRegistroField;
            }
            set {
                if ((object.ReferenceEquals(this.UsuarioRegistroField, value) != true)) {
                    this.UsuarioRegistroField = value;
                    this.RaisePropertyChanged("UsuarioRegistro");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public System.Nullable<System.DateTime> FechaModificacion {
            get {
                return this.FechaModificacionField;
            }
            set {
                if ((this.FechaModificacionField.Equals(value) != true)) {
                    this.FechaModificacionField = value;
                    this.RaisePropertyChanged("FechaModificacion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public string UltimoUsuarioModificacion {
            get {
                return this.UltimoUsuarioModificacionField;
            }
            set {
                if ((object.ReferenceEquals(this.UltimoUsuarioModificacionField, value) != true)) {
                    this.UltimoUsuarioModificacionField = value;
                    this.RaisePropertyChanged("UltimoUsuarioModificacion");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TipoDocumento", Namespace="http://schemas.datacontract.org/2004/07/Pymex.Services.ValueObjects")]
    public enum TipoDocumento : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        RUC = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        DNI = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ClienteProxy.IClienteService")]
    public interface IClienteService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGenericServiceOf_ClienteDC/Listar", ReplyAction="http://tempuri.org/IGenericServiceOf_ClienteDC/ListarResponse")]
        Pymex.MVC.ClienteProxy.ResponseWithDataDataContractOfArrayOfClienteDCXmnxQzc5 Listar();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGenericServiceOf_ClienteDC/Listar", ReplyAction="http://tempuri.org/IGenericServiceOf_ClienteDC/ListarResponse")]
        System.Threading.Tasks.Task<Pymex.MVC.ClienteProxy.ResponseWithDataDataContractOfArrayOfClienteDCXmnxQzc5> ListarAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGenericServiceOf_ClienteDC/ObtenerPorId", ReplyAction="http://tempuri.org/IGenericServiceOf_ClienteDC/ObtenerPorIdResponse")]
        Pymex.MVC.ClienteProxy.ResponseWithDataDataContractOfClienteDCXmnxQzc5 ObtenerPorId(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGenericServiceOf_ClienteDC/ObtenerPorId", ReplyAction="http://tempuri.org/IGenericServiceOf_ClienteDC/ObtenerPorIdResponse")]
        System.Threading.Tasks.Task<Pymex.MVC.ClienteProxy.ResponseWithDataDataContractOfClienteDCXmnxQzc5> ObtenerPorIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGenericServiceOf_ClienteDC/Crear", ReplyAction="http://tempuri.org/IGenericServiceOf_ClienteDC/CrearResponse")]
        Pymex.MVC.ClienteProxy.ResponseDataContract Crear(Pymex.MVC.ClienteProxy.ClienteDC dataContract);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGenericServiceOf_ClienteDC/Crear", ReplyAction="http://tempuri.org/IGenericServiceOf_ClienteDC/CrearResponse")]
        System.Threading.Tasks.Task<Pymex.MVC.ClienteProxy.ResponseDataContract> CrearAsync(Pymex.MVC.ClienteProxy.ClienteDC dataContract);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGenericServiceOf_ClienteDC/Actualizar", ReplyAction="http://tempuri.org/IGenericServiceOf_ClienteDC/ActualizarResponse")]
        Pymex.MVC.ClienteProxy.ResponseDataContract Actualizar(Pymex.MVC.ClienteProxy.ClienteDC dataContract);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGenericServiceOf_ClienteDC/Actualizar", ReplyAction="http://tempuri.org/IGenericServiceOf_ClienteDC/ActualizarResponse")]
        System.Threading.Tasks.Task<Pymex.MVC.ClienteProxy.ResponseDataContract> ActualizarAsync(Pymex.MVC.ClienteProxy.ClienteDC dataContract);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeleteOperationOf_ClienteDC/Eliminar", ReplyAction="http://tempuri.org/IDeleteOperationOf_ClienteDC/EliminarResponse")]
        Pymex.MVC.ClienteProxy.ResponseDataContract Eliminar(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDeleteOperationOf_ClienteDC/Eliminar", ReplyAction="http://tempuri.org/IDeleteOperationOf_ClienteDC/EliminarResponse")]
        System.Threading.Tasks.Task<Pymex.MVC.ClienteProxy.ResponseDataContract> EliminarAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IClienteServiceChannel : Pymex.MVC.ClienteProxy.IClienteService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ClienteServiceClient : System.ServiceModel.ClientBase<Pymex.MVC.ClienteProxy.IClienteService>, Pymex.MVC.ClienteProxy.IClienteService {
        
        public ClienteServiceClient() {
        }
        
        public ClienteServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ClienteServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClienteServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ClienteServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Pymex.MVC.ClienteProxy.ResponseWithDataDataContractOfArrayOfClienteDCXmnxQzc5 Listar() {
            return base.Channel.Listar();
        }
        
        public System.Threading.Tasks.Task<Pymex.MVC.ClienteProxy.ResponseWithDataDataContractOfArrayOfClienteDCXmnxQzc5> ListarAsync() {
            return base.Channel.ListarAsync();
        }
        
        public Pymex.MVC.ClienteProxy.ResponseWithDataDataContractOfClienteDCXmnxQzc5 ObtenerPorId(int id) {
            return base.Channel.ObtenerPorId(id);
        }
        
        public System.Threading.Tasks.Task<Pymex.MVC.ClienteProxy.ResponseWithDataDataContractOfClienteDCXmnxQzc5> ObtenerPorIdAsync(int id) {
            return base.Channel.ObtenerPorIdAsync(id);
        }
        
        public Pymex.MVC.ClienteProxy.ResponseDataContract Crear(Pymex.MVC.ClienteProxy.ClienteDC dataContract) {
            return base.Channel.Crear(dataContract);
        }
        
        public System.Threading.Tasks.Task<Pymex.MVC.ClienteProxy.ResponseDataContract> CrearAsync(Pymex.MVC.ClienteProxy.ClienteDC dataContract) {
            return base.Channel.CrearAsync(dataContract);
        }
        
        public Pymex.MVC.ClienteProxy.ResponseDataContract Actualizar(Pymex.MVC.ClienteProxy.ClienteDC dataContract) {
            return base.Channel.Actualizar(dataContract);
        }
        
        public System.Threading.Tasks.Task<Pymex.MVC.ClienteProxy.ResponseDataContract> ActualizarAsync(Pymex.MVC.ClienteProxy.ClienteDC dataContract) {
            return base.Channel.ActualizarAsync(dataContract);
        }
        
        public Pymex.MVC.ClienteProxy.ResponseDataContract Eliminar(int id) {
            return base.Channel.Eliminar(id);
        }
        
        public System.Threading.Tasks.Task<Pymex.MVC.ClienteProxy.ResponseDataContract> EliminarAsync(int id) {
            return base.Channel.EliminarAsync(id);
        }
    }
}
