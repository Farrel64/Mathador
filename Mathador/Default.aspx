<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Mathador._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row top-right">
        <span>Username :</span>
        <asp:TextBox class="form-control" ID="Username" runat="server"></asp:TextBox>
        <span>Score :</span>
        <asp:TextBox class="form-control" disabled ID="Score" runat="server"></asp:TextBox>
        <asp:Button class="btn btn-primary" ID="Save" runat="server" Text="Sauvegarder" OnClick="saveScore" />
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Label ID="Errors" Text="" runat="server" />
   
    <div class="row">
        <span>Nombres à dispostion :</span>
        <% if (values.Count >= 1)
            {%>
        <asp:Button class="btn btn-default" ID="Button2" runat="server" OnClick="ajouterPile" />
        <% }%>
        <% if (values.Count >= 2)
            {%>
        <asp:Button class="btn btn-default" ID="Button3" runat="server" OnClick="ajouterPile" />
        <% }%>
        <% if (values.Count >= 3)
            {%>
        <asp:Button class="btn btn-default" ID="Button4" runat="server" OnClick="ajouterPile" />
        <% }%>
        <% if (values.Count >= 4)
            {%>
        <asp:Button class="btn btn-default" ID="Button5" runat="server" OnClick="ajouterPile" />
        <% }%>
        <% if (values.Count >= 5)
            {%>
        <asp:Button class="btn btn-default" ID="Button6" runat="server" OnClick="ajouterPile" />
        <% }%>
    </div>

    <div class="row come-back">
        <span>Opérateurs :</span>
        <asp:Button class="btn btn-default" ID="Button7" runat="server" OnClick="ajouterPile" Text="+" />
        <asp:Button class="btn btn-default" ID="Button8" runat="server" OnClick="ajouterPile" Text="-" />
        <asp:Button class="btn btn-default" ID="Button9" runat="server" OnClick="ajouterPile" Text="*" />        
        <asp:Button class="btn btn-default" ID="Button10" runat="server" OnClick="ajouterPile" Text="/" />
    </div>
                </ContentTemplate>
        </asp:UpdatePanel>
    
            <div class="row styles">
                <span>Nombre à atteindre :</span>
                <asp:TextBox class="form-control" disabled ID="Solution" runat="server"></asp:TextBox>
     <asp:UpdatePanel ID="TimerPanel" runat="server">
        <ContentTemplate>
                    <div class="top-right">
                        <span>Temps restant :</span>
                        <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>
                        <asp:Label ID="Chrono" runat="server"></asp:Label>
                    </div>
            </ContentTemplate>
    </asp:UpdatePanel>
            <div class="row styles">
                <asp:Button class="btn btn-primary" ID="Reset" runat="server"  OnClick="Reset_Click" Text="Reset" />
            </div>
            </div>
        

</asp:Content>
