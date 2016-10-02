using MoveIt.Contracts.Repositories;
using MoveIt.Models;
using MoveIt.Services;
using MoveIt.WebUi.ViewModels;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace MoveIt.WebUi.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private IRepository<ApplicationUser> _users;
        private IRepository<TournamentEvent> _tournamentEvents;

        public HomeController(
            IRepository<ApplicationUser> users,
            IRepository<TournamentEvent> tournamentEvents)
        {
            this._users = users;
            this._tournamentEvents = tournamentEvents;
        }

        public ActionResult Index()
        {
            var tournamentEvents =
                _tournamentEvents
                .GetAll()
                .Select(TournamentEventViewModel.FromTournamentEvent)
                .ToList();

            return View(tournamentEvents);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public void Upload()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                var faceRecognition = new FaceRecognitionService();

                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(Server.MapPath("~/App_Data/"), fileName);
                file.SaveAs(path);

                var temp = faceRecognition.UploadAndDetectFaces(path);
            }

        }
    }
}