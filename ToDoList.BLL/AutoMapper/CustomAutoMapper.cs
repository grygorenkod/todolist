using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.BLL.AutoMapper
{
    public static class CustomAutoMapper<TSource, TDestination>
    {
        private static Mapper _mapper = new Mapper(new MapperConfiguration(
            config => config.CreateMap<TSource, TDestination>().ReverseMap()));

        public static TDestination Map(TSource source)
        {
            return _mapper.Map<TDestination>(source);
        }
        public static List<TDestination> MapList(List<TSource> source)
        {
            var list = new List<TDestination>();
            source.ForEach(e => list.Add(Map(e)));
            return list;
        }
    }
}
