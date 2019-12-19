using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChartJSAsync.Data;
using ChartJSAsync.Models;

namespace ChartJSAsync
{
    public class EditModel : PageModel
    {
        private readonly ChartJSAsync.Data.ChartJSAsyncContext _context;

        public EditModel(ChartJSAsync.Data.ChartJSAsyncContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InvoiceModel InvoiceModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InvoiceModel = await _context.InvoiceModel.FirstOrDefaultAsync(m => m.ID == id);

            if (InvoiceModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(InvoiceModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceModelExists(InvoiceModel.ID))
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

        private bool InvoiceModelExists(int id)
        {
            return _context.InvoiceModel.Any(e => e.ID == id);
        }
    }
}
