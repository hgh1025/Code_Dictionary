using AutoMapper;
using System;
using System.Collections.Generic;

namespace Code_Dictionary.Model.Utils
{
    public static class AutoMapperUtil<TSource, TDestination>
    {
        /// <summary>
        /// Object Copy
        /// EX : var mapper = AutoMapperUtil<SourceClass, TargetClass>.ToConvert(sourceObject);
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TDestination ToConvert(TSource source)
        {
            if (source == null) throw new ArgumentNullException("source");

            IMapper imapper = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>()).CreateMapper();
            var mappers = imapper.Map<TSource, TDestination>(source);

            return mappers;
        }

        /// <summary>
        /// Enumerable Object Copy
        /// EX : var list = AutoMapperUtil<SourceClass, TargetClass>.ToConvertEnumerable(sourceObject);
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable<TDestination> ToConvertEnumerable(IEnumerable<TSource> source)
        {
            if (source == null) return default(IEnumerable<TDestination>);

            List<TDestination> targets = new List<TDestination>();
            foreach (var item in source)
            {
                targets.Add(ToConvert(item));
            }
            return targets;
        }
    }
}