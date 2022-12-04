namespace DemoApplication.ViewModels.Admin.SubNavbar
{
    public class UpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ToURL { get; set; }
        public int Order { get; set; }

        public int NavbarId { get; set; }

        public List<NavbarListItemViewModel>? Navbars { get; set; }

        public UpdateViewModel(int id, string name, string toURL, int order, int navbarid)
        {
            Id = id;
            Name = name;
            ToURL = toURL;
            Order = order;
            NavbarId = navbarid;
        }
        public UpdateViewModel()
        {

        }
    }
}
