using AutoMapper;
using KnowledgeZone.Domain.DTOs.Qualification;
using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;
using KnowledgeZone.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Service
{
    public class QualificationService : IQualificationService
    {
        private readonly IMapper _mapper;
        private readonly KnowledgeZoneDbContext _context;
        
        public QualificationService(IMapper mapper, KnowledgeZoneDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public PaginatedList<QualificationDto> GetQualification(QualificationResourceParamentrs qualificationParameters)
        {
            var query = _context.Qualifications.AsQueryable();

            if (!string.IsNullOrEmpty(qualificationParameters.SearchString))
            {
                query = query.Where(q => q.Name.Contains(qualificationParameters.SearchString));
            }

            if(qualificationParameters.OrderBy is not null)
            {
                switch (qualificationParameters.OrderBy)
                {
                    case "name":
                        query = query.OrderBy(q => q.Name);
                        break;
                    case "name_desc":
                        query = query.OrderByDescending(q => q.Name);
                        break;
                }
            }

            var qualifications = query.ToPaginatedList(qualificationParameters.PageSize, qualificationParameters.PageNumber);
            var qualificationDtos = _mapper.Map<PaginatedList<QualificationDto>>(qualifications);

            return new PaginatedList<QualificationDto>(qualificationDtos, qualifications.TotalCount, qualifications.CurrentPage, qualifications.PageSize);  
        }

        public QualificationDto? GetQualificationById(int id)
        {
            var qualification = _context.Qualifications.FirstOrDefault(q => q.Id == id);
            var qualificationDto = _mapper.Map<QualificationDto>(qualification);

            return qualificationDto;
        }

        public QualificationDto CreateQualification(QualificationForCreateDto qualificationToCreate)
        {
            var qualification = _mapper.Map<Qualification>(qualificationToCreate);
            
            _context.Qualifications.Add(qualification);
            _context.SaveChanges();

            var qualificationDto = _mapper.Map<QualificationDto>(qualification);
            return qualificationDto;
        }

        public void UpdateQualification(QualificationForUpdateDto qualificationToUpdate)
        {
            var qualification = _mapper.Map<Qualification>(qualificationToUpdate);

            _context.Qualifications.Update(qualification);
            _context.SaveChanges();
        }

        public void DeleteQualification(int id)
        {
            var qualification = _context.Qualifications.FirstOrDefault(q => q.Id == id);

            if(qualification is not null)
            {
                _context.Qualifications.Remove(qualification);
            }
            _context.SaveChanges();
        }
    }
}
