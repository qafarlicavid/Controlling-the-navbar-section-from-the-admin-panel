using DemoApplication.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.ViewComponents
{
    [ViewComponent(Name = "NavbarFooter")]
    public class NavbarFooterViewComponent : ViewComponent
    {
        private readonly DataContext _dataContext;
        public NavbarFooterViewComponent(DataContext applicationDbContext)
        {
            _dataContext = applicationDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _dataContext.Navbars
                .Include(n => n.subNavbars.OrderBy(sn => sn.Order))
                .Where(n => n.IsOnFooter).OrderBy(n => n.Order).ToList();

            return View("~/Views/Shared/Components/Navbar/NavbarFooter.cshtml", model);

        }
    }
}