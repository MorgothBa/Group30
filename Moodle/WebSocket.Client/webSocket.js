const socket = new WebSocket("wss://localhost:8888/ws");

socket.onopen = (event) => { };

socket.onmessage = (event) => {
    let webSocket = document.getElementById("webSocket");
    webSocket.innerHTML = `Szerver: ${event.data}`;
};

socket.onclose = (event) => {
    if (event.wasClean) {
        // WebSocket connection closed cleanly
    } else {
        // WebSocket connection died
    }
};

function sendMessage(message) {
    socket.send(message);
}