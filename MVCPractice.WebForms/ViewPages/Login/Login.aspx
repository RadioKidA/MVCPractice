<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MVCPractice.WebForms.ViewPages.Login.Login" MasterPageFile="~/Site.Master"%>

<script runat="server">

</script>
<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <input type="text" id="username" value="" /><br />
    <input type="password" id="password" value="" /><br />
    
    <input type="button" id="loginSubmit" value="提交" />
    <input type="reset" value="重置" />
    <div id="loginResult"></div>

    <script>
        $(document).ready(function () {
            $("#loginSubmit").on("click",(function (e)
            {
                $.post("/Handlers/LoginHandler.ashx",
                    {
                        username:$("#username").val(),
                        password: $("#password").val(),
                        action:"CheckLogin"
                    }, 
                    function (data,status)
                    {
                        alert(data + status);
                        $("#loginResult").html(htmlObj.responseText);
                    }
                )
            }))
        })
    </script>
<style>
    input{
        margin-top:5px
    }
</style>
</asp:Content>


