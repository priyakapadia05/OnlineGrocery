﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="OnlineGrocery.View.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <%--<h1>Dashboard</h1>--%>
    <div class="container-fluid">
        <!-- Add some spacing at the top -->
        <div class="row" style="height: 100px">
            <div class="col-5"></div>
            <div class="col-md-8" top="20px">
                <div class="row">
                    <div class="col-1">
                        <img src="../../Asset/Images/Dashboard_layout.png" class="rounded" height="50px" width="50px" />
                    </div>
                    <div class="col-8">
                        <h2 class="text-success">FreshCart DashBoard</h2>
                    </div>
                </div>
            </div>
            <div class="col-md-1"></div>
        </div>

        <!-- Center the content horizontally -->
        <div class="row justify-content-center">
            <div class="col-10">
                <div class="row text-center justify-content-between">

                    <!-- Green Block -->
                    <div class="col-md-3 mb-4 bg-success text-white p-4 rounded mx-auto">
                        <div class="d-flex align-items-center justify-content-between">
                            <img src="../../Asset/Images/Product.png" class="img-fluid" style="height: 150px; width: 150px;" />
                            <div class="mx-3">
                                <h2>Products</h2>
                                <h4><%Response.Write(Session["Products"]); %></h4>
                            </div>
                        </div>
                    </div>

                    <!-- Orange Block -->
                    <div class="col-md-3 mb-4 bg-warning text-dark p-4 rounded mx-auto">
                        <div class="d-flex align-items-center justify-content-between">
                            <img src="../../Asset/Images/Category.png" class="img-fluid" height="140px" width="140px" />
                            <div class="mx-3">
                                <h2>Category</h2>
                                <h4><%Response.Write(Session["Category"]); %></h4>
                            </div>
                        </div>
                    </div>

                    <!-- Blue Block -->
                    <div class="col-md-3 mb-4 bg-primary text-white p-4 rounded mx-auto">
                        <div class="d-flex align-items-center justify-content-between">
                            <!-- Add icon if needed -->
                            <img src="../../Asset/Images/Rupee.png" class="img-fluid" style="height: 150px; width: 150px;" />
                            <div class="mx-3">
                                <h2>Finance</h2>
                                <h4><%Response.Write(Session["Finance"]); %></h4>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <div class="row mb-5 mt-5"></div>

        <div class="row justify-content-center">
            <div class="col-10">
                <div class="row">
                    <div class="mb-3" width:200px">
                            <label>Select Seller:</label>
                            <asp:DropDownList ID="ddlSeller" runat="server" OnSelectedIndexChanged="ddlSeller_SelectedIndexChanged"></asp:DropDownList>                        
                    </div>
                </div>
                <div class="row text-center justify-content-between">

                    <!-- Green Block -->
                    <div class="col-md-3 mb-4 bg-secondary text-white p-4 rounded mx-auto">
                        <div class="d-flex align-items-center justify-content-between">
                            <img src="../../Asset/Images/Amount.png" class="img-fluid" style="height: 150px; width: 150px;" />
                            <div class="mx-3">
                                <h4>Categories Amount</h4>
                                <h3><%Response.Write(Session["Category_amt"]); %></h3>
                            </div>
                        </div>
                    </div>

                    <!-- Orange Block -->
                    <div class="col-md-3 mb-4 bg-info text-dark p-4 rounded mx-auto">
                        <div class="d-flex align-items-center justify-content-between">
                            <img src="../../Asset/Images/tol_sell.png" class="img-fluid" height="140px" width="140px" />
                            <div class="mx-3">
                                <h4>Total Sells</h4>
                                <h3><%Response.Write(Session["Total_sells"]); %></h3>
                            </div>
                        </div>
                    </div>

                    <!-- Blue Block -->
                    <div class="col-md-3 mb-4 bg-dark text-white p-4 rounded mx-auto">
                        <div class="d-flex align-items-center justify-content-between">
                            <!-- Add icon if needed -->
                            <img src="../../Asset/Images/Seller.png" class="img-fluid" style="height: 150px; width: 150px;" />
                            <div class="mx-3">
                                <h4>Sellers</h4>
                                <h3><%Response.Write(Session["Sellers"]); %></h3>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-5"></div>
            <div class="col-4">
                <img src="../../Asset/Images/grocery.png" style="height: 300px" />
            </div>
            <div class="col-4"></div>
        </div>

    </div>
</asp:Content>
