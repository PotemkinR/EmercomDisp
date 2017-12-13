﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmercomDisp.Data.VictimsService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="VictimDto", Namespace="http://schemas.datacontract.org/2004/07/EmercomDisp.Service.Dto.Models")]
    [System.SerializableAttribute()]
    public partial class VictimDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ConnectionFault", Namespace="http://schemas.datacontract.org/2004/07/EmercomDisp.Service.Dto.Models")]
    [System.SerializableAttribute()]
    public partial class ConnectionFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
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
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="VictimsService.IVictimsService")]
    public interface IVictimsService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVictimsService/GetVictimsForIncident", ReplyAction="http://tempuri.org/IVictimsService/GetVictimsForIncidentResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmercomDisp.Data.VictimsService.ConnectionFault), Action="http://tempuri.org/IVictimsService/GetVictimsForIncidentConnectionFaultFault", Name="ConnectionFault", Namespace="http://schemas.datacontract.org/2004/07/EmercomDisp.Service.Dto.Models")]
        EmercomDisp.Data.VictimsService.VictimDto[] GetVictimsForIncident(int incidentId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVictimsService/GetVictimsForIncident", ReplyAction="http://tempuri.org/IVictimsService/GetVictimsForIncidentResponse")]
        System.Threading.Tasks.Task<EmercomDisp.Data.VictimsService.VictimDto[]> GetVictimsForIncidentAsync(int incidentId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IVictimsServiceChannel : EmercomDisp.Data.VictimsService.IVictimsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class VictimsServiceClient : System.ServiceModel.ClientBase<EmercomDisp.Data.VictimsService.IVictimsService>, EmercomDisp.Data.VictimsService.IVictimsService {
        
        public VictimsServiceClient() {
        }
        
        public VictimsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public VictimsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VictimsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public VictimsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public EmercomDisp.Data.VictimsService.VictimDto[] GetVictimsForIncident(int incidentId) {
            return base.Channel.GetVictimsForIncident(incidentId);
        }
        
        public System.Threading.Tasks.Task<EmercomDisp.Data.VictimsService.VictimDto[]> GetVictimsForIncidentAsync(int incidentId) {
            return base.Channel.GetVictimsForIncidentAsync(incidentId);
        }
    }
}
