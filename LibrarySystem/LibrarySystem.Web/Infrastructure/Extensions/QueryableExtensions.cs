using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using AutoMapper.QueryableExtensions;

namespace LibrarySystem.Web.Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TDestination> QueryTo<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(AutoMapperConfig.Configuration, membersToExpand);
        }
    }
}