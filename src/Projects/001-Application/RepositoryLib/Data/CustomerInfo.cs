namespace Integral.CRM.Data.Repository.Entity;

public partial class CustomerInfo
{    
    public string? CustomerName { get; set; }
    public string? CustomerAddress { get; set; } = null!;
    public DateTime? RegistrationDate { get; set; }
}
