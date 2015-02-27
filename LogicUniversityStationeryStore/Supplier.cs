//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogicUniversityStationeryStore
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supplier
    {
        public Supplier()
        {
            this.PurchaseOrders = new HashSet<PurchaseOrder>();
            this.Stationeries = new HashSet<Stationery>();
            this.Stationeries1 = new HashSet<Stationery>();
            this.Stationeries2 = new HashSet<Stationery>();
        }
    
        public string supplierCode { get; set; }
        public string supplierName { get; set; }
        public string registrationNo { get; set; }
        public string contactName { get; set; }
        public string address { get; set; }
        public string telNo { get; set; }
        public string faxNo { get; set; }
        public string email { get; set; }
    
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<Stationery> Stationeries { get; set; }
        public virtual ICollection<Stationery> Stationeries1 { get; set; }
        public virtual ICollection<Stationery> Stationeries2 { get; set; }
    }
}
