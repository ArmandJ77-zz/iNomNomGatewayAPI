using AutoMapper;
using Domain.Employees.DTO;
using Domain.User.DTO;
using ExternalPythonService.Domain.Employees.DTO;
using System.Collections.Generic;

namespace Domain.Employees.Mapping
{
    public class EmployeesMapping: Profile
    {
        public EmployeesMapping()
        {
            
            CreateMap<position, PositionDto>()
                .ReverseMap();

            CreateMap<ExternalPythonService.Domain.Employees.DTO.User, UserDto>()
                .ReverseMap();

            CreateMap<employee, EmployeeDto>()
                .ReverseMap();

            CreateMap<List<employee>, List<EmployeeDto>>()
                .AfterMap((s, d, context) =>
                {
                    s.ForEach(x => d.Add(context.Mapper.Map<employee, EmployeeDto>(x)));
                })
                .ReverseMap();
        }
    }
}
