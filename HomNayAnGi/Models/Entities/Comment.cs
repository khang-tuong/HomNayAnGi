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
    
    public partial class Comment
    {
        public int id { get; set; }
        public int userId { get; set; }
        public Nullable<int> recipeId { get; set; }
        public string content { get; set; }
        public Nullable<int> postId { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Post Post { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
