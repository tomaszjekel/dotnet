using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using to.mo.Data;
using to.mo.Models.ProductViewModels;

namespace to.mo.Controllers
{
    public class ProductAddController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductAddController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductAdd
        public async Task<IActionResult> Index()
        {
            return View(await _context.Add.ToListAsync());
        }

        // GET: ProductAdd/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAdd = await _context.Add
                .SingleOrDefaultAsync(m => m.ID == id);
            if (productAdd == null)
            {
                return NotFound();
            }

            return View(productAdd);
        }

        // GET: ProductAdd/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductAdd/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Price,Description,City,Cauntry,PhoneNumber")] ProductAdd productAdd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productAdd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productAdd);
        }

        // GET: ProductAdd/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAdd = await _context.Add.SingleOrDefaultAsync(m => m.ID == id);
            if (productAdd == null)
            {
                return NotFound();
            }
            return View(productAdd);
        }

        // POST: ProductAdd/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Price,Description,City,Cauntry,PhoneNumber")] ProductAdd productAdd)
        {
            if (id != productAdd.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productAdd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductAddExists(productAdd.ID))
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
            return View(productAdd);
        }

        // GET: ProductAdd/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAdd = await _context.Add
                .SingleOrDefaultAsync(m => m.ID == id);
            if (productAdd == null)
            {
                return NotFound();
            }

            return View(productAdd);
        }

        // POST: ProductAdd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productAdd = await _context.Add.SingleOrDefaultAsync(m => m.ID == id);
            _context.Add.Remove(productAdd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductAddExists(int id)
        {
            return _context.Add.Any(e => e.ID == id);
        }
    }
}
