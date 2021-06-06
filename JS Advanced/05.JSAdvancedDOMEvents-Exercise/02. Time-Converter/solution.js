function attachEventsListeners() {
    let daysInputElement = document.getElementById('days');
    let hoursInputElement = document.getElementById('hours');
    let minutesInputElement = document.getElementById('minutes');
    let secondsInputElement = document.getElementById('seconds');

    let daysButtonElement = document.getElementById('daysBtn');
    let hoursButtonElement = document.getElementById('hoursBtn');
    let minutesButtonElement = document.getElementById('minutesBtn');
    let secondsButtonElement = document.getElementById('secondsBtn');

    daysButtonElement.addEventListener('click', (e) => {
        let days = Number(daysInputElement.value);
        let hours = calculate.hours(days);
        let minutes = calculate.minutes(days);
        let seconds = calculate.seconds(days);

        hoursInputElement.value = hours;
        minutesInputElement.value = minutes;
        secondsInputElement.value = seconds;
    });

    hoursButtonElement.addEventListener('click', (e) => {
        let hours = Number(hoursInputElement.value);
        let days = hours / 24;
        let minutes = calculate.minutes(days);
        let seconds = calculate.seconds(days);

        daysInputElement.value = days;
        minutesInputElement.value = minutes;
        secondsInputElement.value = seconds;
    });

    minutesButtonElement.addEventListener('click', (e) => {
        let minutes =  Number(minutesInputElement.value);
        let days = minutes / 1440;
        let hours = calculate.hours(days);
        let seconds = calculate.seconds(days);

        daysInputElement.value = days;
        hoursInputElement.value = hours;
        secondsInputElement.value = seconds;
    });

    secondsButtonElement.addEventListener('click', (e) => {
        let seconds = Number(secondsInputElement.value);
        let days = seconds / 86400;
        let hours = calculate.hours(days);
        let minutes = calculate.minutes(days);

        daysInputElement.value = days;
        hoursInputElement.value = hours;
        minutesInputElement.value = minutes;
    });

    calculate = {
        hours(days) {
            return days * 24;
        },
        minutes(days) {
            return days * 1440;
        },
        seconds(days) {
            return days * 86400;
        }
    };
}