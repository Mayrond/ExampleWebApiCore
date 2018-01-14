using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;

namespace ExampleWebApiCore.Infrastructure
{
    public static class QueryableExtensions
    {
        public static List<TOut> QueryableForOData<TSource, TOut>(this IQueryable<TSource> s, ODataQueryOptions<TSource> options, IMapper mapper)
        {
            return options
                    .ApplyTo(s, new ODataQuerySettings())
                    .Cast<TSource>()
                    .Select(fbo => mapper.Map<TOut>(fbo))
                    .ToList();
        }
    }
}