function solve() {
    let spanInfoElement = document.querySelector('#info .info');
    let departButtonElement = document.getElementById('depart');
    let arriveButtonElement = document.getElementById('arrive');

    let nextStopId = 'depot';
    let currentStopId = 'depot';

    function depart() {
        let stopIdUrl = `http://localhost:3030/jsonstore/bus/schedule/${nextStopId}`;

        fetch(stopIdUrl)
            .then(body => body.json())
            .then(stopInfo => {
                spanInfoElement.textContent = `Next stop ${stopInfo.name}`;
                nextStopId = stopInfo.next;
                departButtonElement.disabled = true;
                arriveButtonElement.disabled = false;
            })
            .catch(error => {
                spanInfoElement.textContent = 'Error';
                departButtonElement.disabled = true;
                arriveButtonElement.disabled = true;
            });
    }
    function arrive() {
        let stopIdUrl = `http://localhost:3030/jsonstore/bus/schedule/${currentStopId}`;

        fetch(stopIdUrl)
            .then(body => body.json())
            .then(stopInfo => {
                spanInfoElement.textContent = `Arriving at ${stopInfo.name}`;
                currentStopId = nextStopId;
                departButtonElement.disabled = false;
                arriveButtonElement.disabled = true;
            })
            .catch(error => {
                spanInfoElement.textContent = 'Error';
                departButtonElement.disabled = true;
                arriveButtonElement.disabled = true;
            });
    }

    return {
        depart,
        arrive
    };
}

let result = solve();