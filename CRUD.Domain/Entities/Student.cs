using Common.Utils.Model;
using System;
using System.Collections.Generic;

namespace CRUD.Domain.Entities
{
    /// <summary>
    /// Talaba jadvali
    /// </summary>
    public class Student: EntityBase
    {
        /// <summary>
        /// Ismi
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Familyasi
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Otasini ismi
        /// </summary>
        public string FatherName { get; set; }
        /// <summary>
        /// Pasport seria
        /// </summary>
        public string PassportSeria { get; set; }
        /// <summary>
        /// Passport nomeri
        /// </summary>
        public string PassportNumber { get; set; }
        /// <summary>
        /// O'quv moassassasi (SP bo'lish kerak edi)
        /// </summary>
        public string SpInstitutionName { get; set; }
        /// <summary>
        /// Fakultet (SP bo'lish kerak edi)
        /// </summary>
        public string SpFacultetName { get; set; }
        /// <summary>
        /// Yo'nalish (SP bo'lish kerak edi)
        /// </summary>
        public string SpDirectionName { get; set; }
        /// <summary>
        /// Gruh nomi
        /// </summary>
        public string GrupName { get; set; }
        /// <summary>
        /// Manzili
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// O'qishga kirgan vaqti
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// Talabaga bog'langan fanlar ro'yhati
        /// </summary>

        public ICollection<Subject> Subjects { get; set; }
    }
}
