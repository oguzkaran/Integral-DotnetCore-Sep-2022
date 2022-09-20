using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CSD.Data.Repository;

public interface ICrudRepositoryAsync<T, Id>
{
    Task<long> CountAsync();

    Task<IEnumerable<T>> FindAllAsync();

    void DeleteAsync(T t);

    void DeleteByIdAsync(Id id);

    Task<bool> ExistsByIdAsync(Id id);

    Task<IEnumerable<T>> FindByFilterAsync(Expression<Func<T, bool>> predicate);

    Task<T> FindByIdAsync(Id id);

    Task<IEnumerable<T>> FindByIdsAsync(IEnumerable<Id> ids);

    Task<T> SaveAsync(T t);

    Task<IEnumerable<T>> SaveAsync(IEnumerable<T> entities);
}
