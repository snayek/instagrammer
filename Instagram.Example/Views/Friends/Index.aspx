﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	You are following
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>You are following<% Html.RenderPartial("SubNav", ViewData["SubNavItems"]); %></h2>
    <% Html.RenderPartial("FriendRecords", ViewData["Follows"]); %>

</asp:Content>
