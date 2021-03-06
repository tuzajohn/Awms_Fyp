﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Password.aspx.cs" Inherits="Awms_Fyp.Awms.Doctor.Password" MasterPageFile="~/Awms/Doctor/Doctor.Master"%>

<asp:Content runat="server" ContentPlaceHolderID="title">

</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <asp:Literal runat="server" ID="MessageLiteral" />
    <form runat="server">
        <div class="card card-royal">
            <div class="card-header">
                <h3 class="card-title">Change Password</h3>
            </div>
            <div class="card-block">
                <div class="form-group is-empty">
                    <label class="control-label" for="oldPass">Old Password</label>
                    <input runat="server" class="form-control" id="oldPass" type="password" required="" />
                </div>
                <div class="form-group is-empty">
                    <label class="control-label" for="newPass">New Password</label>
                    <input runat="server" class="form-control" id="newPass" type="password" required="" />
                </div>
                <div class="form-group is-empty">
                    <label class="control-label" for="newPass">Repeat Password</label>
                    <input runat="server" class="form-control" id="newRepPass" type="password" required="" />
                </div>
                <a href="#" runat="server" id="savePassBtn" class="btn btn-block  btn-royal">Save</a>
            </div>
        </div>
    </form>
</asp:Content>