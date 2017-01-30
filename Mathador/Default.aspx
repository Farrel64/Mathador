<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mathador._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="Label4" Text="" runat="server" />
    <div class="row">
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" />
        <asp:Button ID="Button11" runat="server"  OnClick="Button11_Click" Text="Reset" />
    </div>
    
    <div class="row">
        <% if (values.Count >= 1)
            {%>
        <asp:Button ID="Button2" runat="server" OnClick="ajouterPile" />
        <% }%>
        <% if (values.Count >= 2)
            {%>
        <asp:Button ID="Button3" runat="server" OnClick="ajouterPile" />
        <% }%>
        <% if (values.Count >= 3)
            {%>
        <asp:Button ID="Button4" runat="server" OnClick="ajouterPile" />
        <% }%>
        <% if (values.Count >= 4)
            {%>
        <asp:Button ID="Button5" runat="server" OnClick="ajouterPile" />
        <% }%>
        <% if (values.Count >= 5)
            {%>
        <asp:Button ID="Button6" runat="server" OnClick="ajouterPile" />
        <% }%>
    </div>

    <div class="row">
        <asp:Button ID="Button7" runat="server" OnClick="ajouterPile" Text="+" />
        <asp:Button ID="Button8" runat="server" OnClick="ajouterPile" Text="-" />
        <asp:Button ID="Button9" runat="server" OnClick="ajouterPile" Text="*" />        
        <asp:Button ID="Button10" runat="server" OnClick="ajouterPile" Text="/" />
    </div>
    <div>
        <asp:TextBox ID="Solution" runat="server"></asp:TextBox>
            <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
            </asp:Timer>
            <asp:Label ID="Label1" runat="server"></asp:Label>
    </div>    
   </ContentTemplate>
  </asp:UpdatePanel>
  

</asp:Content>
