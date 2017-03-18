using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("UserAccounts")]
    public class UserAccount
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string Username { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string Password { get; set; }

        public long ContactId { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsActive { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CDate { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
