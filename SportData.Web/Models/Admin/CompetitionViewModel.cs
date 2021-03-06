﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportData.Web.Models.Admin
{
    public class CompetitionViewModel : BaseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        [Required(ErrorMessage = "Въведете име на състезанието!")]
        public string Name { get; set; }

        public int? OriginalCompetitionId { get; set; }

        [Display(Name = "Локация")]
        [Required(ErrorMessage = "Въведете локация!")]
        public int LocationId { get; set; }

        [Display(Name = "Локация")]
        public string LocationName { get; set; }

        [Display(Name = "Иконка")]
        public string CompetitionImageUrl { get; set; }

        [Display(Name = "Активен")]
        public bool IsActive { get; set; }

        [Display(Name = "Тип")]
        public string CompetitionTypeName { get; set; }

        [Display(Name = "Тип")]
        [Required(ErrorMessage = "Въведете тип на състезанието!")]
        public int CompetitionTypeId { get; set; }

        public List<CompetitionCultureViewModel> Cultures { get; set; }

        public List<CompetitionViewModel> History { get; set; }
    }
}