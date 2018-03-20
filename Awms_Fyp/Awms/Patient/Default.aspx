<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Awms_Fyp.Awms.Patient.Default" MasterPageFile="~/Awms/Patient/Patient.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="title">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <div class="card card-info">
        <div class="card-block">
            <a href="#" class="btn btn-primary" data-toggle="modal" data-target="#app_modal">Schedule an Appointment
            </a>
            <div class="modal modal-primary" id="app_modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel6">
                <div class="modal-dialog animated zoomIn animated-3x" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true"><i class="zmdi zmdi-close"></i></span></button>
                            <h3 class="modal-title" id="myModalLabel6">Schedule Appointment</h3>
                        </div>
                        <form runat="server" class="form-horizontal">
                            <div class="modal-body">
                                <fieldset>
                                    <div class="form-group">
                                        <label for="datePicker" class="col-md-4 control-label">Select appointment date</label>
                                        <div class="col-md-8">
                                            <input id="datePicker" type="text" class="form-control" required="required" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="textArea" class="col-md-4 control-label">Description appointment</label>

                                        <div class="col-md-8">
                                            <textarea class="form-control" rows="2" id="textArea" required="required"></textarea>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                <button runat="server" id="schedulAppBtn" type="button" class="btn  btn-primary">Schedule</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>

            <hr class="color double dashed" />

            <div class="card card-primary animated fadeInUp animation-delay-7">
                <div class="card-header">
                    <h3 class="card-title">
                        <i class="zmdi zmdi-map"></i>Makerere University</h3>
                </div>
                <div class="row">
                    <iframe class="map-top col-md-12" width="598" height="450" src="https://www.google.com/maps/embed/v1/place?key=AIzaSyCkR2oB7b3i_NiKQp4sqhCZ18i3pT8D7SI&q=Makerere+University,Uganda"></iframe>
                </div>
                
            </div>

        </div>
    </div>
</asp:Content>
