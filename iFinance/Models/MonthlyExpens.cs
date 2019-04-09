namespace iFinance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MonthlyExpenses")]
    public partial class MonthlyExpens
    {
        [Key]
        public int TransactionID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Amount { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
    }
}
