<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add Doctor.aspx.cs" Inherits="Awms_Fyp.Awms.Management.Add_Doctor" MasterPageFile="~/Awms/Management/Management.Master"%>
<asp:Content runat="server" ContentPlaceHolderID="sub_title">
    New Doctor
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <asp:Literal runat="server" ID="MessageLiteral" />
    <div class="card card-warning">
        <div class="card-header">
            <h3>New Doctor</h3>
        </div>
        <div class="card-block">
            <form runat="server">
                <fieldset>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group label-floating">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-user"></i>
                                                    </span>
                                                    <label class="control-label" for="userBox">First Name</label>
                                                    <input runat="server" type="text" id="fnameBox" class="form-control" required="" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group label-floating">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-user"></i>
                                                    </span>
                                                    <label class="control-label" for="userBox">Last Name</label>
                                                    <input runat="server" type="text" id="lname" class="form-control" required="" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group label-floating">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-envelope"></i>
                                                    </span>
                                                    <label class="control-label" for="userBox">Email</label>
                                                    <input runat="server" type="text" id="emailBox" class="form-control" required="" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group label-floating">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-address-book"></i>
                                                    </span>
                                                    <label class="control-label" for="userBox">Contact</label>
                                                    <input runat="server" type="text" id="contactBox" class="form-control" required="" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <div class="btn-group bootstrap-select form-control">
                                                    <select runat="server" id="professionSelect" class="form-control selectpicker" data-dropup-auto="false" tabindex="-98">
                                                        <option class="disable">Profession</option>
                                                        <option>Dentist</option>
                                                        <option>Optician</option>
                                                        <option>Medical Officer</option>
                                                    </select>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-calendar"></i>
                                                    </span>
                                                    <label class="control-label" for="userBox">Date of Birth</label>
                                                    <input runat="server" id="dob" type="date" class="form-control" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="control-label" for="userBox">Gender</label>
                                                <div class="btn-group bootstrap-select form-control">
                                                    <select runat="server" id="genderSelect" class="form-control selectpicker" data-dropup-auto="false" tabindex="-98">
                                                        <option>Gender</option>
                                                        <option>Female</option>
                                                        <option>Male</option>
                                                    </select>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group label-floating">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-map-marker"></i>
                                                    </span>
                                                    <label class="control-label" for="userBox">Address</label>
                                                    <textarea runat="server" class="form-control" rows="1" id="addressBox"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="text-center ">
                            <a href="#" runat="server" id="NxtBtn" class="btn btn-royal btn-block">Next<i class="fa fa-arrow-right"></i></a>
                        </div>
                    </div>

                </fieldset>
            </form>
        </div>
    </div>

</asp:Content>