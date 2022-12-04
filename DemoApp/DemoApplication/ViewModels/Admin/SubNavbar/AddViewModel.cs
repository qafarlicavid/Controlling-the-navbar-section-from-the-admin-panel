namespace DemoApplication.ViewModels.Admin.SubNavbar
{
    public class AddViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ToURL { get; set; }
        public int Order { get; set; }

        public int NavbarId { get; set; }

        public List<NavbarListItemViewModel>? Navbar { get; set; }

    }
}
