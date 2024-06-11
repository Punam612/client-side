using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_SD
{
    public partial class Invoice : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Any initial page load logic
           // lblErrorMessage.Text = string.Empty;
        }

        protected void btnGenerateInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                // Collect inputs from the form
                string sellerName = txtSellerName.Text;
                string sellerAddress = txtSellerAddress.Text;
                string sellerCity = txtSellerCity.Text;
                string sellerState = txtSellerState.Text;
                string sellerPincode = txtSellerPincode.Text;
                string sellerPAN = txtSellerPAN.Text;
                string sellerGST = txtSellerGST.Text;

                string orderNo = txtOrderNo.Text;
                DateTime orderDate = DateTime.Parse(txtOrderDate.Text);

                string invoiceNo = txtInvoiceNo.Text;
                DateTime invoiceDate = DateTime.Parse(txtInvoiceDate.Text);
                bool reverseCharge = chkReverseCharge.Checked;

                string itemDescription = txtItemDescription.Text;
                decimal unitPrice = decimal.Parse(txtUnitPrice.Text);
                int quantity = int.Parse(txtQuantity.Text);
                decimal discount = string.IsNullOrWhiteSpace(txtDiscount.Text) ? 0 : decimal.Parse(txtDiscount.Text);

                // Insert seller, order, and invoice into the database
                int sellerID = DatabaseHelper.InsertSeller(sellerName, sellerAddress, sellerCity, sellerState, sellerPincode, sellerPAN, sellerGST);
                int orderID = DatabaseHelper.InsertOrder(orderNo, orderDate, sellerID);
                int invoiceID = DatabaseHelper.InsertInvoice(invoiceNo, invoiceDate, reverseCharge, orderID);

                // Insert item into the database
                int itemID = DatabaseHelper.InsertItem(itemDescription, unitPrice, quantity, discount, invoiceID);

                // Generate invoice HTML
                decimal netAmount = unitPrice * quantity - discount;
                decimal taxRate = 0.18m;
                decimal taxAmount = netAmount * taxRate;
                decimal totalAmount = netAmount + taxAmount;

                string htmlContent = @"
                    <html>
                    <head>
                        <style>
                            body {{ font-family: Arial, sans-serif; }}
                            table {{ width: 100%; border-collapse: collapse; }}
                            th, td {{ border: 1px solid black; padding: 8px; text-align: left; }}
                            th {{ background-color: #f2f2f2; }}
                        </style>
                    </head>
                    <body>
                        <h1>Invoice</h1>
                        <h2>Seller Details</h2>
                        <p>{sellerName}<br>{sellerAddress}<br>{sellerCity}, {sellerState} - {sellerPincode}<br>PAN No.: {sellerPAN}<br>GST Registration No.: {sellerGST}</p>
                        
                        <h2>Order Details</h2>
                        <p>Order No.: {orderNo}<br>Order Date: {orderDate:MM/dd/yyyy}</p>

                        <h2>Invoice Details</h2>
                        <p>Invoice No.: {invoiceNo}<br>Invoice Date: {invoiceDate:MM/dd/yyyy}<br>Reverse Charge: {(reverseCharge ? 'Yes' : 'No')}</p>

                        <h2>Item Details</h2>
                        <table>
                            <tr>
                                <th>Description</th>
                                <th>Unit Price</th>
                                <th>Quantity</th>
                                <th>Discount</th>
                                <th>Net Amount</th>
                                <th>Tax Amount</th>
                                <th>Total Amount</th>
                            </tr>
                            <tr>
                                <td>{itemDescription}</td>
                                <td>{unitPrice:C}</td>
                                <td>{quantity}</td>
                                <td>{discount:C}</td>
                                <td>{netAmount:C}</td>
                                <td>{taxAmount:C}</td>
                                <td>{totalAmount:C}</td>
                            </tr>
                        </table>

                        <p><b>Total Amount (in words):</b> {NumberToWords((int)totalAmount)} {((totalAmount - (int)totalAmount) * 100):0} / 100</p>
                    </body>
                    </html>
                ";

                // Convert HTML to PDF
                ConvertHtmlToPdf(htmlContent, "Invoice.pdf");

                // Clear form fields
                ClearFormFields();
            }
            catch (Exception ex)
            {
                // Handle errors (log, display message, etc.)
                // Example: lblErrorMessage.Text = "An error occurred: " + ex.Message;
            }
        }

        private void ClearFormFields()
        {
            txtSellerName.Text = "";
            txtSellerAddress.Text = "";
            txtSellerCity.Text = "";
            txtSellerState.Text = "";
            txtSellerPincode.Text = "";
            txtSellerPAN.Text = "";
            txtSellerGST.Text = "";
            txtOrderNo.Text = "";
            txtOrderDate.Text = "";
            txtInvoiceNo.Text = "";
            txtInvoiceDate.Text = "";
            chkReverseCharge.Checked = false;
            txtItemDescription.Text = "";
            txtUnitPrice.Text = "";
            txtQuantity.Text = "";
            txtDiscount.Text = "";
        }

        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] 
                {
                    "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", 
                    "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
                };
                var tensMap = new[] 
                {
                    "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
                };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        private void ConvertHtmlToPdf(string htmlContent, string outputPath)
        {
            // Use a PDF conversion library like DinkToPdf to convert HTML to PDF
            // Example using DinkToPdf:
            /*
            var converter = new SynchronizedConverter(new PdfTools());
            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = htmlContent,
                        WebSettings = { DefaultEncoding = "utf-8" },
                    }
                }
            };
            var pdf = converter.Convert(doc);
            File.WriteAllBytes(outputPath, pdf);
            */
        }
    }
}