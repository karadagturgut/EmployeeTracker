using Microsoft.AspNetCore.Identity;

namespace EmployeeTracker.Core.Entities
{
    public class User:IdentityUser<int>,IBaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }


    }
}