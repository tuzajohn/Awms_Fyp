<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Awms_Fyp.Awms.Account.Default" MasterPageFile="~/Awms/Account/Account.Master" %>
<asp:Content runat="server" ContentPlaceHolderID="title">
    Login
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <div class="card color-dark shadow-6dp animated fadeIn animation-delay-7">
        <div class="ms-hero-bg-primary ms-hero-img-mountain">
            <h2 class="text-center no-m pt-4 pb-4 color-white index-1">Login</h2>
        </div>
        <div class="card-block">
            <div class="tab-content">
                <div role="tabpanel" class="tab-pane fade active in" id="ms-login-tab">
                    <asp:Literal runat="server" ID="MessageLiteral" />
                    <form runat="server">
                        <fieldset>
                            <div class="form-group label-floating">
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="zmdi zmdi-account"></i>
                                    </span>
                                    <label class="control-label" for="userBox">Username</label>
                                    <input runat="server" type="text" id="userBox" class="form-control" />
                                </div>
                            </div>
                            <div class="form-group label-floating">
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="zmdi zmdi-lock"></i>
                                    </span>
                                    <label class="control-label" for="passBox">Password</label>
                                    <input runat="server" type="password" id="passBox" class="form-control" />
                                </div>
                            </div>
                            <div class="row ">
                                <div class="col-xs-5">
                                    <small><a href="register">Don't have an account</a></small><br />
                                    <small><a href="recover">Recover password</a></small>
                                </div>
                                <div class="col-xs-7">
                                    <button runat="server" id="loginBtn" class="btn btn-raised btn-primary pull-right">Login</button>
                                </div>
                            </div>
                        </fieldset>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

