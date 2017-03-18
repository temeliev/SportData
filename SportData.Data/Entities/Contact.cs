﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportData.Data.Entities
{
    [Table("Contacts")]
    public class Contact
    {
        public Contact()
        {
            this.UserAccounts = new List<UserAccount>();
        }

        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string FirstName { get; set; }

        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string SecondName { get; set; }

        [Required]
        [MaxLength(250)]
        [Column(TypeName = "nvarchar")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(1)]
        [Column(TypeName = "nchar")]
        public string Gender { get; set; }

        [ForeignKey("AddressInfo")]
        public long AddressId { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CDate { get; set; }

        public virtual AddressInfo AddressInfo { get; set; }

        public ICollection<UserAccount> UserAccounts { get; set; }
    }
}
