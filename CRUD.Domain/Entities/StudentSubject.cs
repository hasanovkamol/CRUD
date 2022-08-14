using Common.Utils.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Domain.Entities
{
    public class StudentSubject: EntityBase
    {
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
    }
}
