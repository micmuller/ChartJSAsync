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
    public class DetailsModel : PageModel
    {
        private readonly ChartJSAsync.Data.ChartJSAsyncContext _context;

        public DetailsModel(ChartJSAsync.Data.ChartJSAsyncContext context)
        {
            _context = context;
        }

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
    }
}
