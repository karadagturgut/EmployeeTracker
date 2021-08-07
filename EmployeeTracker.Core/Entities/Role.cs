using Microsoft.AspNetCore.Identity;

namespace EmployeeTracker.Core.Entities
{
    public class Role:IdentityRole<int>,IBaseEntity
    {
        
    }
}