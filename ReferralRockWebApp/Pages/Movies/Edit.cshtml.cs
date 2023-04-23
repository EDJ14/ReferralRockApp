using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReferralRockWebApp.Data;
using ReferralRockWebApp.Models;

namespace ReferralRockWebApp.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly ReferralRockWebApp.Data.ReferralRockWebAppContext _context;

        public EditModel(ReferralRockWebApp.Data.ReferralRockWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Member Member { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member =  await _context.Member.FirstOrDefaultAsync(m => m.id == id);
            if (member == null)
            {
                return NotFound();
            }
            Member = member;
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

            _context.Attach(Member).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(Member.id))
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

        private bool MemberExists(Guid id)
        {
          return (_context.Member?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
