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
    public class IndexModel : PageModel
    {
        private readonly VubProjektDbContext _context;

        public IndexModel(VubProjektDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string PositionSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Footballer> Footballer { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            // using System;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            PositionSort = sortOrder == "Position" ? "position_desc" : "Position";

            IQueryable<Footballer> footballersIQ = from s in _context.Footballer
                                            select s;
            
            if(!String.IsNullOrEmpty(searchString)){
                footballersIQ = footballersIQ.Where( s => s.Position.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    footballersIQ = footballersIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Position":
                    footballersIQ = footballersIQ.OrderBy(s => s.Position);
                    break;
                case "position_desc":
                    footballersIQ = footballersIQ.OrderByDescending(s => s.Position);
                    break;
                default:
                    footballersIQ = footballersIQ.OrderBy(s => s.LastName);
                    break;
            }

            Footballer = await footballersIQ.AsNoTracking().ToListAsync();
        }
    }
}
