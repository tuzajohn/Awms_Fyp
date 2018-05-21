<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grid.aspx.cs" Inherits="Awms_Fyp.Awms.Patient.Grid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Day" HeaderText="Day" />
                    <asp:BoundField DataField="PERIOD1" HeaderText="0:00 - 4:00" />
                    <asp:BoundField DataField="PERIOD2" HeaderText="4:00 - 8:00" />
                    <asp:BoundField DataField="PERIOD3" HeaderText="8:00 - 12:00" />
                    <asp:BoundField DataField="PERIOD4" HeaderText="12:00 - 16:00" />
                    <asp:BoundField DataField="PERIOD5" HeaderText="16:00 - 20:00" />
                    <asp:BoundField DataField="PERIOD6" HeaderText="20:00 - 24:00" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
