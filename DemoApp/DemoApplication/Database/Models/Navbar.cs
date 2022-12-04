using DemoApplication.Database.Models.Common;

namespace DemoApplication.Database.Models
{
    public class Navbar : BaseEntity
    {
        public string Name { get; set; }
        public string ToURL { get; set; }
        public int Order { get; set; }
        public bool  IsMain { get; set; }

        public bool IsOnHeader { get; set; }
        public bool IsOnFooter { get; set; }

        public List<SubNavbar> subNavbars { get; set; }

    }
}
