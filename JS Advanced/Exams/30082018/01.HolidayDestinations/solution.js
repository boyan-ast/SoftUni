function addDestination() {
    let cityInputElement = document.querySelector('div#input .inputData:nth-child(2)');
    let countryInputElement = document.querySelector('div#input .inputData:nth-child(4)');
    let seasonSelectElement = document.getElementById('seasons');

    let city = cityInputElement.value;
    let country = countryInputElement.value;
    let season = seasonSelectElement.value;
    
    if (city.trim() !== '' && country.trim() !== '') {
        let tbodyElement = document.getElementById('destinationsList');

        let trElement = document.createElement('tr');
        let tdCityElement = document.createElement('td');
        tdCityElement.textContent = `${city}, ${country}`;
        let tdSeasonElement = document.createElement('td');
        tdSeasonElement.textContent = season.charAt(0).toUpperCase() + season.slice(1);

        trElement.appendChild(tdCityElement);
        trElement.appendChild(tdSeasonElement);
        tbodyElement.appendChild(trElement);

        let summeryElement = document.getElementById(season);
        summeryElement.value++;  
    }    

    cityInputElement.value = '';
    countryInputElement.value = '';
    seasonSelectElement.value = 'summer';
}