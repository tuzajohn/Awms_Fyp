<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Awms_Fyp.Awms.Doctor.Default" MasterPageFile="~/Awms/Doctor/Doctor.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="title">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <div class="card card-royal">
        <div class="card-block">
            <div class="panel panel-royal">
                <div class="panel-heading">
                    <h3 class="panel-title">Appointment(s)<span class="badge badge-orange"><asp:Literal runat="server" ID="NewAppointmentsLiteral" /></span></h3>
                </div>
                <div class="panel-body">
                    <div class="table-responsive">
                        <table class="table table-border" id="app_table">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Patient Name</th>
                                    <th>Description</th>
                                    <th>Date</th>
                                    <th>Time</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Literal runat="server" ID="AppLiteral" />
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class="card card-royal">
                <div class="card-header">
                    <h3>My Shift TimeTable</h3>
                </div>
                <div class="card-block">
                    <form runat="server">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-responsive table-condensed">
                            <Columns>
                                <asp:BoundField DataField="Day" HeaderText="Day" HtmlEncode="false" />
                                <asp:BoundField DataField="PERIOD1" HeaderText="00:00 - 04:00" HtmlEncode="false" ControlStyle-Font-Size="XX-Small" />
                                <asp:BoundField DataField="PERIOD2" HeaderText="04:00 - 08:00" HtmlEncode="false" />
                                <asp:BoundField DataField="PERIOD3" HeaderText="08:00 - 12:00" HtmlEncode="false" />
                                <asp:BoundField DataField="PERIOD4" HeaderText="12:00 - 16:00" HtmlEncode="false" />
                                <asp:BoundField DataField="PERIOD5" HeaderText="16:00 - 20:00" HtmlEncode="false" />
                                <asp:BoundField DataField="PERIOD6" HeaderText="20:00 - 24:00" HtmlEncode="false" />
                            </Columns>
                        </asp:GridView>
                    </form>
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
