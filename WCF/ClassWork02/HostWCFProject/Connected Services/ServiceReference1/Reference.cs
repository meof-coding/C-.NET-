﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HostWCFProject.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Product", Namespace="http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    public partial class Product : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CategoryIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool DiscontinuedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ProductIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string QuantityPerUnitField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short ReorderLevelField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SupplierIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal UnitPriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short UnitsInStockField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short UnitsOnOrderField;
        
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
        public int CategoryID {
            get {
                return this.CategoryIDField;
            }
            set {
                if ((this.CategoryIDField.Equals(value) != true)) {
                    this.CategoryIDField = value;
                    this.RaisePropertyChanged("CategoryID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Discontinued {
            get {
                return this.DiscontinuedField;
            }
            set {
                if ((this.DiscontinuedField.Equals(value) != true)) {
                    this.DiscontinuedField = value;
                    this.RaisePropertyChanged("Discontinued");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProductID {
            get {
                return this.ProductIDField;
            }
            set {
                if ((this.ProductIDField.Equals(value) != true)) {
                    this.ProductIDField = value;
                    this.RaisePropertyChanged("ProductID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductName {
            get {
                return this.ProductNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductNameField, value) != true)) {
                    this.ProductNameField = value;
                    this.RaisePropertyChanged("ProductName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string QuantityPerUnit {
            get {
                return this.QuantityPerUnitField;
            }
            set {
                if ((object.ReferenceEquals(this.QuantityPerUnitField, value) != true)) {
                    this.QuantityPerUnitField = value;
                    this.RaisePropertyChanged("QuantityPerUnit");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short ReorderLevel {
            get {
                return this.ReorderLevelField;
            }
            set {
                if ((this.ReorderLevelField.Equals(value) != true)) {
                    this.ReorderLevelField = value;
                    this.RaisePropertyChanged("ReorderLevel");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SupplierID {
            get {
                return this.SupplierIDField;
            }
            set {
                if ((this.SupplierIDField.Equals(value) != true)) {
                    this.SupplierIDField = value;
                    this.RaisePropertyChanged("SupplierID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal UnitPrice {
            get {
                return this.UnitPriceField;
            }
            set {
                if ((this.UnitPriceField.Equals(value) != true)) {
                    this.UnitPriceField = value;
                    this.RaisePropertyChanged("UnitPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short UnitsInStock {
            get {
                return this.UnitsInStockField;
            }
            set {
                if ((this.UnitsInStockField.Equals(value) != true)) {
                    this.UnitsInStockField = value;
                    this.RaisePropertyChanged("UnitsInStock");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short UnitsOnOrder {
            get {
                return this.UnitsOnOrderField;
            }
            set {
                if ((this.UnitsOnOrderField.Equals(value) != true)) {
                    this.UnitsOnOrderField = value;
                    this.RaisePropertyChanged("UnitsOnOrder");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Add", ReplyAction="http://tempuri.org/IService/AddResponse")]
        double Add(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/Add", ReplyAction="http://tempuri.org/IService/AddResponse")]
        System.Threading.Tasks.Task<double> AddAsync(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getProducts", ReplyAction="http://tempuri.org/IService/getProductsResponse")]
        HostWCFProject.ServiceReference1.Product[] getProducts(int CategoryId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/getProducts", ReplyAction="http://tempuri.org/IService/getProductsResponse")]
        System.Threading.Tasks.Task<HostWCFProject.ServiceReference1.Product[]> getProductsAsync(int CategoryId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : HostWCFProject.ServiceReference1.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<HostWCFProject.ServiceReference1.IService>, HostWCFProject.ServiceReference1.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double Add(double n1, double n2) {
            return base.Channel.Add(n1, n2);
        }
        
        public System.Threading.Tasks.Task<double> AddAsync(double n1, double n2) {
            return base.Channel.AddAsync(n1, n2);
        }
        
        public HostWCFProject.ServiceReference1.Product[] getProducts(int CategoryId) {
            return base.Channel.getProducts(CategoryId);
        }
        
        public System.Threading.Tasks.Task<HostWCFProject.ServiceReference1.Product[]> getProductsAsync(int CategoryId) {
            return base.Channel.getProductsAsync(CategoryId);
        }
    }
}