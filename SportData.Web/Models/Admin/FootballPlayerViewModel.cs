using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportData.Web.Models.Admin
{
    public class FootballPlayerViewModel : BaseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Въведете име на футболиста!")]
        public string FirstName { get; set; }

        [Display(Name = "Презиме")]
        public string SecondName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Въведете фамилия на футболиста!")]
        public string LastName { get; set; }

        [Display(Name = "Националност")]
        [Required(ErrorMessage = "Въведете фамилия на футболиста!")]
        public int NationalityId { get; set; }

        public string NationalityImageUrl { get; set; }

        [Display(Name = "Линк")]
        public string PlayerImageUrl { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата на раждане")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Държава")]
        public string LocationName { get; set; }

        public  int FootballTeamPlayerId { get; set; }
        
        public List<FootballPlayerCultureViewModel> Cultures { get; set; }
    }
}