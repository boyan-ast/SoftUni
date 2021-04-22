function solve(day, age) {

    if (isInvalidAge(age)) {
        console.log('Error!');
    } else {
        if (age >= 0 && age <= 18) {
            if (day == 'Weekday') {
                console.log('12$');
            } else if (day == 'Weekend') {
                console.log('15$');
            } else if (day == 'Holiday') {
                console.log('5$');
            }
        } else if (age <= 64) {
            if (day == 'Weekday') {
                console.log('18$');
            } else if (day == 'Weekend') {
                console.log('20$');
            } else if (day == 'Holiday') {
                console.log('12$');
            }
        } else if (age <= 122) {
            if (day == 'Weekday') {
                console.log('12$');
            } else if (day == 'Weekend') {
                console.log('15$');
            } else if (day == 'Holiday') {
                console.log('10$');
            }
        }
    }

    function isInvalidAge(age) {
        return age < 0 || age > 122;
    }
}

solve('Weekday', 42);
solve('Holiday', -12);
solve('Holiday', 15);