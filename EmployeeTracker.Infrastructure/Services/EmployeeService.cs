using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeTracker.Core.Entities;
using EmployeeTracker.Infrastructure.Abstractions.Services;

namespace EmployeeTracker.Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeTrackerDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeService(EmployeeTrackerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<EmployeeResponseDto> GetAll()
        {
            var getAll = _dbContext.Employees.ToList();
            var result = _mapper.Map<List<Employee>, List<EmployeeResponseDto>>(getAll);
            return result;
        }

        public List<EmployeeResponseDto> GetByName(string name)  // EmployeeRequestDTO mu kullanmalı? 
        {
            var getByNameList = _dbContext.Employees.Where(x => x.Name.Equals(name)).ToList();
            var result = _mapper.Map<List<Employee>,List<EmployeeResponseDto>>(getByNameList);
            return result;
        }

    }
}