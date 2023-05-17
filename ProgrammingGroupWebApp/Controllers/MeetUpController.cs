using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingGroupWebApp.Data;
using ProgrammingGroupWebApp.Interfaces;
using ProgrammingGroupWebApp.Models;
using ProgrammingGroupWebApp.Repo;
using ProgrammingGroupWebApp.Services;
using ProgrammingGroupWebApp.ViewModel;
using System.Text.RegularExpressions;

namespace ProgrammingGroupWebApp.Controllers
{
    public class MeetUpController : Controller
    {
        private readonly IMeetRepo _meetRepo;
        private readonly IPhotoService _photoService;

        public MeetUpController(IMeetRepo MeetRepo, IPhotoService PhotoService)
        {
            _meetRepo = MeetRepo;
            _photoService = PhotoService;
        }

        public async Task<IActionResult> Index()
        {

            IEnumerable<CodingMeetUp> codingMeetUps = await _meetRepo.GetAll();
            return View(codingMeetUps);
        }

        public async Task<IActionResult> Detail(int Id)
        {
            CodingMeetUp codingMeetUp = await _meetRepo.GetByIdAync(Id);
            return View(codingMeetUp);
        }

        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MeetUpViewModel meetUpVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(meetUpVM.Image);

                var Teams = new CodingMeetUp
                {
                    Title = meetUpVM.Title,
                    Description = meetUpVM.Description,
                    Image = result.Url.ToString(),
                    Language = new AddLanguage
                    {
                        Name = meetUpVM.Language.Name,
                        Language = meetUpVM.Language.Language,
                        City = meetUpVM.Language.City,
                        Description = meetUpVM.Language.Description,
                    }
                };

                _meetRepo.Add(Teams);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo Uplaod Failed");
            }
            return View(meetUpVM);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var meetUp = await _meetRepo.GetByIdAync(Id);
            if (meetUp == null) return View("Error");
            var meetUpVM = new EditMeetUpViewModel
            {
                Title = meetUp.Title,
                Description = meetUp.Description,
                LangId = meetUp.LangId,
                Language = meetUp.Language,
                URL = meetUp.Image,
                MeetUpCategory = meetUp.MeetUpCategory,
            };
            return View(meetUpVM);

        }


        [HttpPost]
        public async Task<IActionResult> Edit(int Id, EditMeetUpViewModel MeetUpViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please correct the errors in the form, failed to EDIT group");
                return View(MeetUpViewModel);
            }

            var userGroup = await _meetRepo.GetByIdAyncNoTracking(Id);
            if (userGroup != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userGroup.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delte Photo");
                    return View(MeetUpViewModel);
                }
                var photoResult = await _photoService.AddPhotoAsync(MeetUpViewModel.Image);
                var MeetUp = new CodingMeetUp
                {
                    Id = Id,
                    Title = MeetUpViewModel.Title,
                    Description = MeetUpViewModel.Description,
                    LangId = MeetUpViewModel.LangId,
                    Language = MeetUpViewModel.Language,
                    Image = photoResult.Url.ToString(),
                    MeetUpCategory = MeetUpViewModel.MeetUpCategory,
                };
                _meetRepo.Update(MeetUp);

                return RedirectToAction("Index");
            }
            else
            {
                return View(MeetUpViewModel);
            }
        }
    }
}
