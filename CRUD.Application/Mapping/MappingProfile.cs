using AutoMapper;
using CRUD.Domain.Entities;
using CRUD.Domain.Model;
using System;

namespace CRUD.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<string, int>().ConvertUsing<IntTypeConverter>();
            CreateMap<string, int?>().ConvertUsing<NullIntTypeConverter>();
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Subject, Subject>().ReverseMap();
        }
       
        #region AutoMapTypeConverters
        // Automap type converter definitions for 
        // int, int?, decimal, decimal?, bool, bool?, Int64, Int64?, DateTime
        // Automapper string to int?
        private class NullIntTypeConverter : ITypeConverter<string, int?>
        {
            public int? Convert(string source, int? destination, ResolutionContext context)
            {
                if (source == null)
                    return null;
                else
                {
                    int result;
                    return Int32.TryParse(source, out result) ? result : null;
                }
            }
        }
        // Automapper string to int
        private class IntTypeConverter : ITypeConverter<string, int>
        {
            public int Convert(string source, int destination, ResolutionContext context)
            {
                if (string.IsNullOrEmpty(source))
                    return 0;
                else
                    return Int32.Parse(source);
            }
        }
        #endregion
    }
}