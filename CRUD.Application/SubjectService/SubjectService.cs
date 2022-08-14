using AutoMapper;
using Common.Utils.Constant;
using Common.Utils.Model;
using CRUD.Application.Presistencs;
using CRUD.Domain.Entities;
using CRUD.Domain.Model;
using System;
using System.Threading.Tasks;

namespace CRUD.Application.SubjectService
{
    public class SubjectService : ISubjectService
    {
        private readonly IRepository<Subject> _subjectRepository;
        private readonly IMapper _mapper;
        public SubjectService(IRepository<Subject> subjectRepository, IMapper mapper)
        {
            _mapper = mapper;
            _subjectRepository= subjectRepository;
        }
        public async Task<Response> Create(SubjectDTO model)
        {
            var entity = _mapper.Map<Subject>(model);
            await _subjectRepository.AddAsync(entity);
            return new Response() { Status = Statuses.Success, Message = "Success" };
        }

        public Task<SubjectDTO> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<QueryResult<SubjectDTO>> GetQuerResult(TableMetaData uTabl)
        {
            throw new NotImplementedException();
        }

        public Task<bool> onDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(SubjectDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
