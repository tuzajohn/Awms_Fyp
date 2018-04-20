<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Username.aspx.cs" Inherits="Awms_Fyp.Awms.Doctor.Username" MasterPageFile="~/Awms/Doctor/Doctor.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="title">

</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <asp:Literal runat="server" ID="MessageLiteral" />
    <form runat="server">
        <div class="card card-royal">
            <div class="card-header">
                <h3 class="card-title">Change Username</h3>
            </div>
            <div class="card-block">
                <div class="form-group is-empty">
                    <label class="control-label" for="oldusername">Old Username</label>
                    <input runat="server" class="form-control" id="oldusername" type="text" required="" />
                </div>
                <div class="form-group is-empty">
                    <label class="control-label" for="newusername">New Username</label>
                    <input runat="server" class="form-control" id="newusername" type="text" required="" />
                </div>
                <a href="#" runat="server" id="saveUserBtn" class="btn btn-block btn-royal">Save</a>
            </div>
        </div>
    </form>
</asp:Content>