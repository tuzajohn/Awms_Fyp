<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Picture.aspx.cs" Inherits="Awms_Fyp.Awms.Patient.Picture" MasterPageFile="~/Awms/Patient/Patient.Master"%>
<asp:Content runat="server" ContentPlaceHolderID="title">

</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="body">
    <form runat="server">
        <div class="card card-primary">
            <div class="card-header">
                <h3 class="card-title">My Profile Image</h3>
            </div>
            <div class="card-block">
                <div class="row">
                    <div class="col-md-4">
                        <img class="img-responsive" id="profImage" src="../../Images/noimage.jpg" /><br />
                    </div>
                    <div class="col-md-8">
                        <div class="form-group is-empty is-fileinput">
                            <input type="file" runat="server" id="inputFile" />
                            <div class="input-group">
                                <input readonly="" class="form-control" placeholder="Select image" type="text" />
                                <span class="input-group-btn input-group-sm">
                                    <button type="button" class="btn btn-fab btn-fab-mini">
                                        <i class="material-icons">attach_file</i>
                                    </button>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
                <a href="#" runat="server" id="saveBtn" class="btn btn-block btn-primary">Save image</a>
            </div>
        </div>
    </form>
    <script>
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#profImage').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }
        }
        $("#body_body_inputFile").change(function () {
            readURL(this);
        });
    </script>
</asp:Content>
