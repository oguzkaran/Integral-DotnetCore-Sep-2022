using Microsoft.AspNetCore.Identity;

namespace IntegralWebServiceApplication.Identity
{
    public class UserInfo : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
