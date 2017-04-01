using Microsoft.AspNet.Identity.EntityFramework;

namespace SportData.Data.Entities.Identity
{
    public class ApplicationRoleStore : RoleStore<ApplicationRole, long, ApplicationUserRole>
    {
        public ApplicationRoleStore(SportDataContext context) : base(context)
        {
        }
    }
}
