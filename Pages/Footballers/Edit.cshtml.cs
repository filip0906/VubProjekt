using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VubProjekt.Models;

namespace VubProjekt.Pages_Footballers
{
    public class EditModel : PageModel
    {
        private readonly VubProjektDbContext _context;

        public EditModel(VubProjektDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Footballer Footballer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Footballer == null)
            {
                return NotFound();
            }

            var footballer =  await _context.Footballer.FirstOrDefaultAsync(m => m.ID == id);
            if (footballer == null)
            {
                return NotFound();
            }
            Footballer = footballer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Footballer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FootballerExists(Footballer.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FootballerExists(int id)
        {
          return (_context.Footballer?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
