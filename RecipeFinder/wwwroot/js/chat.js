var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (profilepicture, user, message) {
    var li = document.createElement("li");
    var profilePicture = document.createElement("img");
    var div = document.createElement('div');
    div.style.display = 'flex';
    div.style.alignItems = 'flex-start';
    div.style.gap = '15px';
    div.style.marginTop = '15px';
    profilePicture.src = profilepicture;
    profilePicture.style.width = "35px";
    profilePicture.style.height = "35px";
    profilePicture.style.borderRadius = "50%";
    div.append(profilePicture);
    var pUser = document.createElement("p");
    var pMessage = document.createElement("p");
    pUser.style.marginBottom = '0';
    pUser.style.flex = '1 0 40%';
    pMessage.style.marginBottom = '0';
    pUser.textContent = `${user} ➔`;
    pMessage.style.overflowWrap = 'break-word';
    pMessage.textContent = message;
    pMessage.style.textAlign = 'left';
    pMessage.style.width='500px';
    div.append(pUser);
    div.append(pMessage);
    li.append(div);
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString())
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    event.preventDefault();
    var profilepicture = document.getElementById("profilepicture").value;
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage",profilepicture, user, message).catch(function (err) {
        return console.error(err.toString());
    });
});