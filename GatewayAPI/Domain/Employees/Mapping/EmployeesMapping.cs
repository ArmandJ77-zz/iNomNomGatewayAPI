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
                .ForPath(s => s.User.Id, d => d.MapFrom(x => x.user.id))
                .ForPath(s => s.User.IsActive, d => d.MapFrom(x => x.user.is_active))
                .ForPath(s => s.User.IsStaff, d => d.MapFrom(x => x.user.is_staff))

                .ForPath(s => s.User.FirstName, d => d.MapFrom(x => x.user.first_name))
                .ForPath(s => s.User.LastName, d => d.MapFrom(x => x.user.last_name))
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
