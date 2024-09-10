namespace vidly.Models
{
    public partial class Customer
    {
public class Rating
{
    public int Id { get; set; }               // Unique identifier for the rating
    public int Score { get; set; }            // The actual rating score (e.g., 1-5 stars)
    public int MovieId { get; set; }          // Foreign key to the associated movie
    public Movie Movie { get; set; }          // Navigation property to the related movie
    public int CustomerId { get; set; }       // Foreign key to the associated customer
    public Customer Customer { get; set; }    // Navigation property to the related customer
}

    }
}