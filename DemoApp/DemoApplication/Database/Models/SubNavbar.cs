using DemoApplication.Database.Models.Common;

namespace DemoApplication.Database.Models
{
    public class SubNavbar : BaseEntity
    {
        public string Name { get; set; }
        public string ToURL { get; set; }
        public int Order { get; set; }

        public int NavbarId { get; set; }
        public Navbar Navbar { get; set; }

    }
}
