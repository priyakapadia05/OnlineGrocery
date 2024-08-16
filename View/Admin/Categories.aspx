﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="OnlineGrocery.View.Admin.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Mybody" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-8">
                    <br />
                    <img src="../../Asset/Images/vegetables.jpg" height="200px" width="200px" /><h4 style="color: darkgreen">Manage Category</h4>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <h2 class="text-success">Category Details</h2>

                <div class="mb-3">
                    <label>Category Name:</label>
                    <asp:TextBox ID="txtCatdname" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label>Category remarks:</label>
                    <asp:TextBox ID="txtCatremarks" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <label id="lblMsg" runat="server" class="text-success"></label><br />
                <asp:Button ID="btnEdit" runat="server" Text="   Edit   " class="btn btn-success" OnClick="btnEdit_Click"/>
                <asp:Button ID="btnSave" runat="server" Text="   Save   " class="btn btn-success"  OnClick="btnSave_Click"/>
            </div>
            <div class="col-md-8">
                <asp:GridView ID="dtgCategory" runat="server" class="table table-hover" AutoGenerateDeleteButton="True" AutoGenerateSelectButton="True" OnRowDeleting="dtgCategory_RowDeleting" OnSelectedIndexChanged="dtgCategory_SelectedIndexChanged" ></asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>