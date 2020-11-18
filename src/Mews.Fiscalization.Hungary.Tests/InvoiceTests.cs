using Mews.Fiscalization.Core.Model;
using Mews.Fiscalization.Hungary.Models;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mews.Fiscalization.Hungary.Tests
{
    [TestFixture]
    public class InvoiceTests
    {
        [Test]
        public async Task SendInvoiceSucceeds()
        {
            var navClient = TestFixture.GetNavClient();
            var exchangeToken = await navClient.GetExchangeTokenAsync();
            var invoiceTransactionId = await navClient.SendInvoicesAsync(exchangeToken.SuccessResult, SequentialEnumerable.FromPreordered(new[] { GetInvoice() }, startIndex: 1));

            Thread.Sleep(3000);

            var transactionStatus = await navClient.GetTransactionStatusAsync(invoiceTransactionId.SuccessResult);
            Assert.IsNotNull(transactionStatus.SuccessResult);
            Assert.IsNotNull(exchangeToken.SuccessResult);
            Assert.IsNotNull(invoiceTransactionId.SuccessResult);
            AssertError(transactionStatus);
            AssertError(exchangeToken);
            AssertError(invoiceTransactionId);
        }

        [Test]
        public async Task SendCorrectionInvoiceSucceeds()
        {
            var navClient = TestFixture.GetNavClient();
            var exchangeToken = await navClient.GetExchangeTokenAsync();
            var response = await navClient.SendModificationDocumentsAsync(
                token: exchangeToken.SuccessResult,
                invoices: SequentialEnumerable.FromPreordered(new[] { GetModificationInvoice() }, startIndex: 1)
            );

            Thread.Sleep(3000);

            var transactionStatus = await navClient.GetTransactionStatusAsync(response.SuccessResult);
            Assert.IsNotNull(transactionStatus.SuccessResult);
            AssertError(transactionStatus);
        }

        private Invoice GetInvoice()
        {
            var item1Amount = new Amount(new AmountValue(1), new AmountValue(1), new AmountValue(0));
            var item2Amount = new Amount(new AmountValue(20m), new AmountValue(16.81m), new AmountValue(3.19m));
            var unitAmount1 = new ItemAmounts(item1Amount, item2Amount, 0.05m);
            var items = new[]
            {
                new InvoiceItem(
                    consumptionDate: new DateTime(2020, 06, 30),
                    totalAmounts: new ItemAmounts(item1Amount, item1Amount, 0.05m),
                    description: new Description("Httt hzi serts (fl)"),
                    measurementUnit: MeasurementUnit.Night,
                    quantity: 15,
                    unitAmounts: unitAmount1,
                    exchangeRate: new ExchangeRate(1)
                ),
                new InvoiceItem(
                    consumptionDate: new DateTime(2020, 06, 30),
                    totalAmounts: new ItemAmounts(item2Amount, item2Amount, 0.05m),
                    description: new Description("Httt hzi serts (fl)"),
                    measurementUnit: MeasurementUnit.Night,
                    quantity: -15,
                    unitAmounts: unitAmount1,
                    exchangeRate: new ExchangeRate(1)
                ),
            };

            var address = GetAddress();
            return new Invoice(
                number: new InvoiceNumber("ABC-18a"),
                issueDate: new DateTime(2020, 06, 30),
                supplierInfo: GetSupplierInfo(),
                customerInfo: GetCustomerInfo(),
                items: SequentialEnumerable.FromPreordered(items, startIndex: 1),
                paymentDate: new DateTime(2020, 06, 14),
                currencyCode: new CurrencyCode("EUR")
            );
        }

        private ModificationInvoice GetModificationInvoice()
        {
            var amounts = GetItemAmounts(amount: 100, exchangeRate: 300);
            var unitAmounts = GetItemAmounts(amount: 100, exchangeRate: 300);
            var item = new InvoiceItem(
                consumptionDate: new DateTime(2020, 08, 30),
                totalAmounts: amounts,
                description: new Description("NIGHT 8/30/2020"),
                measurementUnit: MeasurementUnit.Night,
                quantity: -1,
                unitAmounts: unitAmounts,
                exchangeRate: new ExchangeRate(300)
            );

            var amounts1 = GetItemAmounts(amount: 100, exchangeRate: 300);
            var unitAmounts1 = GetItemAmounts(amount: 100, exchangeRate: 300);
            var item1 = new InvoiceItem(
                consumptionDate: new DateTime(2020, 08, 31),
                totalAmounts: amounts1,
                description: new Description("NIGHT2 8/31/2020"),
                measurementUnit: MeasurementUnit.Night,
                quantity: 1,
                unitAmounts: unitAmounts1,
                exchangeRate: new ExchangeRate(300)
            );

            return new ModificationInvoice(
                number: new InvoiceNumber("ABC-18abfcefsaa"),
                supplierInfo: GetSupplierInfo(),
                customerInfo: GetCustomerInfo(),
                items: SequentialEnumerable.FromPreordered(new[] { item, item1 }, startIndex: 1),
                currencyCode: new CurrencyCode("USD"),
                issueDate: new DateTime(2020, 08, 31),
                paymentDate: new DateTime(2020, 08, 31),
                itemIndexOffset: 4,
                modificationIndex: 4,
                modifyWithoutMaster: true,
                originalDocumentNumber: new InvoiceNumber("ABC-18afasadafa")
            );
        }

        private CustomerInfo GetCustomerInfo()
        {
            return new CustomerInfo(
                taxpayerId: new TaxPayerId("14750636"),
                name: new Name("Vev Kft"),
                address: GetAddress()
            );
        }

        private SupplierInfo GetSupplierInfo()
        {
            return new SupplierInfo(
                taxpayerId: new TaxPayerId("14750636"),
                vatCode: new VatCode("2"),
                name: new Name("BUDAPESTI MSZAKI S GAZDASGTUDOMNYI EGYETEM"),
                address: GetAddress()
            );
        }

        private SimpleAddress GetAddress()
        {
            return new SimpleAddress(
                new City("Budapest"),
                new CountryCode("HU"),
                new AdditionalAddressDetail("Test"),
                new PostalCode("1111")
            );
        }

        private ItemAmounts GetItemAmounts(decimal amount, decimal exchangeRate = 1)
        {
            var amountHUF = amount * exchangeRate;
            return new ItemAmounts(
                amount: new Amount(
                    net: new AmountValue(amount),
                    gross: new AmountValue(amount),
                    tax: new AmountValue(amount)
                ),
                amountHUF: new Amount(
                    net: new AmountValue(amountHUF),
                    gross: new AmountValue(amountHUF),
                    tax: new AmountValue(amountHUF)
                )
            );
        }

        private void AssertError<TResult, TCode>(ResponseResult<TResult, TCode> result)
            where TResult : class
            where TCode : struct
        {
            Assert.IsNull(result.OperationalErrorResult);
            Assert.IsNull(result.GeneralErrorResult);
        }
    }
}
