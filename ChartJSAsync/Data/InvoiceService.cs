using ChartJSAsync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ChartJSAsync.Data
{
    public class InvoiceService
    {
        
        public List<InvoiceModelSync> GetInvoices()
        {
            return new List<InvoiceModelSync>()
            {
                new InvoiceModelSync() {InvoiceNumber = 1, Amount = 10, CostCategory = "Utilities sync"},
                new InvoiceModelSync() {InvoiceNumber = 2, Amount = 50, CostCategory = "Telephone sync"},
                new InvoiceModelSync() {InvoiceNumber = 3, Amount = 30, CostCategory = "Services sync"},
                new InvoiceModelSync() {InvoiceNumber = 4, Amount = 40, CostCategory = "Consultancy sync"},
                new InvoiceModelSync() {InvoiceNumber = 5, Amount = 60, CostCategory = "Raw materials sync"}
            };
        }
    }
}

