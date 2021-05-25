function calc() {
    let firstNum = Number(document.querySelector('#num1').value);
    let secondNum = Number(document.querySelector('#num2').value);

    let result = firstNum + secondNum;

    document.querySelector('#sum').value = result;
}