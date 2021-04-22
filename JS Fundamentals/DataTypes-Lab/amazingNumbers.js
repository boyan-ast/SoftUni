function amazingNumbers(number) {
    
    let initialNumber = number;
    let sum = 0;

    while(number > 0){
        sum += number % 10;
        number = Math.floor(number / 10);
    }

    let isAmazing = false;

    if (sum.toString().includes('9')) {
        isAmazing = true;
    }

    let result = initialNumber + ' Amazing? ';

    isAmazing ? result += 'True': result += 'False';

    console.log(result);
}

amazingNumbers(999);