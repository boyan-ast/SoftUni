function dayOfWeek(number) {

    let days = ['Monday', 'Tuesday', 'Wednesday', 'Thursday',
        'Friday', 'Saturday', 'Sunday'];

    if (isValid(number)) {
        console.log(days[number - 1]);
    } else {
        console.log('Invalid day!');
    }

    function isValid(number) {
        if (number < 1 || number > 7) {
            return false;
        }

        return true;
    }
}

dayOfWeek(1);
dayOfWeek(8);