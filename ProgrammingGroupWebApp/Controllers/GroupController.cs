using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProgrammingGroupWebApp.Data;
using ProgrammingGroupWebApp.Interfaces;
using ProgrammingGroupWebApp.Models;
using ProgrammingGroupWebApp.ViewModel;
using static System.Net.Mime.MediaTypeNames;

namespace ProgrammingGroupWebApp.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupRepo _groupRepo;
        public readonly IPhotoService _photoService;

        public GroupController(IGroupRepo groupRepo, IPhotoService photoService)
        {
            _groupRepo = groupRepo;
            _photoService = photoService;
        } 

        public async Task<IActionResult> Index()
        {
            IEnumerable<Group> group = await _groupRepo.GetAll();
            return View(group);
        }

        public async Task<IActionResult> Detail(int Id)
        {
            Group groups = await _groupRepo.GetByIdAync(Id);
            return View(groups);
        }

        public IActionResult create() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateGroupViewModel groupVM)
        {
            if(ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(groupVM.Image);
                if(result != null)
                {
                    var group = new Group
                    {
                        Id = groupVM.Id,
                        Title = groupVM.Title,
                        Description = groupVM.Description,
                        Image = result.Url.ToString(),
                        Language = new AddLanguage
                        {
                            Name = groupVM.Language.Name,
                            Language = groupVM.Language.Language,
                            City = groupVM.Language.City,
                            Description = groupVM.Language.Description,
                        }
                    };

                    _groupRepo.Add(group);
                    return RedirectToAction("Index");

                }
                else { return NotFound(); }
            }
            else
            {
                ModelState.AddModelError("", "Photo Uplaod Failed");
            }
            return View(groupVM);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var group = await _groupRepo.GetByIdAync(Id);
            if (group == null) return View("Error");
            var groupVm = new EditViewModel
            {
                Title = group.Title,
                Description = group.Description,
                LangId = group.LangId,
                Language = group.Language,
                URL = group.Image,
                GroupCategory = group.GroupCategory,
            };
            return View(groupVm);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, EditViewModel GroupViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Please correct the errors in the form, failed to EDIT group");
                return View(GroupViewModel);
            }

            var userGroup = await _groupRepo.GetByIdAyncNoTracking(Id);
            if (userGroup != null)
            {
                try
                {
                    await _photoService.DeletePhotoAsync(userGroup.Image);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Could not delte Photo");
                    return View(GroupViewModel);
                }
                var photoResult = await _photoService.AddPhotoAsync(GroupViewModel.Image);
                var Group = new Group
                {
                    Id = Id,
                    Title = GroupViewModel.Title,
                    Description = GroupViewModel.Description,
                    LangId = GroupViewModel.LangId,
                    Language = GroupViewModel.Language,
                    Image = photoResult.Url.ToString(),
                    GroupCategory = GroupViewModel.GroupCategory,
                };
                _groupRepo.Update(Group);

                return RedirectToAction("Index");
            }
            else
            {
                return View(GroupViewModel);
            }
        }

    }
}
