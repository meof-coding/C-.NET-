using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

    [OperationContract]
    double Add(double n1, double n2);
    [OperationContract]
    // TODO: Add your service operations here
    List<Product> getProducts(int CategoryId);
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class Product
{
    [DataMember]
    public int ProductID { get; set; }
    [DataMember]
    public string ProductName { get; set; }
    [DataMember]
    public int SupplierID { get; set; }
    [DataMember]
    public int CategoryID { get; set; }
    [DataMember]
    public string QuantityPerUnit { get; set; }
    [DataMember]
    public decimal UnitPrice { get; set; }
    [DataMember]
    public short UnitsInStock { get; set; }
    [DataMember]
    public short UnitsOnOrder { get; set; }
    [DataMember]
    public short ReorderLevel { get; set; }
    [DataMember]
    public bool Discontinued { get; set; }
}
