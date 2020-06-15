using System;
using System.Collections.Generic;

namespace Mews.Fiscalization.Hungary.Models
{
    public class InvoiceData
    {
        public InvoiceData(string number, DateTime issueDate, IEnumerable<Invoice> invoices)
        {
            Number = number;
            IssueDate = issueDate;
            Invoices = invoices;
        }

        public string Number { get; }

        public DateTime IssueDate { get; }

        public IEnumerable<Invoice> Invoices { get; }
    }
}
