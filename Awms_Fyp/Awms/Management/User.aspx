<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Awms_Fyp.Awms.Management.User" MasterPageFile="~/Awms/Management/Management.Master"%>
<asp:Content runat="server" ContentPlaceHolderID="sub_title">

</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <div class="card card-warning">
        <div class="card-header">
            <h3 class="card-title">User - [<asp:Literal runat="server" ID="NameLiteral" />]</h3>
        </div>
        <div class="card-block">
            <div class="row">
                <div class="col-md-4">
                    <asp:Literal runat="server" ID="ProfPicLiteral" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <ul class="list-group">
                        <li class="list-group-item"><h5 runat="server" id="fname">User's first name</h5></li>
                        <li class="list-group-item"><h5 runat="server" id="dob">User's DOB</h5></li>
                        <li class="list-group-item"><h5 runat="server" id="userTpe">User's Type</h5></li>
                    </ul>
                </div>
                <div class="col-md-6">
                    <ul class="list-group">
                        <li class="list-group-item"><h5 runat="server" id="lname">User's Last name</h5></li>
                        <li class="list-group-item"><h5 runat="server" id="contact">User's Contact</h5></li>
                        <li class="list-group-item"><h5 runat="server" id="speciality">User's Speciality</h5></li>
                    </ul>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <asp:Literal runat="server" ID="ShiftTable" />
                </div>
            </div>
        </div>
        <div class="card-footer">
            <a href="../../management/dashboard" class="color-light">Return</a>
        </div>
    </div>
</asp:Content>