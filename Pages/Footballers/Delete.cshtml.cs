using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VubProjekt.Models;

namespace VubProjekt.Pages_Footballers
{
    public class DeleteModel : PageModel
    {
        private readonly VubProjektDbContext _context;

        public DeleteModel(VubProjektDbContext context)
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

            var footballer = await _context.Footballer.FirstOrDefaultAsync(m => m.ID == id);

            if (footballer == null)
            {
                return NotFound();
            }
            else 
            {
                Footballer = footballer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Footballer == null)
            {
                return NotFound();
            }
            var footballer = await _context.Footballer.FindAsync(id);

            if (footballer != null)
            {
                Footballer = footballer;
                _context.Footballer.Remove(Footballer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
