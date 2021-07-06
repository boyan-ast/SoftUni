let submitButtonElement = document.getElementById('submit');
let locationInputElement = document.getElementById('location');
let divForecastElement = document.getElementById('forecast');
let divCurrentElement = document.getElementById('current');
let divUpcomingElement = document.getElementById('upcoming');

function attachEvents() {
    submitButtonElement.addEventListener('click', getWeather);    
}

function getWeather(e){
    let locationsUrl = 'http://localhost:3030/jsonstore/forecaster/locations';

    fetch(locationsUrl)
        .then(response => response.json())
        .then(locationsInfo => {
            let location = locationInputElement.value;
            locationInputElement.value = '';
            let cityInfo = locationsInfo.find(c => c.name == location);
            console.log(cityInfo);
            let cityCode = cityInfo.code;
            let cityName = cityInfo.name;
            console.log(cityCode, cityName);

            let cityForecastUrl = `http://localhost:3030/jsonstore/forecaster/today/${cityCode}`;
            let cityUpcomingForecastUrl = `http://localhost:3030/jsonstore/forecaster/upcoming/${cityCode}`;

            fetch(cityForecastUrl)
                .then(response => response.json())
                .then(forecastInfo => {
                    let city = forecastInfo.name;
                    let condition = forecastInfo.forecast.condition;
                    let high = forecastInfo.forecast.high;
                    let low = forecastInfo.forecast.low;

                    console.log(city, condition, high, low);
                });

            fetch(cityUpcomingForecastUrl)
                .then(response => response.json())
                .then(upcomingInfo => {
                    let city = upcomingInfo.name;
                    let forecastArray = upcomingInfo.forecast;
                });
        });
}

attachEvents();