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
    
    public partial class GCM
    {
        public int id { get; set; }
        public string empNo { get; set; }
        public string registrationID { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}