using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ReferralRockWebApp.Data;
using ReferralRockWebApp.Models;

namespace ReferralRockWebApp.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly ReferralRockWebApp.Data.ReferralRockWebAppContext _context;

        public DetailsModel(ReferralRockWebApp.Data.ReferralRockWebAppContext context)
        {
            _context = context;
        }

      public Member Member { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FirstOrDefaultAsync(m => m.id == id);
            if (member == null)
            {
                return NotFound();
            }
            else 
            {
                Member = member;
            }
            return Page();
        }
    }
}
