<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Appointment.aspx.cs" Inherits="Awms_Fyp.Awms.Doctor.Appointment" MasterPageFile="~/Awms/Doctor/Doctor.Master"%>

<asp:Content runat="server" ContentPlaceHolderID="title">

</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="body">
    <asp:Literal runat="server" ID="MessageLiteral" />
    <div class="card card-royal">
        <div class="card-header">
            <h3>Appointment ref:- [<asp:Literal runat="server" ID="AppointmentLiteral" />]</h3>
        </div>
        <div class="card-block">
            <div class="card">
                <div class="list-group">
                    <a href="javascript:void(0)" class="list-group-item withripple active">
                        <i class="zmdi zmdi-favorite"></i>Name
                            <p class="pull-right" runat="server" id="name">John Tuza</p>
                    </a>
                    <a href="javascript:void(0)" class="list-group-item withripple">
                        <i class="zmdi zmdi-cast"></i><b>Description</b>
                            <p class="pull-right" runat="server" id="desc">I have been experiencing severe headache, and fever. I thought it would go eventually but It has been two weeks now.</p>
                    </a>
                    <a href="javascript:void(0)" class="list-group-item withripple">
                        <i class="zmdi zmdi-map"></i><b>Address</b>
                        <p class="pull-right" runat="server" id="address">Mutungo Biina. Butabika road.</p>
                    </a>
                    <a href="javascript:void(0)" class="list-group-item withripple">
                        <i class="zmdi zmdi-time"></i><b>Date and Time</b>
                        <p class="pull-right" runat="server" id="dTime">Tuesday, 23 April 2018 17:00</p>
                    </a>
                    <div class="btn-group btn-group-justified">
                        <a href="#" class="btn btn-success">Accept</a>
                        <a href="#" class="btn btn-danger" data-toggle="modal" data-target="#denyModal">Deny</a>
                    </div>
                </div>
            </div>
            <div class="modal modal-danger" id="denyModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel6">
                <div class="modal-dialog animated zoomIn animated-3x" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true"><i class="zmdi zmdi-close"></i></span></button>
                            <h3 class="modal-title" id="myModalLabel6">Justification for Denial!</h3>
                        </div>
                        <div class="modal-body">

                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <form runat="server">
                                        <fieldset>
                                            <div class="form-group">
                                                <label for="SubjectBox" class="col-md-2 control-label">Subject</label>
                                                <div class="col-md-10">
                                                    <input runat="server" class="form-control" id="SubjectBox" placeholder="Subject.." required="required"/>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <label for="ReasonBox" class="col-md-2 control-label">Reason</label>

                                                <div class="col-md-10">
                                                    <textarea class="form-control" rows="4" id="ReasonBox" placeholder="Reason for denial!" required="required"></textarea>
                                                </div>
                                            </div>
                                        </fieldset>
                                    </form>
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            <button runat="server" id="SendBtn" class="btn  btn-warning">Send</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>