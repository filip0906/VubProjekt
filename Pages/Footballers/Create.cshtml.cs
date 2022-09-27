using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VubProjekt.Models;

namespace VubProjekt.Pages_Footballers
{
    public class CreateModel : PageModel
    {
        private readonly VubProjektDbContext _context;

        public CreateModel(VubProjektDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Footballer Footballer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Footballer == null || Footballer == null)
            {
                return Page();
            }

            _context.Footballer.Add(Footballer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
