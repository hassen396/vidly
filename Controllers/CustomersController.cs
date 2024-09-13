//entity framework
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using vidly.Data;
using vidly.Models;
using vidly.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppDbContext _context;
        // Constructor with dependency injection of AppDbContext
        public CustomersController(AppDbContext context)
        {
            _context = context;
        }
        //dispose
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: /Customers/Index
        public ViewResult Index()
        {
            //Fetch all customers from the database with MembershipType including
            //their associated membership type
            var customers = _context.Customers
               .Include(c => c.MembershipType).ToList();
            //Return the Index view with the list of customers
            return View(customers);
        }
        //GET: /Customers/Details
        public ActionResult Details(int id)
        {
            // Fetch the customer from the database by ID
            var customer = _context.Customers.
            Include(c => c.MembershipType).FirstOrDefault(c => c.Id == id);
            if (customer == null)
            {
                // If no customer is found, return NotFound
                return NotFound();
            }
            // Return the Details view and pass the customer to it
            return View(customer);
        }
        // GET: /Customers/Edit
        public ActionResult Edit(int id)
        {
            // Fetch the customer from the database by ID
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                // If no customer is found, return NotFound
                return NotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            // Return the Edit view and pass the customer to it

            return View("CustomerForm", viewModel);
        }
        //customers/New url
        [HttpGet]
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }


        // POST: /Customers/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                // If the customer ID is 0, it means a new customer is being created
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.DateOfBirth = customer.DateOfBirth;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges();
            // Redirect to the Index action
            return RedirectToAction("Index", "Customers");
        }
    }
}