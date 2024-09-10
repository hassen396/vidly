using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vidly.Data;
using vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext _context;

        // Constructor with dependency injection of AppDbContext
        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: /Movies/Home
        // This method retrieves all movies from the database
        public async Task<IActionResult> Home()
        {
            // Fetch movies from the database asynchronously 
            var movies = await _context.Movies.
            Include(m => m.Genre).ToListAsync();

            // Return the view and pass the list of movies to it
            return View(movies);
        }

        // GET: /Movies/Details/5
        // This method retrieves the details of a movie, including customers who rated it
        public async Task<IActionResult> Details(int id)
        {
            // Fetch the movie and its customers' ratings from the database asynchronously
            var movie = await _context.Movies
               .Include(m => m.Genre)
               .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                // If no movie is found, return NotFound
                return NotFound();
            }

            // Return the view and pass the movie details to it
            return View(movie);
        }

        // GET: /Movies/New
        // This method displays a form to create a new movie
        public IActionResult New()
        {
            // Simply return a view to create a new movie
            return View();
        }

        // POST: /Movies/Create
        // This method creates a new movie and saves it to the database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                // If the input model is invalid, return the same view with validation errors
                return View(movie);
            }

            // Add the new movie to the database and save changes asynchronously
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            // After saving, redirect to the Home action
            return RedirectToAction(nameof(Home));
        }

        // GET: /Movies/Edit/5
        // This method displays a form to edit an existing movie
        // public async Task<IActionResult> Edit(int id)
        // {
        //     // Fetch the movie from the database by ID
        //     var movie = await _context.Movies.FindAsync(id);
        //     if (movie == null)
        //     {
        //         // If no movie is found, return NotFound
        //         return NotFound();
        //     }

        //     // Return the edit view, passing the movie to it
        //     return View(movie);
        // }

        // POST: /Movies/Edit/5
        // This method handles the form submission to update an existing movie
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(int id, Movie movie)
        // {
        //     if (id != movie.Id)
        //     {
        //         // If the movie ID does not match, return NotFound
        //         return NotFound();
        //     }

        //     if (!ModelState.IsValid)
        //     {
        //         // If the input model is invalid, return the view with validation errors
        //         return View(movie);
        //     }

        //     // Update the movie in the database and save changes
        //     _context.Update(movie);
        //     await _context.SaveChangesAsync();

        //     // After saving, redirect to the Home action
        //     return RedirectToAction(nameof(Home));
        // }

        // GET: /Movies/Delete/5
        // This method displays a confirmation view for deleting a movie
        // public async Task<IActionResult> Delete(int id)
        // {
        //     // Fetch the movie by ID
        //     var movie = await _context.Movies.FindAsync(id);
        //     if (movie == null)
        //     {
        //         // If no movie is found, return NotFound
        //         return NotFound();
        //     }

        //     // Return the delete confirmation view
        //     return View(movie);
        // }

        // POST: /Movies/Delete/5
        // This method deletes the movie from the database after confirmation
        // [HttpPost, ActionName("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed(int id)
        // {
        //     // Fetch the movie from the database
        //     var movie = await _context.Movies.FindAsync(id);
        //     if (movie == null)
        //     {
        //         return NotFound();
        //     }

        // Remove the movie and save changes
        // _context.Movies.Remove(movie);
        // await _context.SaveChangesAsync();

        // // Redirect to the Home action after deletion
        // return RedirectToAction(nameof(Home));
    }
}

