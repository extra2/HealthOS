using System;
using System.Collections.Generic;
using System.Linq;
using HealthOS.Models;
using HealthOS.Models.HelperModels;
using HealthOS.Models.Statistics;
using HealthOS.Models.ViewModels;
using HealthOS.Repositories.Interfaces;
using HealthOS.Services;
using HealthOS.ViewModels;
using HealthOS.ViewModels.Patient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.Identity;

namespace HealthOS.Controllers
{
    public class PatientController : Controller
    {
        #region Private fields
        private ApplicationUser _user;
        private readonly IUserRepository _userRepository;
        private readonly IVisitsRepository _vistisRepository;
        private readonly IChatRepository _chatRepository;
        #endregion

        #region ctor
        public PatientController(IUserRepository userRepository, IVisitsRepository vistisRepository, IChatRepository chatRepository)
        {
            _userRepository = userRepository;
            _vistisRepository = vistisRepository;
            _chatRepository = chatRepository;
        }
        #endregion
        public IActionResult Index()
        {
            var model = new PatientViewModel
            {
                AppUser = _userRepository.Get(User.Identity.GetUserId())
            };
            return View(model);
        }
        [Route("BloodPressure/{page?}")]
        public IActionResult BloodPressure(int page = 0)
        {
            _user = _userRepository.GetWithBloodPressure(User.Identity.GetUserId());
            var (statistics, chartPoints) = ChartDatapointsService.PrepareBloodPressureStatistics(_user, page);
            var viewModel = new BloodPressureStatisticsViewModel
            {
                ApplicationUser = _user,
                BloodPreasureStatistics = statistics ?? new List<BloodPressureStatistics>(),
                ChartDataPoints = chartPoints,
                PageNumber = page,
                MonthName = ((MonthName)((DateTime.Now.Month + page) % 12)).ToString("G")
            };
            return View(viewModel);
        }
        [Route("Glucose/{page?}")]
        public IActionResult Glucose(int page = 0)
        {
            _user = _userRepository.GetWithBloodGlucoseLevel(User.Identity.GetUserId());
            var (statistics, chartPoints) = ChartDatapointsService.PrepareGlucoseLevelStatistics(_user, page);
            var viewModel = new GlucoseLevelStatisticsViewModel()
            {
                ApplicationUser = _user,
                GlucoseStatistics = statistics ?? new List<GlucoseLevelStatistics>(),
                ChartDataPoints = chartPoints,
                PageNumber = page,
                MonthName = ((MonthName)((DateTime.Now.Month + page) % 12)).ToString("G")
            };
            return View(viewModel);
        }
        [Route("Height/{page?}")]
        public IActionResult Height(int page = 0)
        {
            _user = _userRepository.GetWithHeight(User.Identity.GetUserId());
            var (statistics, chartPoints) = ChartDatapointsService.PrepareHeightStatistics(_user, page);
            var viewModel = new HeightStatisticsViewModel()
            {
                ApplicationUser = _user,
                HeightStatistics = statistics ?? new List<HeightStatistics>(),
                ChartDataPoints = chartPoints,
                PageNumber = page,
                MonthName = ((MonthName)((DateTime.Now.Month + page) % 12)).ToString("G")
            };
            return View(viewModel);
        }
        [Route("Weight/{page?}")]
        public IActionResult Weight(int page = 0)
        {
            _user = _userRepository.GetWithWeight(User.Identity.GetUserId());
            var (statistics, chartPoints) = ChartDatapointsService.PrepareWeightStatistics(_user, page);
            var viewModel = new WeightStatisticsViewModel()
            {
                ApplicationUser = _user,
                WeightStatistics = statistics ?? new List<WeightStatistics>(),
                ChartDataPoints = chartPoints,
                PageNumber = page,
                MonthName = ((MonthName)((DateTime.Now.Month + page) % 12)).ToString("G")
            };
            return View(viewModel);
        }

        [Route("CustomStatistics/{page?}")]
        public IActionResult CustomStatistics(int page = 0)
        {
            //_user = _userRepository.GetWithWeight(User.Identity.GetUserId());
            //var viewModel = new CustomStatisticsViewModel()
            //{
            //    ApplicationUser = _user,
            //    CustomStatistics = ChartDatapointsService.PrepareCustomStatistics(_user, page),
            //    PageNumber = page,
            //    MonthName = ((MonthName)((DateTime.Now.Month + page) % 12)).ToString("G")
            //};
            return View(/*viewModel*/null);
        }
        //TODO: custom statistics

