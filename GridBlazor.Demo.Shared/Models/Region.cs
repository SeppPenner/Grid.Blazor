//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace GridBlazor.Demo.Shared.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Region
    {
        public Region()
        {
            this.Territories = new HashSet<Territory>();
        }
        [Key]
        public int RegionID { get; set; }
        public string RegionDescription { get; set; }
    
        public virtual ICollection<Territory> Territories { get; set; }
    }
}
