using System.Web.Mvc;

namespace MoveIt.WebUi.Controllers
{
    using Contracts.Repositories;
    using Models;
    using System.Linq;
    using ViewModels;

    public class GameLobbyController : Controller
    {
        private IRepository<ApplicationUser> _users;
        private IRepository<TournamentEvent> _tournamentEvents;
        private IRepository<Team> _teams;

        public GameLobbyController(
            IRepository<ApplicationUser> users,
            IRepository<TournamentEvent> tournamentEvents,
            IRepository<Team> teams )
        {
            this._users = users;
            this._tournamentEvents = tournamentEvents;
            this._teams = teams;
        }

        public ActionResult Index()
        {
            var teams =
                _teams
                .GetAll()
                .Select(TeamViewModel.FromTeam)
                .ToList();

            return View(teams);
        }
    }
}