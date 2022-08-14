using Common.Utils.Model;
using CRUD.Application.StudentService;
using CRUD.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    public class StudentController : BaseController
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<QueryResult<StudentDTO>> GetQueryListAsync(TableMetaData uTable)
            => await _studentService.GetQuerResult(uTable);
        [HttpPost]
        public async Task<StudentDTO> GetStudentByIdAsync(int Id)
            =>await _studentService.GetById(Id);
        [HttpPost]
        public async Task<Response> onCreateAsync(StudentDTO model)
            =>await _studentService.Create(model);
        [HttpPost]
        public async Task<Response> onUpdateAsync(StudentDTO model)
            =>await _studentService.Update(model);
        [HttpDelete]
        public async Task<bool> onDeleteByIdAsync(int Id)
            => await _studentService.onDelete(Id);
    }
}
