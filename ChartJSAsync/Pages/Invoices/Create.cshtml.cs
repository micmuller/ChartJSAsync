using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChartJSAsync.Data;
using ChartJSAsync.Models;

namespace ChartJSAsync
{
    public class CreateModel : PageModel
    {
        private readonly ChartJSAsync.Data.ChartJSAsyncContext _context;

        public CreateModel(ChartJSAsync.Data.ChartJSAsyncContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public InvoiceModel InvoiceModel { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.InvoiceModel.Add(InvoiceModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
