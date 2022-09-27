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
    public class DetailsModel : PageModel
    {
        private readonly VubProjektDbContext _context;

        public DetailsModel(VubProjektDbContext context)
        {
            _context = context;
        }

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
    }
}
