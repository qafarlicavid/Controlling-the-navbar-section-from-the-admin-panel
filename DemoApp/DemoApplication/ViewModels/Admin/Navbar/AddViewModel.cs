using System.ComponentModel.DataAnnotations;

namespace DemoApplication.ViewModels.Admin.Navbar
{
    public class AddViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ToURL { get; set; }
        public int Order { get; set; }
        public bool IsMain { get; set; }

        [Required]
        public bool IsOnHeader { get; set; }

        [Required]
        public bool IsOnFooter { get; set; }

        public AddViewModel(int id, string name, string toURL, int order, bool isMain, bool isOnHeader, bool isOnFooter)
        {
            Id = id;
            Name = name;
            ToURL = toURL;
            Order = order;
            IsMain = isMain;
            IsOnHeader = isOnHeader;
            IsOnFooter = isOnFooter;
        }
        public AddViewModel()
        {

        }
    }
}
