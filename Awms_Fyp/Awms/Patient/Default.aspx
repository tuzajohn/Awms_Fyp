<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Awms_Fyp.Awms.Patient.Default" MasterPageFile="~/Awms/Patient/Patient.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="title">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <asp:Literal runat="server" ID="MessageLiteral" />
    <div class="card card-info">
        <div class="card-block">
            <div class="panel-group ms-collapse no-margin" id="accordion12" role="tablist" aria-multiselectable="true">
                <div class="panel panel-primary">
                    <div class="panel-heading" role="tab" id="headingOne12">
                        <h4 class="panel-title">
                            <a class="withripple collapsed" role="button" data-toggle="collapse" data-parent="#accordion12" href="#collapseOne12" aria-expanded="false" aria-controls="collapseOne12">
                                <i class="zmdi zmdi-calendar"></i>Schedule Appointment
                                            <div class="ripple-container"></div>
                            </a>
                        </h4>
                    </div>
                    <div id="collapseOne12" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne12" aria-expanded="false" style="height: 0px;">
                        <div class="panel-body">
                            <form runat="server">
                                <div class="row">
                                    <div class="col-md-12">
                                        <fieldset>
                                            <div class="form-group label-floating">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-newspaper-o"></i>
                                                    </span>
                                                    <label class="control-label" for="userBox">Message</label>
                                                    <textarea runat="server" class="form-control" rows="1" id="messageBox" required="required"></textarea>
                                                </div>
                                            </div>
                                        </fieldset>
                                        <button runat="server" class="btn btn-block btn-raised btn-primary" id="saveBtn" value="john">Let's schedule</button>
                                    </div>
                                </div>
                                <asp:Literal runat="server" ID="ListLiteral" />

                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
                                    <Columns>
                                        <asp:BoundField DataField="Day" HeaderText="Day" HtmlEncode="false"/>
                                        <asp:BoundField DataField="PERIOD1" HeaderText="00:00 - 04:00" HtmlEncode="false" />
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
                <div class="panel panel-primary">
                    <div class="panel-heading" role="tab" id="headingTwo12">
                        <h4 class="panel-title">
                            <a class="collapsed withripple" role="button" data-toggle="collapse" data-parent="#accordion12" href="#collapseTwo12" aria-expanded="false" aria-controls="collapseTwo12">
                                <i class="zmdi zmdi-pin"></i>Our Location </a>
                        </h4>
                    </div>
                    <div id="collapseTwo12" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo12" aria-expanded="false">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <iframe class="map-top col-md-12" height="450" src="https://www.google.com/maps/embed/v1/place?key=AIzaSyCkR2oB7b3i_NiKQp4sqhCZ18i3pT8D7SI&q=Makerere+University,Uganda"></iframe>
                                </div>
                            </div>                            
                        </div>
                    </div>
                </div>
            </div>
            <hr class="color double dashed" />
            
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#bodybody_GridView1').DataTable({
                "columns": [
                    { "data": "#" },
                    { "data": "Day" },
                    { "data": "PERIOD1" },
                    { "data": "PERIOD2" },
                    { "data": "PERIOD3" },
                    { "data": "PERIOD4" },
                    { "data": "PERIOD5" },
                    { "data": "PERIOD6" }
                ]
            });
        });
    </script>
</asp:Content>
