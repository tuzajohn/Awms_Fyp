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
                            <div class="text-center">
                                <div class="circle" id="circles-1">
                                    <div class="circles-wrp" style="position: relative; display: inline-block;">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="120" height="120">
                                            <path fill="transparent" stroke="#f1f1f1" stroke-width="5" d="M 59.98828879078753 2.5000011926297603 A 57.5 57.5 0 1 1 59.92013365356088 2.500055466403218 Z" class="circles-maxValueStroke"></path><path fill="transparent" stroke="#000" stroke-width="5" d="M 59.98828879078753 2.5000011926297603 A 57.5 57.5 0 0 1 84.53293895598404 112.0037008892825 " class="circles-valueStroke circle-primary"></path></svg>
                                        <div class="circles-text" style="position: absolute; top: 0px; left: 0px; text-align: center; width: 100%; font-size: 42px; height: 120px; line-height: 120px;">43%</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card card-warning">
                        <div class="card-header">
                            <h3 class="card-title">Doctor(s)</h3>
                        </div>
                        <div class="card-block">
                            <div class="text-center">
                                <div class="circle" id="circles-2">
                                    <div class="circles-wrp" style="position: relative; display: inline-block;">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="120" height="120">
                                            <path fill="transparent" stroke="#f1f1f1" stroke-width="5" d="M 59.98828879078753 2.5000011926297603 A 57.5 57.5 0 1 1 59.92013365356088 2.500055466403218 Z" class="circles-maxValueStroke"></path><path fill="transparent" stroke="#000" stroke-width="5" d="M 59.98828879078753 2.5000011926297603 A 57.5 57.5 0 0 1 84.53293895598404 112.0037008892825 " class="circles-valueStroke circle-primary"></path></svg>
                                        <div class="circles-text" style="position: absolute; top: 0px; left: 0px; text-align: center; width: 100%; font-size: 42px; height: 120px; line-height: 120px;">43%</div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card card-warning">
                        <div class="card-header">
                            <h3 class="card-title">Appointment(s)</h3>
                        </div>
                        <div class="card-block">
                            <div class="text-center">
                                <div class="circle" id="circles-3">
                                    <div class="circles-wrp" style="position: relative; display: inline-block;">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="120" height="120">
                                            <path fill="transparent" stroke="#f1f1f1" stroke-width="5" d="M 59.98828879078753 2.5000011926297603 A 57.5 57.5 0 1 1 59.92013365356088 2.500055466403218 Z" class="circles-maxValueStroke"></path><path fill="transparent" stroke="#000" stroke-width="5" d="M 59.98828879078753 2.5000011926297603 A 57.5 57.5 0 0 1 84.53293895598404 112.0037008892825 " class="circles-valueStroke circle-primary"></path></svg>
                                        <div class="circles-text" style="position: absolute; top: 0px; left: 0px; text-align: center; width: 100%; font-size: 42px; height: 120px; line-height: 120px;">43%</div>
                                    </div>
                                </div>
                            </div>
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
                            <div class="table-responsive">
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
