using Common.Utils.Model;
using CRUD.Domain.Model;
using System.Threading.Tasks;

namespace CRUD.Application.StudentService
{
    public class StudentService : IStudentService
    {
        public Task<Response> Create(StudentDTO entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<StudentDTO> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<QueryResult<StudentDTO>> GetQuerResult(TableMetaData uTabl)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> onDelete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response> Update(StudentDTO entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
