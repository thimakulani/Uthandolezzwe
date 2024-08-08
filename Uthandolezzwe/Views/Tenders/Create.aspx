<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Create.aspx.cs" Inherits="Uthandolezzwe.Views.Tenders.Create" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <!-- Bootstrap CSS -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Optionally, include Bootstrap JavaScript for certain components -->
    <!-- <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script> -->

    <main>


        <div class="card">
            <div class="card-header p-2">
                <h3>ADD TENDER</h3>
            </div>
            <!-- /.card-header -->
            <div class="card-body">
                <!-- Tender Form -->
                <form enctype="multipart/form-data" runat="server" class="form-horizontal" method="post">
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Tender Name</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" type="text" class="form-control" ID="tender_name" placeholder="Tender Name" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Bid Number</label>
                        <div class="col-sm-10">

                            <asp:TextBox runat="server" CssClass="form-control" ID="bit_number"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Tendering Institution</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" type="text" class="form-control" ID="tendering_institution" placeholder="Tendering Institution" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Tendering Department</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" type="text" class="form-control" ID="tendering_department" placeholder="Tendering Department" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Person Attending This Tender</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" type="text" class="form-control" ID="attending_person" placeholder="Person Attending This Tender" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Due Date (Office Due Date)</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" type="date" class="form-control" ID="office_due_date" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Tender Due Date</label>
                        <div class="col-sm-10">
                            <asp:TextBox runat="server" type="date" class="form-control" ID="tender_due_date" />
                        </div>
                    </div>
                    <div class="form-group row">
                        <label class="col-sm-2 col-form-label">Project Type</label>
                        <div class="col-sm-10">

                            <asp:DropDownList CssClass="form-control" ID="project_type" runat="server">
                                <asp:ListItem Text="Construction" Value="Construction"></asp:ListItem>
                                <asp:ListItem Text="Supply and Delivery" Value="SupplyAndDelivery"></asp:ListItem>
                                <asp:ListItem Text="IT" Value="IT"></asp:ListItem>
                                <asp:ListItem Text="Maintenance" Value="Maintenance"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="offset-sm-2 col-sm-10">
                            <asp:Button runat="server" ID="BtnCreateTender" Text="Create Tender" class="btn-sm btn-primary" OnClick="BtnCreateTender_Click" />
                        </div>
                    </div>
                </form>
                <!-- /.tender-form -->
            </div>
            <!-- /.card-body -->
        </div>
        <!-- /.card -->


    </main>


</asp:Content>
