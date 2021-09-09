using System.Collections.Generic;

namespace MessageGenerator.Database.DataAccess
{
    public class ApplicationDbContext<TEntity>
    {
        public static readonly List<TEntity> Data = new();
    }
}
