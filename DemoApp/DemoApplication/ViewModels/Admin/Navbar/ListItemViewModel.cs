namespace DemoApplication.ViewModels.Admin.Navbar
{
    public class ListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ToURL { get; set; }
        public int Order { get; set; }

        public bool IsOnHeader { get; set; }
        public bool IsOnFooter { get; set; }

        public ListItemViewModel(int id, string name, string toURL, int order, bool isOnHeader, bool isOnFooter)
        {
            Id = id;
            Name = name;
            ToURL = toURL;
            Order = order;
            IsOnHeader = isOnHeader;
            IsOnFooter = isOnFooter;
        }

    }
}
