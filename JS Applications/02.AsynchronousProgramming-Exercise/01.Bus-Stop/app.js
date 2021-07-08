function getInfo() {
    let inputIdElement = document.getElementById('stopId');
    let stopId = inputIdElement.value;
    let divStopNameElement = document.getElementById('stopName');
    let ulBusesElement = document.getElementById('buses');

    let busIdUrl = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;

    fetch(busIdUrl)
        .then(response => response.json())
        .then(busInfo => {
            Array.from(ulBusesElement.children).forEach(li => li.remove());

            divStopNameElement.textContent = busInfo.name;

            Object.keys(busInfo.buses).forEach(bus => {
                let liElement = document.createElement('li');
                liElement.textContent = `Bus ${bus} arrives in ${busInfo.buses[bus]} minutes`;
                ulBusesElement.appendChild(liElement);
            });
        })
        .catch(error => {
            Array.from(ulBusesElement.children).forEach(li => li.remove());
            divStopNameElement.textContent = 'Error';
        });
}