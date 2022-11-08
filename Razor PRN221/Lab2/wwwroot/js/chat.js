"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
// document.getElementById("sendButton").disabled = true;
//event on click with class

document.getElementsByClassName("user").addEventListener("click", function () {
  var chat = `<div class="chat-header">
                  <div> <img width="60" height="60" src="{this.children[0].getAttribute('src')}"></div>    
        </div>`;
  var user = document.getElementById("user").value;
  var message = document.getElementById("message").value;

  connection.invoke("Send", user, message);
});

connection.on("ReceiveMessage", function (user, message) {
  //find div with class = chat-history
  var chatHistory = document.getElementsByClassName("chat-history")[0];
  //get current time in HH:mm AM format in vietnam Location
  var time = new Date().toLocaleTimeString("en-US", {
    hour: "numeric",
    minute: "numeric",
    hour12: true,
  });
  //get ul tag inside chat history
  var ul = chatHistory.getElementsByTagName("ul")[0];
  var chatmsg = `<li class="clearfix">
    <div class="message-data text-right">
        <span class="message-data-time"> ${time}</span>
        <img src="https://bootdey.com/img/Content/avatar/avatar7.png" alt="avatar">
    </div>
    <div class="message other-message float-right"> ${message} </div>
</li>`;
  //set inner HTML of ul append to chatmsg
  ul.innerHTML += chatmsg;
  //clear input in message
  document.getElementById("messageInput").value = "";
});

connection
  .start()
  .then(function () {
    document.getElementById("sendButton").disabled = false;
  })
  .catch(function (err) {
    return console.error(err.toString());
  });

//On click send button
document
  .getElementById("sendButton")
  .addEventListener("click", function (event) {
    // var user = document.getElementById("userInput").value;
    sendMessage(event);
  });

//event when user hit enter from keyboard button
document
  .getElementById("messageInput")
  .addEventListener("keypress", function (event) {
    if (event.code === "Enter") {
      sendMessage(event);
    }
  });

function sendMessage(event) {
  var user = document.getElementById("senderInput").value;
  var message = document.getElementById("messageInput").value;
  connection.invoke("SendPrivateMessage", "abc", message).catch(function (err) {
    return console.error(err.toString());
  });
  event.preventDefault();
}
