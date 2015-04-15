<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pager.ascx.cs" Inherits="WebSite.Web.UserControl.Pager" %>
<div class=" clearfix mt">
    <div class="pull-left">共有 <span class="label label-important">
        <asp:Literal ID="lblCount" runat="server"></asp:Literal></span> 条，当前 <span class="label label-success">
            <asp:Literal ID="litPageNo" runat="server"></asp:Literal>/<asp:Literal ID="labPcount" runat="server"></asp:Literal>
        </span> 页</div>
    <div class="pull-right">
        <div class="pagination  pagination-small">
            <ul>
                <asp:Literal runat="server" ID="litPag"></asp:Literal>
            </ul>
        </div>
    </div>
</div>
