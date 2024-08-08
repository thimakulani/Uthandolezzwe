<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="TenderHome.aspx.cs" Inherits="Uthandolezzwe.Views.Tenders.TenderHome" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <a class="btn btn-primary" href="Create.aspx">ADD TENDER</a>
        <form runat="server">
            <asp:GridView AllowPaging="true" AutoGenerateColumns="false" ID="tenders" CssClass="table table-responsive" runat="server" OnRowCommand="tenders_RowCommand" >
                <Columns>
                    <asp:BoundField DataField="tenderid" HeaderText="ID" />
                    <asp:BoundField DataField="tender_name" HeaderText="TENDER NAME" />
                    <asp:BoundField DataField="bid_number" HeaderText="BID NUMBER" />
                    <asp:BoundField DataField="tendering_institution" HeaderText="TENDERING INSTITUTION" />
                    <asp:BoundField DataField="tendering_department" HeaderText="TENDERING DEPSARTMENT" />
                    <asp:BoundField DataField="attending_person" HeaderText="TENDERING INSTITUTION" />
                    <asp:BoundField DataField="office_due_date" HeaderText="OFFICE DUE DATE" />
                    <asp:BoundField DataField="tender_due_date" HeaderText="TENDER DUE DATE" />
                    <asp:BoundField DataField="project_type" HeaderText="PROJECT TYPE" />
                    <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn-sm btn-success" Text="VIEW" CommandName="ViewDetails" />
                </Columns>
            </asp:GridView>
        </form>

    </main>
</asp:Content>
