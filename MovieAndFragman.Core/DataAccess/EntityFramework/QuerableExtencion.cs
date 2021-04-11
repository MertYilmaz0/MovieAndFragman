using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MovieAndFragman.Core.DataAccess.EntityFramework
{
    public static class QuerableExtencion
    {
        public static IQueryable<T> MyInclude<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
         where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (a, b) => a.Include(b));
            }
            return query;

        }
    }
}
