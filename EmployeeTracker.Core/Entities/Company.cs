using System;

namespace EmployeeTracker.Core.Entities
{
    public class Company:IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string OfficialPerson { get; set; }
    }
}