        public IActionResult DrugList()
        {
            _user = _userRepository.GetWithDrugs(User.Identity.GetUserId());
            var viewModel = new DrugsViewModel
            {
                Drugs = _user.Drugs.ToList(),
                User = _user,
                DrugsReminder = DrugsService.GetDrugsForToday(_user.Drugs.ToList())
            };
            return View(viewModel);
        }
        public IActionResult Diseases()
        {
            _user = _userRepository.GetWithDiseasesAndAllergies(User.Identity.GetUserId());
            var viewModel = new DiseasesViewModel
            {
                ApplicationUser = _user,
                Allergies = _user.Allergies.ToList(),
                Diseases = _user.Diseases.ToList()
            };
            return View(viewModel);
        }
        public IActionResult PersonalData()
        {
            _user = _userRepository.GetWithDiseasesAndAllergies(User.Identity.GetUserId());
            var viewModel = new PersonalDataViewModel
            {
                ApplicationUser = _user
            };
            return View(viewModel);
        }
        public IActionResult MyDoctors()
        {
            _user = _userRepository.Get(User.Identity.GetUserId());
            var relations = _userRepository.GetAuthorizedDoctors(User.Identity.GetUserId());
            var viewModel = new AuthorizedDoctoraViewModel
            {
                ApplicationUser = _user,
                Relations = relations
            };
            return View(viewModel);
        }
        public IActionResult DoctorVisits()
        {
            _user = _userRepository.Get(User.Identity.GetUserId());
            var viewModel = new NextDoctorVisitViewModel
            {
                ApplicationUser = _user,
                NextDoctorVisits = _vistisRepository.GetDoctorVisits(_user.Id).OrderBy(w => w.VisitTime).ToList()
            };
            return View(viewModel);
        }

        public IActionResult ChatList()
        {
            var viewModel = new ChatMainInboxViewModel
            {
                ChatMainInbox = GetMessages(),
                Users = SendToUsers(),
                ApplicationUser = _userRepository.Get(User.Identity.GetUserId())
            };
            return View(viewModel);
        }

        public IActionResult ChatWith(string id)
        {
            var viewModel = new ChatWithUserViewModel
            {
                CurreentUser = _userRepository.Get(User.Identity.GetUserId()),
                ConversationUser = _userRepository.Get(id),
                ChatMessages = GetConversationMessages(id)
            };
            SetSeen(id, User.Identity.GetUserId());
            return View(viewModel);
        }

        #region Helpers
        private List<ChatMainInboxModel> GetMessages()
        {
            var currentUserId = User.Identity.GetUserId();
            var messages = _chatRepository.Chats(User.Identity.GetUserId()).OrderByDescending(t => t.SentDate).ToList();
            var lastMessages = new List<ChatMainInboxModel>();
            while (messages.Any())
            {
                if (messages.First().UserFrom.Id != currentUserId)
                {
                    lastMessages.Add(new ChatMainInboxModel
                    {
                        Seen = messages.First().Seen,
                        SentDate = messages.First().SentDate,
                        Title = messages.First().Title,
                        UserId = messages.First().UserFrom.Id,
                        UserName = messages.First().UserFrom.Name + " " + messages.First().UserFrom.Surname
                    });
                    string id = messages.First().UserFrom.Id;
                    messages.RemoveAll(m => m.UserFrom.Id == id || m.UserTo.Id == id);
                }
                else
                {
                    if (!messages.Any()) break;
                    lastMessages.Add(new ChatMainInboxModel
                    {
                        Seen = true,
                        SentDate = messages.First().SentDate,
                        Title = messages.First().Title,
                        UserId = messages.First().UserTo.Id,
                        UserName = messages.First().UserTo.Name + " " + messages.First().UserTo.Surname
                    });
                    string id = messages.First().UserTo.Id;
                    messages.RemoveAll(m => m.UserFrom.Id == id || m.UserTo.Id == id);
                }
            }
            return lastMessages;
        }

        private List<SendToModel> SendToUsers()
        {
            var possibleReceivers = new List<Relation>();
            var listOfReceivers = new List<SendToModel>();
            possibleReceivers.AddRange(_userRepository.GetAuthorizedDoctors(User.Identity.GetUserId()));
            foreach (var possibleReceiver in possibleReceivers)
            {
                listOfReceivers.Add(new SendToModel
                {
                    MessageReveiverName = possibleReceiver.AuthorizedDoctors.Name + " " + possibleReceiver.AuthorizedDoctors.Surname,
                    MessageReceiverId = possibleReceiver.AuthorizedDoctors.Id
                });
            }
            return listOfReceivers;
        }
        private List<ChatMessage> GetConversationMessages(string id)
        {
            return _chatRepository.GetChat(id, User.Identity.GetUserId());
        }
        private void SetSeen(string from, string to)
        {
            _chatRepository.SetSeen(from, to);
        }
        #endregion
    }
}