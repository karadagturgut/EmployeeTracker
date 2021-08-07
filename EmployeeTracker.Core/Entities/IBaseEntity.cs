using Microsoft.AspNetCore.Identity;

namespace EmployeeTracker.Core.Entities
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
    }
}