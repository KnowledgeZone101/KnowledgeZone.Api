using AutoMapper;
using KnowledgeZone.Domain.DTOs.Department;
using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;
using KnowledgeZone.Infrastructure;
using Microsoft.Extensions.Logging;

namespace KnowledgeZone.Service
{
    public class DeapartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly KnowledgeZoneDbContext _context;
        private readonly ILogger<DeapartmentService> _logger;
        
        public DeapartmentService(IMapper mapper, KnowledgeZoneDbContext context, ILogger<DeapartmentService> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }
        public PaginatedList<DepartmentDto> GetDepartment(DepartmentResourceParamentrs departmentParameters)
        {
            var query = _context.Departments.AsQueryable();
            if (!string.IsNullOrEmpty(departmentParameters.SearchString))
            {
                query = query.Where(d => d.Name.Contains(departmentParameters.SearchString));
            }

            if(departmentParameters is not null)
            {
                switch (departmentParameters.OrderBy)
                {
                    case "name":
                        query = query.OrderBy(d => d.Name); break;
                    case "name_desc":
                        query = query.OrderByDescending(d => d.Name); break;
                }
            }

            var departments = query.ToPaginatedList(departmentParameters.PageSize, departmentParameters.PageNumber);
            var departmentDtos = _mapper.Map<PaginatedList<DepartmentDto>>(departments);
            
            return new PaginatedList<DepartmentDto>(departmentDtos, departments.TotalCount, departments.CurrentPage, departments.PageSize);
        }

        public DepartmentDto? GetDepartmentById(int id)
        {
            var department = _context.Departments.FirstOrDefault(d => d.Id == id);

            var departmentDto = _mapper.Map<DepartmentDto>(department);

            return departmentDto;
        }

        public DepartmentDto CreateDepartment(DepartmentForCreateDto departmentToCreate)
        {
            var department = _mapper.Map<Department>(departmentToCreate);

            _context.Departments.Add(department);
            _context.SaveChanges();

            var departmentDto = _mapper.Map<DepartmentDto>(department);

            return departmentDto;
        }

        public void UpdateDepartment(DepartmentForUpdateDto departmentToUpdate)
        {
            var department = _mapper.Map<Department>(departmentToUpdate);

            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public void DeleteDepartment(int id)
        {
            var department = _context.Departments.FirstOrDefault(d => d.Id == id);

            if(department is not null)
            {
            _context.Departments.Remove(department);
            }
            _context.SaveChanges();

        }
    }
}
