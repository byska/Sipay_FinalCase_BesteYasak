using Sipay_FinalCase.Core.Entities.BaseEntities;

namespace Sipay_FinalCase.Entities.DbSets
{
    public class User:BaseUser
    {
        public User()
        {
            MessageAdminToUsers = new HashSet<MessageAdminToUser>();
            MessageUserToAdmins = new HashSet<MessageUserToAdmin>();
        }

        public string Tc { get; set; }
        public string Phone { get; set; }
        public string? LicensePlate { get; set; }
        public Apartment Apartment { get; set; }
        public int ApartmentId { get; set; }
        public ICollection<MessageAdminToUser> MessageAdminToUsers { get; set; }
        public ICollection<MessageUserToAdmin> MessageUserToAdmins { get; set; }
    }
}
