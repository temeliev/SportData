using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("AddressInfo")]
    public class AddressInfo
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "nvarchar")]
        public string Address { get; set; }

        public int CountryId { get; set; }

        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string NameOfState { get; set; }

        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string NameOfTown { get; set; }

        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string PostalCode { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CDate { get; set; }

        public virtual Location Country { get; set; }
    }
}
