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
    public class IndexModel : PageModel
    {
        private readonly ChartJSAsync.Data.ChartJSAsyncContext _context;

        public IndexModel(ChartJSAsync.Data.ChartJSAsyncContext context)
        {
            _context = context;
        }

        public IList<InvoiceModel> InvoiceModel { get;set; }

        public async Task OnGetAsync()
        {
            InvoiceModel = await _context.InvoiceModel.ToListAsync();
        }

        public async Task<JsonResult> OnGetInvoiceAsyncChartData()
        {
            InvoiceModel = await _context.InvoiceModel.ToListAsync();
             var invoiceChart = new CategoryChartModel();
            invoiceChart.AmountList = new List<double>();
            invoiceChart.CategoryList = new List<string>();

            foreach (var inv in InvoiceModel)
            {
                invoiceChart.AmountList.Add(inv.Amount);
                invoiceChart.CategoryList.Add(inv.CostCategory);
            }

            return new JsonResult(invoiceChart);
        }
    }
}
