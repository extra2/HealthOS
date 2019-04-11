using System.Collections.Generic;
using System.Linq;
using HealthOS.Data;
using HealthOS.Models;
using HealthOS.Models.HelperModels;
using HealthOS.Repositories.Interfaces;
using HealthOS.ViewModels;
using HealthOS.ViewModels.Patient;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthOS.Controllers
{
    public class DoctorController : Controller
    {
        #region Private fields
        private ApplicationUser _user;
        private readonly IUserRepository _userRepository;
        private readonly IVisitsRepository _vistisRepository;
        private readonly IChatRepository _chatRepository;
        #endregion 
        public DoctorController(ApplicationDbContext context, IVisitsRepository vistisRepository, IChatRepository chatRepository, IUserRepository userRepository)
        {
            _vistisRepository = vistisRepository;
            _chatRepository = chatRepository;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var model = new DoctorViewModel
            {
                AppUser = _userRepository.Get(User.Identity.GetUserId())
            };
            return View(model);
        }

        public IActionResult MyPatients()
        {
            var viewModel = new MyPatientsViewModel
            {
                ApplicationUsers = _userRepository.GetMyPatients(User.Identity.GetUserId())
            };
            return View(viewModel);
        }

        [Route("MyPatient/{id}")]
        public IActionResult MyPatient(string id)
        {
            var viewModel = new MyPatientViewModel
            {
                ApplicationUser = _userRepository.GetAllMyPatientData(id)
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
        public IActionResult PersonalData()
        {
            _user = _userRepository.GetWithDiseasesAndAllergies(User.Identity.GetUserId());
            var viewModel = new PersonalDataViewModel
            {
                ApplicationUser = _user
            };
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
            possibleReceivers.AddRange(_userRepository.GetAuthorizedPatients(User.Identity.GetUserId()));
            foreach (var possibleReceiver in possibleReceivers)
            {
                listOfReceivers.Add(new SendToModel
                {
                    MessageReveiverName = possibleReceiver.AuthorizedPatients.Name + " " + possibleReceiver.AuthorizedPatients.Surname,
                    MessageReceiverId = possibleReceiver.AuthorizedPatients.Id
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