namespace Integral.CRM.Data.Repository.Entity;

public partial class CustomerDetail
{
    public int CustomerId { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerAddress { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string? Email { get; set; }
    public string? PhoneNo { get; set; }
    public bool IsActive { get; set; }
}
