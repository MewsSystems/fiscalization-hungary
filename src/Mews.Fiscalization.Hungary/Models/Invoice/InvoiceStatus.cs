using System.Collections.Generic;
using System.Linq;

namespace Mews.Fiscalization.Hungary.Models
{
    public sealed class InvoiceStatus
    {
        public InvoiceStatus(InvoiceState status, IEnumerable<InvoiceValidationResult> validationResults)
        {
            Status = status;
            ValidationResults = validationResults;
        }

        public InvoiceState Status { get; }

        public IEnumerable<InvoiceValidationResult> ValidationResults { get; }

        internal static InvoiceStatus Map(Dto.QueryTransactionStatusResponse response)
        {
            var result = response.processingResults.processingResult.First();
            return new InvoiceStatus(
                status: (InvoiceState)result.invoiceStatus,
                validationResults: InvoiceValidationResult.Map(result.businessValidationMessages, result.technicalValidationMessages).ToArray()
            );
        }
    }
}
