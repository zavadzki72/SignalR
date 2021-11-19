"use strict";

const connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:44358/grouphub").build();
connection.start().catch(err => alert(err.toString()));

$(document).ready(function () {
    $("#btnPrivateGroup").click(function (e) {
        connection.invoke('JoinGroup', "PrivateGroup");
        e.preventDefault();
    });

    $("#btnSend").click(function (e) {
        let message = $('#messagebox').val();
        let sender = $('#senderUId').text();
        $('#messagebox').val('');

        connection.invoke('SendMessageToGroup', 'PrivateGroup', sender, message);

        e.preventDefault();
    });
});

connection.on("SendMessageGroup", function (user, message) {
    appendLine(user, message);
});

function appendLine(uid, message) {
    let nameElement = document.createElement('strong');
    nameElement.innerText = `${uid}:`;
    let msgElement = document.createElement('em');
    msgElement.innerText = ` ${message}`;
    let li = document.createElement('li');
    li.appendChild(nameElement);
    li.appendChild(msgElement);
    $('#messageList').append(li);
};