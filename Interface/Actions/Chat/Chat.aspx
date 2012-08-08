<%@ Page Title="Title" Language="C#" inherits="Interface.Actions.Chat.Chat"  %>
<%@ Import Namespace="Core.Hubs" %>

<html>
<head>
<script type="text/javascript" src="/Scripts/jquery-1.6.4.min.js"></script>
<script type="text/javascript" src="/Scripts/jquery.signalr-0.5.2.min.js"></script>
<script type="text/javascript" src="signalr/hubs"></script>

</head>
<body>
    <h3>Tasks</h3>
    <ul id="taskList"></ul>
    
  
    
    <%= this.FormFor<ChatMessage>() %>
        <%= this.InputFor(x => x.subject) %>
        <input type="submit"/>
    <%= this.EndForm() %>
</body>
</html>