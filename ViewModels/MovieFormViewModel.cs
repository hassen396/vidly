using vidly.Models;

namespace vidly.ViewModels 
{
    
    public class MovieFormViewModel
    {
    public IEnumerable<Genre> Genres { get; set; }

    public Movie Movie { get; set; }
    }

}