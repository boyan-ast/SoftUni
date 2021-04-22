function solve(number) {
    let daysArr = 
    ['January', 'February', 'March', 'April', 'May', 'June', 
    'July', 'August', 'September', 'October', 'November', 'December'];

    if (isValid(number)) {
        return daysArr[number-1];        
    } else {
        return "Error!";
    }    

    function isValid(number){
        return number >= 1 && number <= 12;
    }
}

console.log(solve(2));
console.log(solve(-1));
console.log(solve(12));