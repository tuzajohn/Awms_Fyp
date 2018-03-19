<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Awms_Fyp.Awms.Doctor.Default" MasterPageFile="~/Awms/Doctor/Doctor.Master"%>

<asp:Content runat="server" ContentPlaceHolderID="title">

</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <div class="card card-royal">
        <div class="card-block">
            <div class="panel panel-royal">
                <div class="panel-heading">
                    <h3 class="panel-title">Appointment(s)<span class="badge badge-orange"><asp:Literal runat="server" ID="NEwAppointmentsLiteral" />0</span></h3>
                </div>
                <div class="panel-body">
                    <table class="table table-border" id="app_table">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Patient Name</th>
                                <th>Description</th>
                                <th>Date and Time</th>
                                <th>Status</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Literal runat="server" ID="marksLitera" />
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
        <script type="text/javascript">
        $(document).ready(function () {
            $('#app_table').DataTable({
                "columns": [
                    { "data": "#" },
                    { "data": "Patient_Name" },
                    { "data": "Description" },
                    { "data": "Date_and_Time" },
                    { "data": "Status" }
                ]
            });
            });
        </script>
</asp:Content>