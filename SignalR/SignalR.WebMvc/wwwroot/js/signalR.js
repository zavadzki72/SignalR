"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:44334/streaming").build();

connection.on("Message", function (message) {
    var msg = message.replace(/&/g, "&").replace(/</g, "<").replace(/>/g, ">");
    var li = document.createElement("li");
    li.textContent = msg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    var li = document.createElement("li");
    li.textContent = "Connetado!";
    document.getElementById("messagesList").appendChild(li);
}).catch(function (err) {
    return console.error(err.toString());
});
