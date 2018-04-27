<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Awms_Fyp.Awms.Account.Register" MasterPageFile="~/Awms/Account/Account.Master"%>
<asp:Content runat="server" ContentPlaceHolderID="title">
    Create Account
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <div class="card color-dark shadow-6dp animated fadeIn animation-delay-7">
        <div class="ms-hero-bg-primary ms-hero-img-mountain">
            <h2 class="text-center no-m pt-4 pb-4 color-white index-1">Create Account</h2>
        </div>
        <div class="card-block">
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane active in" id="ms-register-tab">
                    <asp:Literal runat="server" ID="MessageLiteral" />
                    <form runat="server">
                        <fieldset>
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
                                    <div class="form-group label-floating">
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
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
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
                                            <label class="control-label" for="addressBox">Address</label>
                                            <textarea runat="server" class="form-control" rows="3" id="addressBox"></textarea>                                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group label-floating">
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="fa fa-user-circle"></i>
                                    </span>
                                    <label class="control-label" for="userBox">Username</label>
                                    <input runat="server" type="text" id="userBox" class="form-control" required="" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group label-floating">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="zmdi zmdi-lock"></i>
                                            </span>
                                            <label class="control-label" for="passBox">Password</label>
                                            <input runat="server" type="password" id="passBox" class="form-control" required="" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group label-floating">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="zmdi zmdi-lock"></i>
                                            </span>
                                            <label class="control-label" for="rePass">Re-type Password</label>
                                            <input runat="server" type="password" id="rePass" class="form-control" required="" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <button runat="server" id="regBtn" class="btn btn-raised btn-block btn-primary">Register Now</button>
                        </fieldset>
                    </form>
                </div>
            </div>
        </div>
    </div>
    <div class="text-center animated fadeInUp animation-delay-7">
        <a href="login" class="btn btn-white">
            <i class="zmdi zmdi-home"></i>Go Home</a>
    </div>
</asp:Content>
