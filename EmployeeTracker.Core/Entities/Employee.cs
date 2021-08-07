namespace EmployeeTracker.Core.Entities
{
    public class Employee:IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double DailyWage { get; set; }
    }
}