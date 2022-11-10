"use strict";
//document ready

$(document).ready(function () {
  debugger;
  var connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();
  // $('select').selectpicker();
  //Disable the send button until connection is established.
  connection.on("UserConnected", function (list) {
    debugger;
    var email = $(".main-user").html();
    //filter object in list to remove duplicate object
    var result = [];
    list = $.grep(list, function (item) {
      return item.email != email;
    });

    $.each(list, function (i, e) {
      var matchingItems = $.grep(result, function (item) {
        return item.userName === e.userName;
      });
      if (matchingItems.length === 0) {
        result.push(e);
      }
    });

    //init array
    var userArr = "";
    $(".btn-add").click(function () {
      debugger;
      //remove class btn-primary
      $(this).removeClass("btn-primary");
      //add class btn-success
      $(this).addClass("btn-success");
      var added = `<i class="fa-solid fa-check"></i> Added`;
      $(this).html(added);
      //get this id
      var id = $(this).attr("id");
      //append id to userArr
      userArr += id + ";";
    });

    $(".btn-create-group").click(function () {
      //if last character is ";" then remove it
      if (userArr.charAt(userArr.length - 1) == ";") {
        userArr = userArr.substring(0, userArr.length - 1);
      }
      connection
        .invoke("CreateRoom", $(".grp-name").val(), userArr)
        .catch(function (err) {
          return console.error(err.toString());
        });
    });

    //filter fiv .user in .user-list div where span.html() = connectionId
    var userList = $(".user-list");
    userList.html("");

    //loop through result
    $.each(result, function (i, e) {
      userList.append(` <div class="user d-flex align-items-center" >
      <img src="${e.avatar}" alt="avatar" width="60" class="avatar mr-2">
      <span class="d-none">${e.email}</span>
      <i class="fa-solid fa-circle  my-3 mb-4 px-2 px-2" style="color:green"></i>
      <h5 style="font-weight:700">
          ${e.userName}
      </h5>
  </div>`);

      //set onclick in .user jquery
      $(".user").click(function () {
        //aff class useractive
        $(this).addClass("useractive");
        //get src attribute of img  children elements
        var imgsrc = $(this).children("img").attr("src");
        var username = $(this).children("h5");
        var receiverEmail = $(this).children("span");
        var conectionId = $(this).children("p");
        //set inner html of .chat-frame  to chatSection
        $(".chat-frame").html(` <div class="chat-header">
  <div class="d-flex align-items-center">
      <img width="60" height="60" src="${imgsrc}">
      <strong class="receiver-name">${username.html()}</strong>
      <span class="receiver-email d-none">${receiverEmail.html()}</span>
      <span class="connection_id d-none">${conectionId.html()}</span>
  </div>
 </div>
 <hr style="width:90%" />
 <div class="chattingframe">
 <div class="chat-msg ">
  
 </div>
 </div>
 </div>
 <hr style="width:90%" />
 <div class="chat-input">
  <form class="send-msg"><input class="input-msg"  placeholder="type something nice" value=""><button type="submit" id="sendButton">🕊️</button></form>
 </div>`);
        document.getElementById("sendButton").disabled = true;
        //add event listener for messageInput enter event
        $(".input-msg").on("keypress", function (e) {
          if (e.code == "Enter") {
            //clear input value
            sendMessage(e);
            $(this).val("");
          }
        });

        document
          .getElementById("sendButton")
          .addEventListener("click", function (event) {
            // var user = document.getElementById("userInput").value;
            sendMessage(event);
          });

        $(".input-msg").on("change", function (e) {
          document.getElementById("sendButton").disabled = false;
        });
        $(".chat-msg").animate(
          { scrollTop: $(".chat-msg")[0].scrollHeight },
          0
        );
        connection
          .invoke("GetMessageHistory", receiverEmail.html())
          .catch(function (err) {
            return console.error(err.toString());
          });

        //  e.preventDefault();
      });
    });
  });

  connection.on(
    "GetHistory",
    function (listMsg, senderId, senderAvatar, receiverID, reeceiverAvatar) {
      debugger;
      //for each object in listMsg
      var sendMessage = "";
      $.each(listMsg, function (i, e) {
        if (e.fromUserId == senderId) {
          sendMessage = `<div class="d-flex justify-content-end my-msg">
    <img width="40" height="40" src="${senderAvatar}">
    <div class="msg ">
    <p class=" my-0 py-1">${e.content}</p>
    </div></div>`;
        } else {
          sendMessage = `<div class="d-flex justify-content-start">
          <img width="40" height="40" src="${reeceiverAvatar}">
          <div class="msg ">
          <p class="text-white my-0 py-1">${e.content}</p>
          </div></div>`;
        }
        $(".chat-msg").append(sendMessage);
      });
      $(".chat-msg").animate({ scrollTop: $(".chat-msg")[0].scrollHeight }, 0);
    }
  );

  connection.on("GetMessageGroupHistory", function (listMsg, reeceiverAvatar) {
    debugger;
    //for each object in listMsg
    var sendMessage = "";
    $.each(listMsg, function (i, e) {
      if (e.fromUserId == senderId) {
        sendMessage = `<div class="d-flex justify-content-end my-msg">
    <img width="40" height="40" src="${senderAvatar}">
    <div class="msg ">
    <p class=" my-0 py-1">${e.content}</p>
    </div></div>`;
      } else {
        sendMessage = `<div class="d-flex justify-content-start">
          <img width="40" height="40" src="${reeceiverAvatar}">
          <div class="msg ">
          <p class="text-white my-0 py-1">${e.content}</p>
          </div></div>`;
      }
      $(".chat-msg").append(sendMessage);
    });
    $(".chat-msg").animate({ scrollTop: $(".chat-msg")[0].scrollHeight }, 0);
  });

  connection.on("addChatRoom", function (roomname, roomid) {
    //remove space in roomname
    var name = roomname.replace(/\s/g, "");
    var myRoom = `<div class="group my-2 d-flex align-items-center" >
      <img src="https://avatars.dicebear.com/api/identicon/${name}}.svg" alt="avatar" width="60" class="avatar mr-2">
      <span class="d-none">${roomid}</span>
      <h5 style="font-weight:700">
          ${roomname}
      </h5>
  </div>`;
    $(".user-list").append(myRoom);
    //click on button
    $(".close-modal").click();

    $(".group").click(function (e) {
      $(this).addClass("useractive");
      //get src attribute of img  children elements
      var imgsrc = $(this).children("img").attr("src");
      var grpname = $(this).children("h5");
      var grpId = $(this).children("span");
      //set inner html of .chat-frame  to chatSection
      $(".chat-frame").html(` <div class="chat-header">
   <div class="d-flex align-items-center">
       <img width="60" height="60" src="${imgsrc}">
       <strong class="receiver-name">${grpname}</strong>
   </div>
  </div>
  <hr style="width:90%" />
  <div class="chattingframe">
  <div class="chat-msg ">
   
  </div>
  </div>
  </div>
  <hr style="width:90%" />
  <div class="chat-input">
   <form class="send-msg"><input class="input-msg"  placeholder="type something nice" value=""><button type="submit" id="sendButton">🕊️</button></form>
  </div>`);
      document.getElementById("sendButton").disabled = true;
      //add event listener for messageInput enter event
      $(".input-msg").on("keypress", function (e) {
        if (e.code == "Enter") {
          //clear input value
          sendMessage(e);
          $(this).val("");
        }
      });

      document
        .getElementById("sendButton")
        .addEventListener("click", function (event) {
          // var user = document.getElementById("userInput").value;
          sendMessage(event);
        });

      $(".input-msg").on("change", function (e) {
        document.getElementById("sendButton").disabled = false;
      });
      $(".chat-msg").animate({ scrollTop: $(".chat-msg")[0].scrollHeight }, 0);
      connection
        .invoke("GetMessageGroupHistory", grpId.html())
        .catch(function (err) {
          return console.error(err.toString());
        });
    });
  });

  connection.on("ReceiveMessage", function (message, avatar) {
    debugger;
    var sendMessage = `<div class="d-flex justify-content-start">
    <img width="40" height="40" src="${avatar}">
    <div class="msg ">
    <p class="text-white my-0 py-1">${message}</p>
    </div></div>`;
    //append html of .chat-msg to  sendMessage
    $(".chat-msg").append(sendMessage);
    $(".chat-msg").animate({ scrollTop: $(".chat-msg")[0].scrollHeight }, 0);
  });

  connection.on("RemoveUser", function (username) {
    var noti = `<div class="d-flex justify-content-center my-msg">
      <p class=" my-0 py-1">${username} has left conversation</p>
      </div>`;
    $(".chat-msg").append(noti);
    $(".chat-msg").animate({ scrollTop: $(".chat-msg")[0].scrollHeight }, 0);
  });

  connection.on("addUser", function (username) {
    var noti = `<div class="d-flex justify-content-center my-msg">
    <p class=" my-0 py-1">${username} has join to this conversation</p>
    </div>`;
    $(".chat-msg").append(noti);
    $(".chat-msg").animate({ scrollTop: $(".chat-msg")[0].scrollHeight }, 0);
  });

  connection.on("SendMsg", function (message, avatar) {
    debugger;
    var sendMessage = `<div class="d-flex justify-content-end my-msg">
    <img width="40" height="40" src="${avatar}">
    <div class="msg ">
    <p class=" my-0 py-1">${message}</p>
    </div></div>`;
    $(".chat-msg").append(sendMessage);
    $(".chat-msg").animate({ scrollTop: $(".chat-msg")[0].scrollHeight }, 0);
  });

  connection.on("onError", function (stringErr) {
    alert(stringErr);
  });

  connection
    .start()
    .then(function () {
      if ($("#sendButton").length > 0) {
        //enable it
        document.getElementById("sendButton").disabled = false;
      }
    })
    .catch(function (err) {
      return console.error(err.toString());
    });

  function sendMessage(e) {
    debugger;
    var receiver = $(".receiver-email").html();
    var message = $(".input-msg").val();
    var connection_id = $(".connection_id").html();
    connection
      .invoke("SendPrivateMessage", receiver, message)
      .catch(function (err) {
        return console.error(err.toString());
      });
    e.preventDefault();
  }
});
