<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Doctor Detail.aspx.cs" Inherits="Awms_Fyp.Awms.Management.Doctor_Detail" MasterPageFile="~/Awms/Management/Management.Master"%>
<asp:Content runat="server" ContentPlaceHolderID="sub_title">

</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
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
                                    <div class="card-block">
                                        <div class="row">
                                            <div class="col-md-4">
                                                <asp:Image runat="server" CssClass="img-responsive" ID="profImage" ImageUrl="../../Images/noimage.jpg" /><br />
                                            </div>
                                            <div class="col-md-8">
                                                <div class="form-group is-empty is-fileinput">
                                                    <asp:FileUpload runat="server" ID="input" />
                                                    <div class="input-group">
                                                        <input readonly="" class="form-control" placeholder="Select profile image" type="text" />
                                                        <span class="input-group-btn input-group-sm">
                                                            <button type="button" class="btn btn-fab btn-fab-mini">
                                                                <i class="material-icons">attach_file</i>
                                                            </button>
                                                        </span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="panel panel-default">
                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group label-floating">
                                                <div class="input-group">
                                                    <span class="input-group-addon">
                                                        <i class="fa fa-user-circle"></i>
                                                    </span>
                                                    <label class="control-label" for="userBox">Username</label>
                                                    <input runat="server" type="text" id="userBox" class="form-control" required="" />
                                                </div>
                                            </div>
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
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="text-center ">
                            <a href="#" runat="server" id="SaveBtn" class="btn btn-warning btn-block">Save<i class="fa fa-check"></i></a>
                        </div>
                    </div>

                </fieldset>
            </form>
        </div>
    </div>
</asp:Content>