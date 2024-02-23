let ta;
let ws = null;
let bstart;
let bstop;
window.onload = () => {
    ta = document.getElementById('ta');
    bstart = document.getElementById('bstart');
    bstop = document.getElementById('bstop');
    bstart.disabled = false;
    bstop.disabled = true;
};

function writeMessage(idspan, text) {
    let span = document.getElementById(idspan);
    span.innerHTML = text;
}

function exe_start() {
    if (ws == null) {
        ws = new WebSocket('ws://localhost:5115/ws');
        ws.onopen = () => {
            ws.send('Connection');
        }
        ws.onclose = (s) => {
            console.log(`onclose: ${s}`);
        }
        ws.onmessage = (evt) => {
            ta.innerHTML += '\n' + evt.data;
        }
        bstart.disabled = true;
        bstop.disabled = false;
    }
}

function exe_stop() {
    ws.close(3001, 'stopapplication');
    ws = null;
    bstart.disabled = false;
    bstop.disabled = true;
}