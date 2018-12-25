using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Domain;

namespace WebApp.Controllers
{
    public class MarkdownPostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarkdownPostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MarkdownPosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.MarkdownPosts.ToListAsync());
        }

        // GET: MarkdownPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markdownPost = await _context.MarkdownPosts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (markdownPost == null)
            {
                return NotFound();
            }

            return View(markdownPost);
        }

        // GET: MarkdownPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MarkdownPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Markdown,CreatedDate")] MarkdownPost markdownPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(markdownPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(markdownPost);
        }

        // GET: MarkdownPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markdownPost = await _context.MarkdownPosts.FindAsync(id);
            if (markdownPost == null)
            {
                return NotFound();
            }
            return View(markdownPost);
        }

        // POST: MarkdownPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Markdown,CreatedDate")] MarkdownPost markdownPost)
        {
            if (id != markdownPost.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(markdownPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkdownPostExists(markdownPost.ID))
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
            return View(markdownPost);
        }

        // GET: MarkdownPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var markdownPost = await _context.MarkdownPosts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (markdownPost == null)
            {
                return NotFound();
            }

            return View(markdownPost);
        }

        // POST: MarkdownPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var markdownPost = await _context.MarkdownPosts.FindAsync(id);
            _context.MarkdownPosts.Remove(markdownPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkdownPostExists(int id)
        {
            return _context.MarkdownPosts.Any(e => e.ID == id);
        }
    }
}
