namespace iFinance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonthlyIncome")]
    public partial class MonthlyIncome
    {
        [Key]
        public int IncomeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Origin { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
    }
}
