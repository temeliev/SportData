using System.Collections.Generic;

namespace SportData.Web.Models.Admin
{
    public class SearchFootballPlayerViewModel : BaseViewModel
    {
        public int TeamId { get; set; }

        public string PlayerName { get; set; }

        public string SearchText { get; set; }

        public List<FootballTeamPlayerViewModel> FoundPlayers { get; set; }
    }
}