using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webUniversity.Models;

namespace webUniversity.Controllers
{
    public class OrdersController : Controller
    {
        private readonly UniversityContext _context;

        public OrdersController(UniversityContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var universityContext = _context.Orders.Include(o => o.OrderType).Include(o => o.Student);
            return View(await universityContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.OrderType)
                .Include(o => o.Student)
                .FirstOrDefaultAsync(m => m.ordersID == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["orderTypeID"] = new SelectList(_context.Set<OrderType>(), "orderTypeID", "orderTypeID");
            ViewData["studentID"] = new SelectList(_context.Students, "studentID", "studentID");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ordersID,code,isImplemented,number,title,data,dataStart,dataEnd,studentID,orderTypeID")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["orderTypeID"] = new SelectList(_context.Set<OrderType>(), "orderTypeID", "orderTypeID", orders.orderTypeID);
            ViewData["studentID"] = new SelectList(_context.Students, "studentID", "studentID", orders.studentID);
            return View(orders);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            ViewData["orderTypeID"] = new SelectList(_context.Set<OrderType>(), "orderTypeID", "orderTypeID", orders.orderTypeID);
            ViewData["studentID"] = new SelectList(_context.Students, "studentID", "studentID", orders.studentID);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("ordersID,code,isImplemented,number,title,data,dataStart,dataEnd,studentID,orderTypeID")] Orders orders)
        {
            if (id != orders.ordersID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.ordersID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["orderTypeID"] = new SelectList(_context.Set<OrderType>(), "orderTypeID", "orderTypeID", orders.orderTypeID);
            ViewData["studentID"] = new SelectList(_context.Students, "studentID", "studentID", orders.studentID);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.OrderType)
                .Include(o => o.Student)
                .FirstOrDefaultAsync(m => m.ordersID == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'UniversityContext.Orders'  is null.");
            }
            var orders = await _context.Orders.FindAsync(id);
            if (orders != null)
            {
                _context.Orders.Remove(orders);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int? id)
        {
          return (_context.Orders?.Any(e => e.ordersID == id)).GetValueOrDefault();
        }
    }
}
