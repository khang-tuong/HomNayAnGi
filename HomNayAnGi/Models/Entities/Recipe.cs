//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HomNayAnGi.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recipe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recipe()
        {
            this.Comments = new HashSet<Comment>();
            this.Ingredients = new HashSet<Ingredient>();
            this.Payments = new HashSet<Payment>();
            this.Steps = new HashSet<Step>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public int authorId { get; set; }
        public int dishId { get; set; }
        public int status { get; set; }
        public double rating { get; set; }
        public int rateQuantity { get; set; }
        public int viewQuantity { get; set; }
        public System.DateTime dateCreated { get; set; }
        public Nullable<int> type { get; set; }
        public decimal price { get; set; }
        public Nullable<System.DateTime> dateApproved { get; set; }
        public string seoName { get; set; }
    
        public virtual Account Account { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Dish Dish { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Step> Steps { get; set; }
    }
}
