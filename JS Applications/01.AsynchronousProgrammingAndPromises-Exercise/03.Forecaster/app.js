let submitButtonElement = document.getElementById('submit');
let locationInputElement = document.getElementById('location');
let divForecastElement = document.getElementById('forecast');
let divCurrentElement = document.getElementById('current');
let divUpcomingElement = document.getElementById('upcoming');

let weatherSymbols = {
    Sunny: '☀',
    'Partly sunny': '⛅',
    Overcast: '☁',
    Rain: '☂',
}

function attachEvents() {
    submitButtonElement.addEventListener('click', getWeather);
}

function getWeather() {
    divForecastElement.style.display = 'block';
    let locationsUrl = 'http://localhost:3030/jsonstore/forecaster/locations';

    fetch(locationsUrl)
        .then(response => response.json())
        .then(locationsInfo => {
            let location = locationInputElement.value;
            locationInputElement.value = '';

            let cityInfo = locationsInfo.find(c => c.name == location);
            let cityCode = cityInfo.code;

            let cityForecastUrl = `http://localhost:3030/jsonstore/forecaster/today/${cityCode}`;
            let cityUpcomingForecastUrl = `http://localhost:3030/jsonstore/forecaster/upcoming/${cityCode}`;

            fetch(cityForecastUrl)
                .then(response => response.json())
                .then(forecastInfo => {
                    Array.from(divCurrentElement.children)
                        .slice(1)
                        .forEach(el => el.remove());

                    let city = forecastInfo.name;
                    let condition = forecastInfo.forecast.condition;
                    let high = forecastInfo.forecast.high;
                    let low = forecastInfo.forecast.low;

                    let divForecastsElement = document.createElement('div');
                    divForecastsElement.classList.add('forecasts');

                    let spanSymbolElement = document.createElement('span');
                    spanSymbolElement.classList.add('condition', 'symbol');
                    spanSymbolElement.textContent = weatherSymbols[condition];

                    let spanWeatherElement = document.createElement('span');
                    spanWeatherElement.classList.add('condition');

                    let spanCityElement = document.createElement('span');
                    spanCityElement.classList.add('forecast-data');
                    spanCityElement.textContent = city;

                    let spanTempElement = document.createElement('span');
                    spanTempElement.classList.add('forecast-data');
                    spanTempElement.textContent = `${low}°/${high}°`;

                    let spanConditionElement = document.createElement('span');
                    spanConditionElement.classList.add('forecast-data');
                    spanConditionElement.textContent = condition;

                    spanWeatherElement.appendChild(spanCityElement);
                    spanWeatherElement.appendChild(spanTempElement);
                    spanWeatherElement.appendChild(spanConditionElement);

                    divForecastsElement.appendChild(spanSymbolElement);
                    divForecastsElement.appendChild(spanWeatherElement);

                    divCurrentElement.appendChild(divForecastsElement);
                });

            fetch(cityUpcomingForecastUrl)
                .then(response => response.json())
                .then(upcomingInfo => {
                    Array.from(divUpcomingElement.children)
                        .slice(1)
                        .forEach(el => el.remove());

                    let forecastArray = upcomingInfo.forecast;

                    let divForecastInfo = document.createElement('div');
                    divForecastInfo.classList.add('forecast-info');

                    forecastArray.forEach(dayInfo => {
                        let condition = dayInfo.condition;
                        let high = dayInfo.high;
                        let low = dayInfo.low;

                        let spanUpcomingElement = document.createElement('span');
                        spanUpcomingElement.classList.add('upcoming');

                        let spanSymbolElement = document.createElement('span');
                        spanSymbolElement.classList.add('symbol');
                        spanSymbolElement.textContent = weatherSymbols[condition];

                        let spanTempElement = document.createElement('span');
                        spanTempElement.classList.add('forecast-data');
                        spanTempElement.textContent = `${low}°/${high}°`;

                        let spanConditionElement = document.createElement('span');
                        spanConditionElement.classList.add('forecast-data');
                        spanConditionElement.textContent = condition;

                        spanUpcomingElement.appendChild(spanSymbolElement);
                        spanUpcomingElement.appendChild(spanTempElement);
                        spanUpcomingElement.appendChild(spanConditionElement);

                        divForecastInfo.appendChild(spanUpcomingElement);
                    });

                    divUpcomingElement.appendChild(divForecastInfo);
                });
        })
        .catch(() => {
            Array.from(divCurrentElement.children)
                .slice(1)
                .forEach(el => el.remove());
            Array.from(divUpcomingElement.children)
                .slice(1)
                .forEach(el => el.remove());

            let divForecastsElement = document.createElement('div');
            divForecastsElement.classList.add('forecasts');
            divForecastsElement.textContent = 'Error';
            divCurrentElement.appendChild(divForecastsElement);
        });
}

attachEvents();