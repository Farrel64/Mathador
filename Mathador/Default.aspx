<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mathador._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </div>
    <div class="row">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" />
    </div>

    <div class="row">
        <asp:Button ID="Button2" runat="server" OnClick="ajouterPile" />
        <asp:Button ID="Button3" runat="server" OnClick="ajouterPile" />
        <asp:Button ID="Button4" runat="server" OnClick="ajouterPile" />        
        <asp:Button ID="Button5" runat="server" OnClick="ajouterPile" />
        <asp:Button ID="Button6" runat="server" OnClick="ajouterPile" />
    </div>

    <div class="row">
        <asp:Button ID="Button7" runat="server" OnClick="ajouterPile" Text="+" />
        <asp:Button ID="Button8" runat="server" OnClick="ajouterPile" Text="-" />
        <asp:Button ID="Button9" runat="server" OnClick="ajouterPile" Text="*" />        
        <asp:Button ID="Button10" runat="server" OnClick="ajouterPile" Text="/" />
    </div>

</asp:Content>
