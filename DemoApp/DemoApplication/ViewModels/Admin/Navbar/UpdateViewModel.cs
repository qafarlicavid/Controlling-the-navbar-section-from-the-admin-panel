namespace DemoApplication.ViewModels.Admin.Navbar
{
    public class UpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ToURL { get; set; }
        public int Order { get; set; }
        public bool IsMain { get; set; }

        public bool IsOnHeader { get; set; }
        public bool IsOnFooter { get; set; }

        public UpdateViewModel(int id, string name, string toURL, int order, bool isMain, bool isOnHeader, bool isOnFooter)
        {
            Id = id;
            Name = name;
            ToURL = toURL;
            Order = order;
            IsMain = isMain;
            IsOnHeader = isOnHeader;
            IsOnFooter = isOnFooter;
        }
        public UpdateViewModel()
        {

        }
    }
}
