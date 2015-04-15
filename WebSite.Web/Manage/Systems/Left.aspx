<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="WebSite.Web.Manage.Systems.Left" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/themes/default/main.css" rel="stylesheet" type="text/css">
    <script type="text/javascript" src="/themes/js/jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="/themes/js/wiimedia-market.js"></script>
</head>
<body class="left">
    <ul class="nav">
        <%
      
            System.Data.DataTable table = GetUrl();
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        if (getTopURL(table.Rows[i]["PC_Id"]) != "")
                        {
        %>
        <li><a href='<%= getTopURL(table.Rows[i]["PC_Id"]) == "" ? "javascript:;" : getTopURL(table.Rows[i]["PC_Id"]) + "?id=" + table.Rows[i]["PC_Id"] %>' target="mainFrame" id="a2"><span></span><%= table.Rows[i]["PC_Name"] %></a></li>
        <%
                        }
                    }
                }
            } %>
    </ul>
</body>
</html>
