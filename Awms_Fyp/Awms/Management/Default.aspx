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
                    <div class="card card-success">
                        <div class="card-header">
                            <h3 class="card-title">Admin(s)</h3>
                        </div>
                        <div class="card-block">
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card card-success">
                        <div class="card-header">
                            <h3 class="card-title">Doctor(s)</h3>
                        </div>
                        <div class="card-block">
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit.</p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card card-success">
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
                    <div class="card card-light">
                        <div class="card-header">
                            <h3 class="card-title">More Details</h3>
                        </div>
                        <div class="card-block">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">Admin(s)</h3>
                                </div>
                                <div class="panel-body">
                                    <table class="table table-border" id="admin_table">
                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                <th>Reg Number</th>
                                                <th>Test One</th>
                                                <th>Test Two</th>
                                                <th>Coursework</th>
                                                <th>Exam</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Literal runat="server" ID="marksLitera" />
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title">Doctor(s)</h3>
                                </div>
                                <div class="panel-body">
                                    <table class="table table-border" id="doc_table">
                                        <thead>
                                            <tr>
                                                <th>#</th>
                                                <th>Reg Number</th>
                                                <th>Test One</th>
                                                <th>Test Two</th>
                                                <th>Coursework</th>
                                                <th>Exam</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <asp:Literal runat="server" ID="marksLiteral" />
                                        </tbody>
                                    </table>
                                </div>
                            </div>
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
                    { "data": "Reg_Number" },
                    { "data": "Test_One" },
                    { "data": "Test_Two" },
                    { "data": "Coursework" },
                    { "data": "Exam" }
                ]
            });
        });
        $(document).ready(function () {
            $('#doc_table').DataTable({
                "columns": [
                    { "data": "#" },
                    { "data": "Reg_Number" },
                    { "data": "Test_One" },
                    { "data": "Test_Two" },
                    { "data": "Coursework" },
                    { "data": "Exam" }
                ]
            });
        });
    </script>
</asp:Content>
