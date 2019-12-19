using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChartJSAsync.Data;
using ChartJSAsync.Models;

namespace ChartJSAsync
{
    public class DeleteModel : PageModel
    {
        private readonly ChartJSAsync.Data.ChartJSAsyncContext _context;

        public DeleteModel(ChartJSAsync.Data.ChartJSAsyncContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InvoiceModel = await _context.InvoiceModel.FindAsync(id);

            if (InvoiceModel != null)
            {
                _context.InvoiceModel.Remove(InvoiceModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
