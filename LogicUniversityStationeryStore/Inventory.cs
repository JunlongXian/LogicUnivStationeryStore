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
    
    public partial class Inventory
    {
        public string stationeryCode { get; set; }
        public Nullable<int> quantity { get; set; }
        public Nullable<int> availableQty { get; set; }
        public string binNo { get; set; }
    
        public virtual Stationery Stationery { get; set; }
    }
}