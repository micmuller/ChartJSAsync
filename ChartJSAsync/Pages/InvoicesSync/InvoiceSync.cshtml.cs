using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChartJSAsync.Data;
using ChartJSAsync.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ChartJSAsync
{
    public class InvoiceSyncModel : PageModel
    {
        private readonly InvoiceService _invoiceService;

        public List<InvoiceModelSync> InvoiceList;
        public InvoiceSyncModel(InvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        public void OnGet()
        {
            InvoiceList = _invoiceService.GetInvoices();
        }

        public JsonResult OnGetInvoiceChartDataSync()
        {
            InvoiceList = _invoiceService.GetInvoices();
            var invoiceChart = new CategoryChartModel();
            invoiceChart.AmountList = new List<double>();
            invoiceChart.CategoryList = new List<string>();

            foreach (var inv in InvoiceList)
            {
                invoiceChart.AmountList.Add(inv.Amount);
                invoiceChart.CategoryList.Add(inv.CostCategory);
            }

            return new JsonResult(invoiceChart);
        }

    }
}