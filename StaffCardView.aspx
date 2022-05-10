<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffCardView.aspx.cs" Inherits="Card_View.StaffCardView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Card View Staff List..</title>
    <style type="text/css">
        #FlexMainContainer {
            display: flex;
            flex-direction: row;
            justify-content: center;
            flex-wrap: wrap;
            border: 2px solid #000000;
            background-color: #cecece;
            gap:10px;
        }

        .FlexChildContainer {
            border: 2px solid #CC0000;
            background-color: #FFFFFF;
            width: 200px;
            height: auto;
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            font-family: "Segoe UI";
            font-size: small;
            color: #333333;
            border-radius:10px;
        }
        .Staff_Photo_img{
            width:90px;
            height:90px;
            border-radius:100px;
            margin: 10px 0px 10px 0px;
        }
        #FlexChildContainer_ID p{
            margin: 5px 8px 5px 8px;
        }
        .FullName_P{
            color: #008800;
            font-size: medium;
            font-weight: bold;
        }
    </style>
</head>
<body dir="ltr">
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Button ID="Button1" runat="server" Text="Load All" OnClick="Button1_Click" />
            </div>
            <div id="FlexMainContainer" runat="server">
                
            </div>
        </div>
    </form>
</body>
</html>
