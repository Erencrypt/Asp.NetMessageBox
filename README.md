# MessageBox library for Asp.Net

This is a useful and simple class for using toastr notifications in **asp.net**. Last year when i was create one of my web project, i couldn't find **asp.net** library like this and i create one **:D**.

## How to setup

**It's very simple.**

 1. download **MessageBox.dll** file.
https://github.com/ErenCanUtku/Asp.NetMessageBox/releases/tag/Version1.0
 2. extract **.dll** file from **.zip** archive.
 3.	open **"solution explorer"** and right click on **"referances"**.
 4.	click **"add referance"** button from top of the list.
 5.	click **"Browse"** button from bottom of the new opened window.
 6.	choose the **MessageBox.dll** file.
 7.	be sure checked little box on the left of dll file name and click **"ok"** button.
 
**It's done**, now you can use it but before, **don't forget** to check out our **"How to use"** guide **:D**. 

# How to use

Now, before use it you must add library:

    using MessageBox;
And create an object:

    Message MessageBox = new Message();
we have **"settings"** and **"clear"** method, for our created objects individually.
Firs we must create **"settings"** for **"literal"** who used in our **.aspx** files. 

    MessageBox.Settings(literal: Ltrmessage);

## Settings

In **"settings"** method, we must set literal, all other parameters has default value, if you want to change any value  you can set;

1. language (for now, only english and turkish available) (**default:** english)
I'm put language option for "headers default value".
2. timeout 
3. extended timeout
4. escape html
5. process bar
6. close button
 
if you chance only one of this you can use like this:

	    MessageBox.Settings(literal: Ltrmessage,processbar:false);

## Clear
**"Clear"** method is for cleaning **"literal"** so message instantly disappear.

    MessageBox.Clear();

## Show Message

 And finally we can create message, **"show"** method is very easy to use, for example:

    MessageBox.Show(Message.Type.info, "This is test message.", "Test");
in **"show"** method  we have 4 parameters

1.  type
2. message
3. head
4. position

**Type:** this parameter chance type of message, for example:

    MessageBox.Show(Message.Type.info, "This is info and its color blue.");
    MessageBox.Show(Message.Type.warning, "This is warning and its color yellow.");
    
**Message:** its simply your message :D.

**Head:** this parametter set header of messagebox, this parametter has default value, if you don't set, parameter automatically set header by **type** of message.

**Position:** this parameter sets the position where the messagebox will appear on the screen, this parametter has default value, if you don't set, parameter automatically set position to **"top right"** on screen.
**we have 6 position:**

 - top right
 - bottom right
 - top left
 - bottom left
 - top center
 - top full width
 - bottom center
 - bottom full width

# Example Project:
More detailed version of example project is available in source code and release page.
>**WebForm1.aspx.cs:**

    using System;
	using MessageBox;

	namespace test
	{
	    public partial class WebForm1 : System.Web.UI.Page
	    {
	        Message MessageBox = new Message();
	        protected void Page_Load(object sender, EventArgs e)
	        {
	            MessageBox.Settings(literal: Ltrmessage, timeout:10000, processbar:false,closebutton:false);
	            MessageBox.Show(Message.Type.info, "This is centered message.", "Test",Message.Position.topCenter);
	        }
	        protected void Button1_Click(object sender, EventArgs e)
	        {
	            MessageBox.Show(Message.Type.info, "This is test message.", "Test");
	        }
	    }
	}
>**WebForm1.aspx**

    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="test.WebForm1" %>
	<html lang="en">
	<head runat="server">
	    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	    <title>Test</title>
	</head>
	<body>
	    <form id="form1" runat="server">
	        <div>
	            <asp:Button ID="Button1" runat="server" Text="info" OnClick="Button1_Click" />
	        </div>
	    </form>

	    <asp:Literal ID="Ltrmessage" runat="server"></asp:Literal>
	</body>
	</html>
