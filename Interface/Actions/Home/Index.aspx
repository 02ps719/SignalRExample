<%@ Page Title="Title" Language="C#" inherits="Interface.Actions.Home.Index"  %>

<html>
<head>
<script type="text/javascript" src="/Scripts/jquery-1.6.4.min.js"></script>
<script type="text/javascript" src="/Scripts/jquery.signalr-0.5.2.min.js"></script>
<script type="text/javascript" src="signalr/hubs"></script>

</head>
<body>
    <h3>Tasks</h3>
    <ul id="taskList"></ul>
    <form id="taskForm">
        <input type="text" id="subject"/>
        <input type="submit" value="Add"/>
    </form>
    
    <script type="text/javascript">
        $(document).ready(function () {

            $.connection.hub.start()
                .done(function () { alert("Now connected!"); })
                .fail(function () { alert("Could not Connect!"); });

            var chat = $.connection.chat;
            console.log(chat);

            $("#taskForm").submit(function (e) {
                e.preventDefault();

                chat.addTask($("#subject").val())
                    .done(function () {
                        $("#subject").val("").focus();
                    });
            });

            chat.taskAdded = function (subject) {
                $("#taskList").append("<li>" + subject + "</li>");
            };

        });
    </script>

</body>
</html>