<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add User.aspx.cs" Inherits="Awms_Fyp.Awms.Management.Add_User" MasterPageFile="~/Awms/Management/Management.Master"%>

<asp:Content runat="server" ContentPlaceHolderID="sub_title">
    New Admin
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="body">
    <div class="card card-warning">
        <div class="card-block">
            <div class="row">
                <div class="col-md-12">
                    <div class="card card-warning">
                        <div class="card-header">
                            <h2><i class="fa fa-user-plus"></i></h2> 
                        </div>
                        <div class="card-block">
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
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-calendar"></i>
                                                    </span>
                                                    <label class="control-label" for="userBox">Date of Birth</label>
                                                    <input runat="server" id="datePicker" type="text" class="form-control" />
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
                                                    <label class="control-label" for="userBox">Address</label>
                                                    <textarea class="form-control" rows="1" id="textArea"></textarea>
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
                                    <button runat="server" id="createBtn" class="btn btn-raised btn-block btn-warning">Create Now</button>
                                </fieldset>
                            </form>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>