using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Photocopier.Data
{
    interface IProducts<TEntity>
    {
        IEnumerable<TEntity> All();

        bool Any(Expression<Func<TEntity, bool>> predicate);

        TEntity Find(Expression<Func<TEntity, bool>> predicate);
    }
}
