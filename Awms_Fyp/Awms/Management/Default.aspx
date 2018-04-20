<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Awms_Fyp.Awms.Management.Default" MasterPageFile="~/Awms/Management/Management.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="sub_title">
    Home
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">

    <asp:Literal runat="server" ID="MessageLiteral" />
    <div class="card card-warning">
        <div class="card-block">
            <div class="row">
                <div class="col-md-4">
                    <div class="card card-warning">
                        <div class="card-header">
                            <h3 class="card-title">Admin(s)</h3>
                        </div>
                        <div class="card-block">
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card card-warning">
                        <div class="card-header">
                            <h3 class="card-title">Doctor(s)</h3>
                        </div>
                        <div class="card-block">
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card card-warning">
                        <div class="card-header">
                            <h3 class="card-title">Appointment(s)</h3>
                        </div>
                        <div class="card-block">
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.</p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel panel-warning">
                        <div class="panel-heading">
                            <h3 class="panel-title">User(s)</h3>
                        </div>
                        <div class="panel-body">
                            <table class="table table-border" id="admin_table">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Name</th>
                                        <th>Contact</th>
                                        <th>Age</th>
                                        <th>Type</th>
                                        <th>Profession</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Literal runat="server" ID="UserLiteral" />
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#admin_table').DataTable({
                "columns": [
                    { "data": "#" },
                    { "data": "Name" },
                    { "data": "Contact" },
                    { "data": "Age" },
                    { "data": "Type" },
                    { "data": "Profession" }
                ]
            });
        });
    </script>
</asp:Content>
