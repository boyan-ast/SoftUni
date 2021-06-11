function calculator() {
    let firstInputElement;
    let secondInputElement;
    let resultElement;

    let obj = {
        init: function (selectorOne, selectorTwo, resultSelector) {
            firstInputElement = document.querySelector(selectorOne);
            secondInputElement = document.querySelector(selectorTwo);
            resultElement = document.querySelector(resultSelector);
        },
        add: function () {
            resultElement.value = Number(firstInputElement.value) + Number(secondInputElement.value);
        },
        subtract: function () {
            resultElement.value = Number(firstInputElement.value) - Number(secondInputElement.value);
        }
    };

    return obj;
}


const calculate = calculator (); 
calculate.init ('#num1', '#num2', '#result'); 




