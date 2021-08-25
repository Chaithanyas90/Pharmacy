using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pharmacy.Dal
{
    public class Medicine
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        public string FullName { get; set; }
        [StringLength(50)]
        public string Brand { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        [StringLength(500)]
        public string Notes { get; set; }

    }
}
