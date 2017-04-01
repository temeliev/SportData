using Microsoft.AspNet.Identity.EntityFramework;

namespace SportData.Data.Entities.Identity
{
    public class ApplicationRole : IdentityRole<long, ApplicationUserRole>
    {
        public ApplicationRole() { }

        public ApplicationRole(string name)
        {
            Name = name;
        }
    }
}
