using Integral.CRM.Data.DAL;
using Integral.CRM.Data.Repository;
using Integral.CRM.Data.Repository.Entity;

namespace RepositoryTest;


[TestFixture]
public class TestSaveFind
{
    private IntegralCRMAppHelper m_helper;   

    private static Customer createCustomer(string[] dataInfoStr)
    {
        var name = dataInfoStr[0];
        var email = dataInfoStr[1];
        var date = DateTime.Parse(dataInfoStr[2]);
        var active = bool.Parse(dataInfoStr[3]);

        return new(){ CustomerName = name, IsActive = active, RegistrationDate = date, CustomerAddress = email };
    }    
    
    public static IEnumerable<Customer> Source
    {
        get
        {
            var streamReader = new StreamReader("customers.csv");

            string line;

            while ((line = streamReader.ReadLine()) != null)
                yield return createCustomer(line.Split(","));                        
        }
    }

    [SetUp]
    public void SetUp()
    {
        var context = new IntegralCrmdbContext();

        m_helper = new(new CustomerRepository(context), new CustomerInfoRepository(context));        
    }

    [Ignore("Tested")]
    [Test, TestCaseSource(nameof(Source))]
    public async Task SaveFindTest(Customer customer)
    {
        var expectedName = customer.CustomerName;

        await m_helper.SaveCustomerAsync(customer);
        var actualCustomers = await m_helper.FindCustomerByNameAsync(expectedName!);

        Assert.IsNotNull(actualCustomers);
        var c = actualCustomers.First();

        Assert.AreEqual(expectedName, c.CustomerName);

        await m_helper.DeleteCustomerByKeyAsync(c.CustomerId);
    }

    [Test, TestCaseSource(nameof(Source))]
    public async Task FindCustomerInfoTest(Customer customer)
    {
        var expectedName = customer.CustomerName;

        await m_helper.SaveCustomerAsync(customer);
        var actualCustomers = await m_helper.FindCustomerInfoByNameAsync(customer.CustomerName!);

        Assert.IsNotNull(actualCustomers);
        var c = actualCustomers.First();
        Assert.AreEqual(expectedName, c.CustomerName);

        await m_helper.DeleteAllCustomer();
    }


    [TearDown]
    public void TearDown()
    {
        //Test finished
    }
}