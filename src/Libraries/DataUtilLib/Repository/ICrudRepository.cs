using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CSD.Util.Data.Repository;

public interface ICrudRepository<T, ID>
{
    #region CRUD Operations
    IEnumerable<T> All { get; }

    long Count();

    void Delete(T t);

    void DeleteById(ID id);

    bool ExistsById(ID id);

    IEnumerable<T> FindByFilter(Expression<Func<T, bool>> predicate);

    T FindById(ID id);

    IEnumerable<T> FindByIds(IEnumerable<ID> ids);

    T Save(T t);

    IEnumerable<T> Save(IEnumerable<T> entities);
    #endregion    
}
