using HotelManagement.Bogus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCHotel.Context;
using MVCHotel.Models;

namespace MVCHotel.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationContext _context;

        public ReservationController(ReservationContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index(int pageNumber = 1)
        {
            int pageSize = 100; // Number of records per page
            int totalRecords = _context.Reservations.Count();
            int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);


            // Ensure pageNumber is within range
            if (pageNumber < 1)
                pageNumber = 1;

            else if (totalPages > 0 && pageNumber > totalPages)
                pageNumber = totalPages;


            // Ensure skip amount is not negative
            int skipAmount = (pageNumber - 1) * pageSize;
            if (skipAmount < 0)
                skipAmount = 0;


            var reservations = _context.Reservations
                                       // Sorts data consistently to avoid page jumps
                                       .OrderBy(r => r.Id) // Ensure consistent ordering
                                       .Skip(skipAmount)
                                       .Take(pageSize)
                                       .ToList();

            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;
            ViewBag.RecordCounts = _context.Reservations.Count();

            return View(reservations);
        }

        

        // GET: ReservationController
        //public IActionResult Index()
        //{
        //    return View(_context.Reservations.Take(100).ToList());
        //    //return View(_context.Reservations.Take(100).ToList()); 
        //    //return View(_context.Reservations.ToList()); // Wrong Way
        //}



        [HttpGet]
        public IActionResult CreateBogusData()
        {
            var fakeData = ReservationFaker.GenerateData(10000);

            try
            {
                _context.Reservations.AddRange(fakeData);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }



        [HttpGet]
        public IActionResult DeleteAll()
        {
            try
            {
                //_context.Reservations.RemoveRange(_context.Reservations.ToList()); // Wrong Way
                _context.Database.ExecuteSqlRaw($"DELETE FROM Reservation");
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
