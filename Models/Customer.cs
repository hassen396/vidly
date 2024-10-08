using System.ComponentModel.DataAnnotations;

namespace vidly.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        //not required

        [Display(Name = "Date of Birth")]

        [Min18YearsIfAMember]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Name of a customer is required")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType? MembershipType { get; set; }


        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}