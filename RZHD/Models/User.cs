using Microsoft.AspNetCore.Identity;

namespace RZHD.Models
{
    public class User : IdentityUser<int>
    {
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Middlename { get; set; }
        public int Age { get; set; }
        public int BonusQuantity { get; set; }
    }
}
