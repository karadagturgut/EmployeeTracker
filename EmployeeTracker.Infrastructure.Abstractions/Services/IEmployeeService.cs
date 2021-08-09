using System.Collections.Generic;

namespace EmployeeTracker.Infrastructure.Abstractions.Services
{
    public interface IEmployeeService:IScopedService
    {
        List<EmployeeResponseDto> GetAll();
        List<EmployeeResponseDto> GetByName(string name);
    }

    public class EmployeeRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
    }
    
    public class EmployeeResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public double WeeklyWage { get; set; }
    }

}