using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using vidly.Data;
using vidly.Models;
using vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        //private field for db
        private readonly AppDbContext _context;
        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: /Customer/Index
        public IActionResult Index()
        {
            var customers = _context.Customers.
            Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        // GET: /Customer/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _context.Customers
               .Include(c => c.MembershipType)
               .FirstOrDefault(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
        // GET: /Customers/New
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new ViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }
        // POST: /Customers/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: /Customers/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _context.Customers
               .Include(c => c.MembershipType)
               .FirstOrDefault(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new ViewModel
            {
                Customer = customer,
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }
        // POST: /Customers/Edit/5
        [HttpPost]
        public ActionResult Update(int id, ViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // Repopulate the MembershipTypes because they are not persisted across postbacks
                viewModel.MembershipTypes = _context.MembershipTypes.ToList();

                // Redisplay the form with the current data
                return RedirectToAction("Edit",viewModel);
            }

            _context.Update(viewModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}