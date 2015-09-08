<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <%-- <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css "/>
  <script src="//code.jquery.com/jquery-1.10.2.js"></script>
  <script src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
  <link rel="stylesheet" href="/resources/demos/style.css "/>
  <script>
      $(function () {
          $("#datepicker").datepicker();
      });
  </script>--%>
  <%-- <link type="text/css" href="css/smoothness/jquery-ui-1.7.1.custom.css" rel="stylesheet" />
     <script src="_scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
     <script src="_scripts/jquery-ui-1.7.1.custom.min.js" type="text/javascript"></script>
  <script type="text/javascript">
      $(function () {
          $("#txtDate").datepicker();
      });

	</script>--%>



    <style type="text/css">
        
        .MyCalendar .ajax__calendar_container {
    border:1px solid #646464;
    background-color: lemonchiffon;
    color: red;
}
          .word1 {
        font-family:微軟正黑體11;

        }

        .word {
        font-family:微軟正黑體;
        color:white;
        }
                .word4 {
        font-family:微軟正黑體;
        color:red;
        font-size:14px;

        }
           .word3 {
        font-family:微軟正黑體;
        font-size:16px;
        font-weight:bold;
        color:black;
        text-align:center;
        }
        .auto-style1 {
            width: 300px;
            height: 60px;
        }

        .bcolor {
        color:#646464;
        font-weight:bold;
        font-size:12px;
        }
        .align1 {
        text-align:center
        }

      body {
          font-family:微軟正黑體;
background: rgb(249,252,247); /* Old browsers */
/* IE9 SVG, needs conditional override of 'filter' to 'none' */
background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPGxpbmVhckdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgeDE9IjAlIiB5MT0iMTAwJSIgeDI9IjEwMCUiIHkyPSIwJSI+CiAgICA8c3RvcCBvZmZzZXQ9IjAlIiBzdG9wLWNvbG9yPSIjZjlmY2Y3IiBzdG9wLW9wYWNpdHk9IjEiLz4KICAgIDxzdG9wIG9mZnNldD0iMTAwJSIgc3RvcC1jb2xvcj0iI2QwZDZjZiIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgPC9saW5lYXJHcmFkaWVudD4KICA8cmVjdCB4PSIwIiB5PSIwIiB3aWR0aD0iMSIgaGVpZ2h0PSIxIiBmaWxsPSJ1cmwoI2dyYWQtdWNnZy1nZW5lcmF0ZWQpIiAvPgo8L3N2Zz4=);
background: -moz-linear-gradient(45deg,  rgba(249,252,247,1) 0%, rgba(208,214,207,1) 100%); /* FF3.6+ */
background: -webkit-gradient(linear, left bottom, right top, color-stop(0%,rgba(249,252,247,1)), color-stop(100%,rgba(208,214,207,1))); /* Chrome,Safari4+ */
background: -webkit-linear-gradient(45deg,  rgba(249,252,247,1) 0%,rgba(208,214,207,1) 100%); /* Chrome10+,Safari5.1+ */
background: -o-linear-gradient(45deg,  rgba(249,252,247,1) 0%,rgba(208,214,207,1) 100%); /* Opera 11.10+ */
background: -ms-linear-gradient(45deg,  rgba(249,252,247,1) 0%,rgba(208,214,207,1) 100%); /* IE10+ */
background: linear-gradient(45deg,  rgba(249,252,247,1) 0%,rgba(208,214,207,1) 100%); /* W3C */
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#f9fcf7', endColorstr='#d0d6cf',GradientType=1 ); /* IE6-8 fallback on horizontal gradient */




background-repeat : no-repeat; 
background-position: center;
background-size:cover;
}

        .round {
    border: 1px solid;
    border-radius: 5px;
        
        }

    </style>

    <script type="text/javascript">
        function ConfirmMe() {
            if (Page_ClientValidate()) {
                return confirm('確定送出嗎?');
            }
            else {
                return false;
            }
        }
</script>



</head>
<body >
    <form id="form1" runat="server" >
        <br/>
        <div class="align1">
           <img alt="report" class="auto-style1" src="img/headers.png" />
            </div>
     
       
        <div  align="center">
            <br/>
                 <p class="word3">
        帳號：<asp:TextBox ID="tbid" runat="server" CssClass="round" Height="18px" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9"  ControlToValidate="tbid" runat="server" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                        <%--<asp:TextBox ID="TextBox1" runat="server" Width="1px" Visible="false" Text="@excelsiorgroup.com.tw"></asp:TextBox>--%>

    </p>
    <p class="word3">
        密碼：<asp:TextBox ID="tbpd" runat="server" TextMode="Password" CssClass="round" Height="18px" Width="150px"></asp:TextBox>
            <asp:Regularexpressionvalidator id="nameRegex" runat="server" 
        ControlToValidate="tbpd" 
        ValidationExpression="^([a-zA-Z0-9]{1,40})+$" 
        ErrorMessage="*" ForeColor="Red">
  </asp:Regularexpressionvalidator>
    <br/>
   </p>
          
            <p>
  
        <asp:Button ID="Button2" runat="server" Text="登入" OnClick="Button2_Click" CssClass="word1" Height="26px" Width="90px" />
        <asp:Label ID="Label6" runat="server"></asp:Label>
 </p>
             <br/>

            </div>
         
        <p></p>
        <p></p>
        <p></p>
        <br/>
         <br/>

      <div class="bcolor" align="center">  Copyright © 2014 Excelsior Biopharma Inc. All Rights Reserved.
          </div>
               <br/>
         <br/>
               <br/>
         <br/>
    </form>
</body>
</html>
