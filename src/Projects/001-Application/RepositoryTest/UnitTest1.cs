using Integral.CRM.Data.DAL;
using Integral.CRM.Data.Repository;

namespace RepositoryTest;

public class Tests
{
    private IntegralCRMAppHelper m_helper;

    [SetUp]
    public void Setup()
    {
        var context = new IntegralCrmdbContext();

        m_helper = new(new CustomerRepository(context), new CustomerInfoRepository(context));
    }

    [Test]
    public async Task TestNull()
    {
        var customers = await m_helper.FindCustomerByNameContainsAsync("ali");
        //...        
    }

    [TearDown]
    public void TearDown()
    {
        //Test finished
    }
}