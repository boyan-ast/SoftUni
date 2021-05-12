function dayOfWeek(day) {
    let week = ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'];

    if (week.includes(day)) {
        console.log(week.indexOf(day) + 1);
    } else {
        console.log('error');
    }
}

dayOfWeek('Monday');
dayOfWeek('Friday');
dayOfWeek('invalid day');