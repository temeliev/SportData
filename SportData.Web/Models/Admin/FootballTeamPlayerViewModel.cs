using System;
using System.ComponentModel.DataAnnotations;

namespace SportData.Web.Models.Admin
{
    public class FootballTeamPlayerViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public int TeamId { get; set; }

        public int PlayerId { get; set; }

        [Display(Name = "Футболист")]
        public string PlayerFullName { get; set; }

        [Display(Name = "Начало на престоя")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Край на престоя")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Статус")]
        public int PlayerStatusId { get; set; }

        [Display(Name = "Статус")]
        public string PlayerStatusName { get; set; }

        [Display(Name = "Държава")]
        public string LocationName { get; set; }

        [Display(Name = "Флаг")]
        public string NationalityImageUrl { get; set; }
    }
}