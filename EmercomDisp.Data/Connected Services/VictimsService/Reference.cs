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
        private int AgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ResidenceField;
        
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
        public int Age {
            get {
                return this.AgeField;
            }
            set {
                if ((this.AgeField.Equals(value) != true)) {
                    this.AgeField = value;
                    this.RaisePropertyChanged("Age");
                }
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Residence {
            get {
                return this.ResidenceField;
            }
            set {
                if ((object.ReferenceEquals(this.ResidenceField, value) != true)) {
                    this.ResidenceField = value;
                    this.RaisePropertyChanged("Residence");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SqlFault", Namespace="http://schemas.datacontract.org/2004/07/EmercomDisp.Service.Dto.Models")]
    [System.SerializableAttribute()]
    public partial class SqlFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ArgumentFault", Namespace="http://schemas.datacontract.org/2004/07/EmercomDisp.Service.Dto.Models")]
    [System.SerializableAttribute()]
    public partial class ArgumentFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVictimsService/GetVictimById", ReplyAction="http://tempuri.org/IVictimsService/GetVictimByIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmercomDisp.Data.VictimsService.ConnectionFault), Action="http://tempuri.org/IVictimsService/GetVictimByIdConnectionFaultFault", Name="ConnectionFault", Namespace="http://schemas.datacontract.org/2004/07/EmercomDisp.Service.Dto.Models")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmercomDisp.Data.VictimsService.SqlFault), Action="http://tempuri.org/IVictimsService/GetVictimByIdSqlFaultFault", Name="SqlFault", Namespace="http://schemas.datacontract.org/2004/07/EmercomDisp.Service.Dto.Models")]
        EmercomDisp.Data.VictimsService.VictimDto GetVictimById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVictimsService/GetVictimById", ReplyAction="http://tempuri.org/IVictimsService/GetVictimByIdResponse")]
        System.Threading.Tasks.Task<EmercomDisp.Data.VictimsService.VictimDto> GetVictimByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVictimsService/GetVictimsByIncidentId", ReplyAction="http://tempuri.org/IVictimsService/GetVictimsByIncidentIdResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmercomDisp.Data.VictimsService.ConnectionFault), Action="http://tempuri.org/IVictimsService/GetVictimsByIncidentIdConnectionFaultFault", Name="ConnectionFault", Namespace="http://schemas.datacontract.org/2004/07/EmercomDisp.Service.Dto.Models")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmercomDisp.Data.VictimsService.SqlFault), Action="http://tempuri.org/IVictimsService/GetVictimsByIncidentIdSqlFaultFault", Name="SqlFault", Namespace="http://schemas.datacontract.org/2004/07/EmercomDisp.Service.Dto.Models")]
        EmercomDisp.Data.VictimsService.VictimDto[] GetVictimsByIncidentId(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVictimsService/GetVictimsByIncidentId", ReplyAction="http://tempuri.org/IVictimsService/GetVictimsByIncidentIdResponse")]
        System.Threading.Tasks.Task<EmercomDisp.Data.VictimsService.VictimDto[]> GetVictimsByIncidentIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVictimsService/AddVictim", ReplyAction="http://tempuri.org/IVictimsService/AddVictimResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmercomDisp.Data.VictimsService.ConnectionFault), Action="http://tempuri.org/IVictimsService/AddVictimConnectionFaultFault", Name="ConnectionFault", Namespace="http://schemas.datacontract.org/2004/07/EmercomDisp.Service.Dto.Models")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmercomDisp.Data.VictimsService.SqlFault), Action="http://tempuri.org/IVictimsService/AddVictimSqlFaultFault", Name="SqlFault", Namespace="http://schemas.datacontract.org/2004/07/EmercomDisp.Service.Dto.Models")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmercomDisp.Data.VictimsService.ArgumentFault), Action="http://tempuri.org/IVictimsService/AddVictimArgumentFaultFault", Name="ArgumentFault", Namespace="http://schemas.datacontract.org/2004/07/EmercomDisp.Service.Dto.Models")]
        void AddVictim(EmercomDisp.Data.VictimsService.VictimDto victim, int callId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVictimsService/AddVictim", ReplyAction="http://tempuri.org/IVictimsService/AddVictimResponse")]
        System.Threading.Tasks.Task AddVictimAsync(EmercomDisp.Data.VictimsService.VictimDto victim, int callId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVictimsService/UpdateVictim", ReplyAction="http://tempuri.org/IVictimsService/UpdateVictimResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmercomDisp.Data.VictimsService.ConnectionFault), Action="http://tempuri.org/IVictimsService/UpdateVictimConnectionFaultFault", Name="ConnectionFault", Namespace="http://schemas.datacontract.org/2004/07/EmercomDisp.Service.Dto.Models")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmercomDisp.Data.VictimsService.SqlFault), Action="http://tempuri.org/IVictimsService/UpdateVictimSqlFaultFault", Name="SqlFault", Namespace="http://schemas.datacontract.org/2004/07/EmercomDisp.Service.Dto.Models")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmercomDisp.Data.VictimsService.ArgumentFault), Action="http://tempuri.org/IVictimsService/UpdateVictimArgumentFaultFault", Name="ArgumentFault", Namespace="http://schemas.datacontract.org/2004/07/EmercomDisp.Service.Dto.Models")]
        void UpdateVictim(EmercomDisp.Data.VictimsService.VictimDto victim);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVictimsService/UpdateVictim", ReplyAction="http://tempuri.org/IVictimsService/UpdateVictimResponse")]
        System.Threading.Tasks.Task UpdateVictimAsync(EmercomDisp.Data.VictimsService.VictimDto victim);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVictimsService/DeleteVictim", ReplyAction="http://tempuri.org/IVictimsService/DeleteVictimResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmercomDisp.Data.VictimsService.ConnectionFault), Action="http://tempuri.org/IVictimsService/DeleteVictimConnectionFaultFault", Name="ConnectionFault", Namespace="http://schemas.datacontract.org/2004/07/EmercomDisp.Service.Dto.Models")]
        [System.ServiceModel.FaultContractAttribute(typeof(EmercomDisp.Data.VictimsService.SqlFault), Action="http://tempuri.org/IVictimsService/DeleteVictimSqlFaultFault", Name="SqlFault", Namespace="http://schemas.datacontract.org/2004/07/EmercomDisp.Service.Dto.Models")]
        void DeleteVictim(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IVictimsService/DeleteVictim", ReplyAction="http://tempuri.org/IVictimsService/DeleteVictimResponse")]
        System.Threading.Tasks.Task DeleteVictimAsync(int id);
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
        
        public EmercomDisp.Data.VictimsService.VictimDto GetVictimById(int id) {
            return base.Channel.GetVictimById(id);
        }
        
        public System.Threading.Tasks.Task<EmercomDisp.Data.VictimsService.VictimDto> GetVictimByIdAsync(int id) {
            return base.Channel.GetVictimByIdAsync(id);
        }
        
        public EmercomDisp.Data.VictimsService.VictimDto[] GetVictimsByIncidentId(int id) {
            return base.Channel.GetVictimsByIncidentId(id);
        }
        
        public System.Threading.Tasks.Task<EmercomDisp.Data.VictimsService.VictimDto[]> GetVictimsByIncidentIdAsync(int id) {
            return base.Channel.GetVictimsByIncidentIdAsync(id);
        }
        
        public void AddVictim(EmercomDisp.Data.VictimsService.VictimDto victim, int callId) {
            base.Channel.AddVictim(victim, callId);
        }
        
        public System.Threading.Tasks.Task AddVictimAsync(EmercomDisp.Data.VictimsService.VictimDto victim, int callId) {
            return base.Channel.AddVictimAsync(victim, callId);
        }
        
        public void UpdateVictim(EmercomDisp.Data.VictimsService.VictimDto victim) {
            base.Channel.UpdateVictim(victim);
        }
        
        public System.Threading.Tasks.Task UpdateVictimAsync(EmercomDisp.Data.VictimsService.VictimDto victim) {
            return base.Channel.UpdateVictimAsync(victim);
        }
        
        public void DeleteVictim(int id) {
            base.Channel.DeleteVictim(id);
        }
        
        public System.Threading.Tasks.Task DeleteVictimAsync(int id) {
            return base.Channel.DeleteVictimAsync(id);
        }
    }
}
