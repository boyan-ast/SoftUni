function specialNumbers(n) {

    for (let i = 1; i <= n; i++) {

        let isSpecial = false;

        if (sumDigits(i) == 5 || sumDigits(i) == 7 || sumDigits(i) == 11) {
            isSpecial = true;
        }

        let result = `${i} -> `;

        isSpecial ? result += 'True' : result += 'False';

        console.log(result);
    }

    function sumDigits(number) {
        let sum = 0;

        while (number > 0) {
            sum += number % 10;
            number = Math.floor(number / 10);
        }

        return sum;
    }
}

specialNumbers(15);