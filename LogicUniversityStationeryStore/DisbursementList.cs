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
    
    public partial class DisbursementList
    {
        public DisbursementList()
        {
            this.Requests = new HashSet<Request>();
        }
    
        public int id { get; set; }
        public string deptCode { get; set; }
        public Nullable<int> collectionPt { get; set; }
        public System.DateTime deliveryDate { get; set; }
        public string clerkEmpNo { get; set; }
    
        public virtual CollectionPoint CollectionPoint { get; set; }
        public virtual Department Department { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}