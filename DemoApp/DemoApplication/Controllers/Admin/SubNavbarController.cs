using DemoApplication.Database;
using DemoApplication.Database.Models;
using DemoApplication.ViewModels.Admin.SubNavbar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Controllers.Admin
{
    public class SubNavbarController : Controller
    {
        private readonly DataContext _dataContext;

        public SubNavbarController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        #region List

        [HttpGet("list", Name = "admin-subnavbar-list")]
        public async Task<IActionResult> ListAsync()
        {
            var model = await _dataContext.SubNavbars
                .Select(a => new SubNavbarListItemViewModel(a.Id, a.Name, a.ToURL, a.Order, a.Navbar.Name))
                .ToListAsync();

            return View("~/Views/Admin/SubNavbar/List.cshtml", model);
        }

        #endregion

        #region Add

        [HttpGet("add", Name = "admin-subnavbar-add")]
        public async Task<IActionResult> AddAsync()
        {
            var model = new AddViewModel
            {
                Navbar = await _dataContext.Navbars.Select(n => new NavbarListItemViewModel(n.Id, n.Name)).ToListAsync()
            };
            return View("~/Views/Admin/SubNavbar/Add.cshtml", model);
        }

        [HttpPost("add", Name = "admin-subnavbar-add")]
        public async Task<IActionResult> AddAsync(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("~/Views/Admin/SubNavbar/Add.cshtml", model);
            }

            if (!_dataContext.Navbars.Any(n => n.Id == model.NavbarId))
            {
                ModelState.AddModelError(String.Empty, "This order using");
                return View("~/Views/Admin/SubNavbar/Add.cshtml");
            }

            var subnavbar = new SubNavbar
            {
               
                Name = model.Name,
                ToURL = model.ToURL,
                Order = model.Order,
                NavbarId = model.NavbarId

            };
            await _dataContext.SubNavbars.AddAsync(subnavbar);
             _dataContext.SaveChanges();

            return RedirectToRoute("admin-subnavbar-list");

        }


        #endregion

        #region Update

        [HttpGet("update/{id}", Name = "admin-subnavbar-update")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id)
        {
            var subnavbar = await _dataContext.SubNavbars.FirstOrDefaultAsync(b => b.Id == id);
            if (subnavbar is null)
            {
                return NotFound();
            }

            var model = new UpdateViewModel
            {
                Name = subnavbar.Name,
                ToURL = subnavbar.ToURL,
                Order = subnavbar.Order,
                Navbars = _dataContext.Navbars.Select(n => new NavbarListItemViewModel(n.Id, n.Name)).ToList()

        };

            return View("~/Views/Admin/SubNavbar/Update.cshtml", model);
        }

        [HttpPost("update/{id}", Name = "admin-subnavbar-update")]
        public async Task<IActionResult> UpdateAsync(UpdateViewModel model)
        {
            var subnavbar = await _dataContext.SubNavbars.Include(n=>n.Navbar).FirstOrDefaultAsync(n => n.Id == model.Id);
            if (subnavbar is null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View("~/Views/Admin/SubNavbar/Update.cshtml");
            }


            subnavbar.Name = model.Name;
            subnavbar.ToURL = model.ToURL;
            subnavbar.Order = model.Order;
            subnavbar.NavbarId = model.NavbarId;

            await _dataContext.SaveChangesAsync();
            return RedirectToRoute("admin-subnavbar-list");
        }

        #endregion



        #region Delete

        [HttpPost("delete/{id}", Name = "admin-subnavbar-delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var subnavbar = await _dataContext.SubNavbars.FirstOrDefaultAsync(b => b.Id == id);
            if (subnavbar is null)
            {
                return NotFound();
            }

            _dataContext.SubNavbars.Remove(subnavbar);
            await _dataContext.SaveChangesAsync();

            return RedirectToRoute("admin-subnavbar-list");
        }

        #endregion
    }
}
