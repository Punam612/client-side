<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="Assignment_SD.Invoice" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Generate Invoice</title>
    <link href="bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container border">
            <h2 class="text-center text-info">Invoice Details</h2>
            <hr />
            <fieldset class="border">
                <legend class="text-center text-danger">Seller Details</legend>
                <hr style="width:80px;height:2px; background-color:skyblue;"/>
                <div class="row">
                    <div class="col-md-4">
                        Name: 
                        <asp:TextBox ID="txtSellerName" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtSellerName" runat="server" ErrorMessage="Name is required." CssClass="text-danger" Display="Dynamic" />
                        <br />
                    </div>
                    <div class="col-md-4">
                        Address: 
                        <asp:TextBox ID="txtSellerAddress" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtSellerAddress" runat="server" ErrorMessage="Address is required." CssClass="text-danger" Display="Dynamic" />
                        <br />
                    </div>
                    <div class="col-md-4">
                        City: 
                        <asp:TextBox ID="txtSellerCity" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtSellerCity" runat="server" ErrorMessage="City is required." CssClass="text-danger" Display="Dynamic" />
                        <br />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        State: 
                        <asp:TextBox ID="txtSellerState" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtSellerState" runat="server" ErrorMessage="State is required." CssClass="text-danger" Display="Dynamic" />
                        <br />
                    </div>
                    <div class="col-md-4">
                        Pincode: 
                        <asp:TextBox ID="txtSellerPincode" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtSellerPincode" runat="server" ErrorMessage="Pincode is required." CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtSellerPincode" runat="server" ErrorMessage="Enter a valid pincode." ValidationExpression="^\d{6}$" CssClass="text-danger" Display="Dynamic" />
                        <br />
                    </div>
                    <div class="col-md-4">
                        PAN No.: 
                        <asp:TextBox ID="txtSellerPAN" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtSellerPAN" runat="server" ErrorMessage="PAN No. is required." CssClass="text-danger" Display="Dynamic" />
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtSellerPAN" runat="server" ErrorMessage="Enter a valid PAN No." ValidationExpression="^[A-Z]{5}\d{4}[A-Z]$" CssClass="text-danger" Display="Dynamic" />

                        <br />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        GST No.: 
                        <asp:TextBox ID="txtSellerGST" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtSellerGST" runat="server" ErrorMessage="GST No. is required." CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtSellerGST" runat="server" ErrorMessage="Enter a valid GST No." ValidationExpression="^\d{2}[A-Z]{5}\d{4}[A-Z]{1}[A-Z\d]{1}[Z]{1}[A-Z\d]{1}$" CssClass="text-danger" Display="Dynamic" />
                        <br />
                    </div>
                </div>
            </fieldset>
            <fieldset class="border">
                <legend class="text-center text-warning">Order Details</legend>
                <hr style="width:80px;height:2px; background-color:skyblue;"/>
                <div class="row">
                    <div class="col-md-4">
                        Order No.: 
                        <asp:TextBox ID="txtOrderNo" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtOrderNo" runat="server" ErrorMessage="Order No. is required." CssClass="text-danger" Display="Dynamic" />
                        <br />
                    </div>
                    <div class="col-md-4">
                        Order Date: 
                        <asp:TextBox ID="txtOrderDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtOrderDate" runat="server" ErrorMessage="Order Date is required." CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtOrderDate" runat="server" ErrorMessage="Invalid date format (MM/DD/YYYY)." ValidationExpression="^\d{2}/\d{2}/\d{4}$" CssClass="text-danger" Display="Dynamic" />
                        <br />
                    </div>
                </div>
            </fieldset>
            <fieldset class="border">
                <legend class="text-center text-warning">Invoice Details</legend>
                <hr style="width:80px;height:2px; background-color:skyblue;"/>
                <div class="row">
                    <div class="col-md-4">
                        Invoice No.: 
                        <asp:TextBox ID="txtInvoiceNo" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtInvoiceNo" runat="server" ErrorMessage="Invoice No. is required." CssClass="text-danger" Display="Dynamic" />
                        <br />
                    </div>
                    <div class="col-md-4">
                        Invoice Date: 
                        <asp:TextBox ID="txtInvoiceDate" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtInvoiceDate" runat="server" ErrorMessage="Invoice Date is required." CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtInvoiceDate" runat="server" ErrorMessage="Invalid date format (MM/DD/YYYY)." ValidationExpression="^\d{2}/\d{2}/\d{4}$" CssClass="text-danger" Display="Dynamic" />
                        <br />
                    </div>
                    <div class="col-md-4">
                        Reverse Charge: 
                        <asp:CheckBox ID="chkReverseCharge" runat="server" /><br />
                    </div>
                </div>
            </fieldset>
            <fieldset class="border">
                <legend class="text-center text-warning">Item Details</legend>
                <hr style="width:80px;height:2px; background-color:skyblue;"/>
                <div class="row">
                    <div class="col-md-4">
                        Description: 
                        <asp:TextBox ID="txtItemDescription" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtItemDescription" runat="server" ErrorMessage="Description is required." CssClass="text-danger" Display="Dynamic" />
                        <br />
                    </div>
                    <div class="col-md-4">
                        Unit Price: 
                        <asp:TextBox ID="txtUnitPrice" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="txtUnitPrice" runat="server" ErrorMessage="Unit Price is required." CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtUnitPrice" runat="server" ErrorMessage="Enter a valid unit price." ValidationExpression="^\d+(\.\d{1,2})?$" CssClass="text-danger" Display="Dynamic" />
                        <br />
                    </div>
                    <div class="col-md-4">
                        Quantity: 
                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="txtQuantity" runat="server" ErrorMessage="Quantity is required." CssClass="text-danger" Display="Dynamic" />
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txtQuantity" runat="server" ErrorMessage="Enter a valid quantity." ValidationExpression="^\d+$" CssClass="text-danger" Display="Dynamic" />
                        <br />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4">
                        Discount: 
                        <asp:TextBox ID="txtDiscount" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="txtDiscount" runat="server" ErrorMessage="Enter a valid discount." ValidationExpression="^\d+(\.\d{1,2})?$" CssClass="text-danger" Display="Dynamic" />
                        <br />
                    </div>
                </div>
            </fieldset>
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <asp:Button CssClass="btn btn-success" ID="btnGenerateInvoice" runat="server" Text="Generate Invoice" OnClick="btnGenerateInvoice_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
