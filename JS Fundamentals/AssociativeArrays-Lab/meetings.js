function meetings(input) {
    let calendar = {};

    for (let meetingInfo of input) {
        let [day, name] = meetingInfo.split(' ');

        if (calendar.hasOwnProperty(day)) {
            console.log(`Conflict on ${day}!`);
        } else {
            console.log(`Scheduled for ${day}`);
            calendar[day] = name;
        }
    }

    for (let day in calendar) {
        console.log(`${day} -> ${calendar[day]}`);
    }
}

meetings(['Monday Peter',
    'Wednesday Bill',
    'Monday Tim',
    'Friday Tim']);