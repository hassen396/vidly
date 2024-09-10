using vidly.Models;

namespace vidly.ViewModels
{
    public class ViewModel
    {

        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

    }
}