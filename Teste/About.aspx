<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Teste.About" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>

    <div>
        <asp:GridView ID="dgPrincipal" runat="server" OnRowDataBound="dgPrincipal_RowDataBound" DataKeyNames="Id" Width="100%"  GridLines="None"
                 HeaderStyle-CssClass="gvHeader"  CssClass="gvRow"  AlternatingRowStyle-CssClass="gvAltRow"
                 AutoGenerateColumns="False"  >
            <Columns>
                <asp:TemplateField>
            <ItemTemplate>
                <button class="glyphicon glyphicon-chevron-down vira" type="button"  data-toggle="collapse" data-target="#<%# Eval("Id") %>" aria-expanded="true" aria-controls="<%# Eval("Id") %>" ></button>
            </ItemTemplate>
        </asp:TemplateField>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Telefone" HeaderText="Telefone" />
                <%--<asp:BoundField DataField="Modelo" />--%>

                <asp:TemplateField HeaderText="Modelo">
                    <ItemTemplate>
                        <%# Eval("Modelo") %>
                        <%# NovaLinha(Eval("Id")) %>

                        <asp:GridView ID="gvOrders" runat="server" Width="100%"
                            GridLines="None" AutoGenerateColumns="false" 
                            HeaderStyle-CssClass="gvChildHeader" CssClass="gvRow" Style="padding: 0; margin: 0"
                            AlternatingRowStyle-CssClass="gvAltRow">
                            <Columns>
                                
                                <asp:BoundField DataField="Valor" HeaderText="Valor" />
                                <asp:BoundField DataField="Data" HeaderText="Data" />
                            </Columns>

                        </asp:GridView>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <script>
       
            $(".vira").click(function () {

                if ($(this).hasClass('glyphicon-chevron-down')) {
                    $(this).removeClass('glyphicon-chevron-down');
                    $(this).addClass('glyphicon-chevron-up');
                }
                else {
                    $(this).removeClass('glyphicon-chevron-up');
                    $(this).addClass('glyphicon-chevron-down');
                }


            })
     
    </script>
</asp:Content>

