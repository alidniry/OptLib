using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptLib.Data.InfrastructureLayer
{
    //BaseRepository
    public abstract class BaseRep<TEntity>
        where TEntity : class
    {
        //public abstract SectionAccess<eSPermission> Access { get; }
        protected abstract void ArgumentNotNull(TEntity value);

    }
}
