using Integral.CRM.Data.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using static CSD.Util.Async.TaskUtil;

namespace Integral.CRM.Data.Repository;

public class CustomerRepository : ICustomerRepository
{
    private readonly IntegralCrmdbContext m_context;

    #region callback methods
    private Customer saveAsyncCallback(Customer customer)
    {
        m_context.Database.ExecuteSqlRaw("exec sp_insert_customer {0}, {1}, {2}, {3}", 
            customer.CustomerName!, customer.CustomerAddress!, customer.RegistrationDate, customer.IsActive);
        
        return customer;
    }

    private IEnumerable<Customer> findByNameCallback(string name) => m_context.Customers.FromSqlRaw("exec sp_get_customer_by_name", name).ToList();  

    private IEnumerable<Customer> findByNameContainsCallback(string name)
    {
        var list = new List<Customer>();

        //...

        return list;
    }

    #endregion

    public CustomerRepository(IntegralCrmdbContext context)
    {
        m_context = context;
    }

    #region implemented methods
    public Task<Customer> SaveAsync(Customer customer) => CreateTaskAsync(() => saveAsyncCallback(customer));

    public Task<IEnumerable<Customer>> FindByNameAsync(string name) => CreateTaskAsync(() => findByNameCallback(name));

    public Task<IEnumerable<Customer>> FindByNameContainsAsync(string text) => CreateTaskAsync(() => findByNameContainsCallback(text));    

    #endregion

    public Task<long> CountAsync()
    {        
        throw new NotImplementedException();
    }

    public void DeleteAsync(Customer t)
    {
        throw new NotImplementedException();
    }

    public void DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Customer>> FindAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Customer>> FindByFilterAsync(Expression<Func<Customer, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<Customer> FindByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Customer>> FindByIdsAsync(IEnumerable<int> ids)
    {
        throw new NotImplementedException();
    }   

    

    public Task<IEnumerable<Customer>> SaveAsync(IEnumerable<Customer> entities)
    {
        throw new NotImplementedException();
    }
}
