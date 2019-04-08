namespace iFinance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [Key]
        public int UsersID { get; set; }

        [Required]
        [StringLength(500)]
        public string Username { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }
    }
}
