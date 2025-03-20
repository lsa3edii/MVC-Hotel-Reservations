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
        public async Task<IActionResult> Search(string name, int pageNumber = 1)
        {
            int pageSize = 100;

            if (string.IsNullOrEmpty(name))
                return RedirectToAction("Index", new List<Reservation>());


            var query = _context.Reservations
                .AsNoTracking()
                .Where(r => EF.Functions.Like(r.FirstName + " " + r.LastName, $"%{name.Trim()}%"))
                .OrderBy(r => r.FirstName).ThenBy(r => r.LastName);


            int totalRecords = await query.CountAsync();
            int totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            var results = await query.Skip((pageNumber - 1) * pageSize)
                                     .Take(pageSize)
                                     .ToListAsync();


            ViewBag.CurrentPage = pageNumber;
            ViewBag.TotalPages = totalPages;
            ViewBag.RecordCounts = totalRecords;
            ViewBag.name = name;

            return View("Index", results);
        }



        [HttpPost]
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



        [HttpPost]
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



        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_context.Reservations.Find(id));
        }




        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Create(Reservation reservation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Reservations.Add(reservation);
                    _context.SaveChanges();
                    return RedirectToAction("index");
                }
                return View(reservation);
            }
            catch
            {
                return View(reservation);
            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_context.Reservations.FirstOrDefault(R => R.Id == id));
        }



        [HttpPost]
        public ActionResult Edit(Reservation reservation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Reservations.Update(reservation);
                    _context.SaveChanges();
                    return RedirectToAction("index", reservation);
                }
                return View(reservation);
            }
            catch
            {
                return View(reservation);
            }
        }



        [HttpPost]
        public ActionResult Delete(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
