//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class GrocsharyItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GrocsharyItem()
        {
            this.SendReceiveRequests = new HashSet<SendReceiveRequest>();
        }
    
        public int itemId { get; set; }
        public string itemDescription { get; set; }
        public string exchangeItem { get; set; }
        public Nullable<int> user_id { get; set; }
        public string imageName { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public System.DateTime createdDate { get; set; }
        public System.DateTime modifiedDate { get; set; }
        public string ItemName { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual UsersInfo UsersInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SendReceiveRequest> SendReceiveRequests { get; set; }
    }
}
