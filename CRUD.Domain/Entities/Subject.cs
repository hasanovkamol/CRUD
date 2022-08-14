using Common.Utils.Model;
using System.Collections.Generic;

namespace CRUD.Domain.Entities
{
    public class Subject: EntityBase
    {
        /// <summary>
        /// Fanning malakaviy kodi
        /// </summary>
        public string SubjectCode { get; set; }

        /// <summary>
        /// Fan nomi
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ma'ruza (soat)
        /// </summary>
        public int Lecture { get; set; }
        /// <summary>
        /// Amaliy (soat)
        /// </summary>
        public int Practical { get; set; }
        /// <summary>
        /// Labaratorya (soat)
        /// </summary>
        public int Laboratory { get; set; }
        /// <summary>
        /// Seminar (soat)
        /// </summary>
        public int Seminar { get; set; }
        /// <summary>
        /// Kurs ishi (soat)
        /// </summary>
        public int CourseWork { get; set; }
        /// <summary>
        /// Mustaqil ta'lim (soat)
        /// </summary>
        public int IndependentEducation { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
