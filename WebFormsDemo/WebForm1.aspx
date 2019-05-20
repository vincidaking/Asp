<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebFormsDemo.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .submit {
            background-color: #44c767;
            -moz-border-radius: 28px;
            -webkit-border-radius: 28px;
            border-radius: 28px;
            border: 1px solid #18ab29;
            display: inline-block;
            cursor: pointer;
            color: #ffffff;
            font-family: Arial;
            font-size: 17px;
            padding: 16px 31px;
            text-decoration: none;
            text-shadow: 0px 1px 0px #2f6627;
        }

            .submit:hover {
                background-color: #5cbf2a;
            }

            .submit:active {
                position: relative;
                top: 1px;
            }

        .container {
            margin: 0;
            width: 300px;
        }

        .item {
            float: left;
            width: 150px;
            height: 30px;
        }

        .clear {
            clear: both;
            width: 100%;
            height: 1px;
        }
    </style>
    <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
    <asp:Button ID="btnGet" runat="server" Text="Get Feed" OnClick="btnGet_Click" CssClass="submit" />
    <div class="row">
        <asp:Repeater ID="Repeater1" runat="server" ItemType="WebFormsDemo.Model.RSSItem">
            <ItemTemplate>
                <div class="col-md-6">
                    <h3><%# Item.Title %></h3>
                    <span><%# Item.PubDate %></span>
                    <p><%# Item.Description %></p>
                </div>
                
            </ItemTemplate>
        </asp:Repeater>
        <div class="clear"></div>
    </div>

    <%--<table style="width: 100%" >
            <asp:Repeater ID="Repeater1" runat="server" ItemType="WebFormsDemo.Model.RSSItem" >
        <ItemTemplate>
            <td>
                
            <h3><%# Item.Title %></h3>
            <span><%# Item.PubDate %></span>
            <p><%# Item.Description %></p>
                </td>
        </ItemTemplate>

    </asp:Repeater>    
</table>--%>
</asp:Content>
