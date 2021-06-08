function solve() {
    let checkButtonElement = document.querySelector('#exercise tfoot tr td button:nth-child(1)');
    let clearButtonElement = checkButtonElement.nextElementSibling;
    let tableElement = document.getElementsByTagName('table')[0];
    let endPElement = document.querySelector('#check p');

    checkButtonElement.addEventListener('click', checkSudomu);

    function checkSudomu(e) {
        let isSolved = true;
        let rowElements = document.querySelectorAll('tbody tr');
        let firstRowElement = rowElements[0];
        let firstRowInputElements = Array.from(firstRowElement.querySelectorAll('input'));
        let areElementsDifferentPerRow = checkForDifferentElements(firstRowInputElements);

        if (!areElementsDifferentPerRow) {
            isSolved = false;
        } else {
            let magicSum = calculateSum(firstRowInputElements);

            for (let index = 1; index < rowElements.length; index++) {
                let rowInputElements = Array.from(rowElements[index].querySelectorAll('input'));
                areElementsDifferentPerRow = checkForDifferentElements(rowInputElements);

                if (!areElementsDifferentPerRow) {
                    isSolved = false;
                    break;
                }

                let sum = calculateSum(rowInputElements);

                if (sum !== magicSum) {
                    isSolved = false;
                    break;
                }
            }

            if (isSolved) {
                for (let i = 1; i <= rowElements.length; i++) {
                    let colInputElements = Array.from(document.querySelectorAll(`tbody tr td:nth-child(${i}) input`));

                    let areElementsDifferentPerCol = checkForDifferentElements(colInputElements);

                    if (!areElementsDifferentPerCol) {
                        isSolved = false;
                        break;
                    }

                    let sum = calculateSum(colInputElements);

                    if (sum !== magicSum) {
                        isSolved = false;
                        break;
                    }
                }
            }
        }

        if (isSolved) {
            tableElement.style.border = '2px solid green';
            endPElement.textContent = 'You solve it! Congratulations!';
            endPElement.style.color = 'green';
        } else {
            tableElement.style.border = '2px solid red';
            endPElement.textContent = 'NOP! You are not done yet...';
            endPElement.style.color = 'red';
        }
    }

    clearButtonElement.addEventListener('click', (e) => {
        let allInputElements = Array.from(document.querySelectorAll('tbody input'));
        allInputElements.forEach(el => el.value = '');
        endPElement.style.color = null;
        endPElement.textContent = '';
        tableElement.style.border = 'none';
    });

    function calculateSum(inputElements) {
        return inputElements.reduce((a, el) => {
            a = a + Number(el.value);
            return a;
        }, 0);
    }

    function checkForDifferentElements(inputElements) {
        let uniqueNumbers = [];

        inputElements.forEach(el => {
            if (el.value) {
                let num = Number(el.value);
                console.log(num);
                if (!uniqueNumbers.includes(num)) {
                    uniqueNumbers.push(num);
                }
            }
        });

        if (uniqueNumbers.length == inputElements.length) {
            return true;
        } else {
            return false;
        }
    }
}

// function solve() {
//     let checkButtonElement = document.querySelector('#exercise tfoot tr td button:nth-child(1)');
//     let clearButtonElement = checkButtonElement.nextElementSibling;
//     let tableElement = document.getElementsByTagName('table')[0];
//     let endPElement = document.querySelector('#check p');

//     checkButtonElement.addEventListener('click', checkSudomu);

//     function checkSudomu(e) {
//         let isSolved = true;
//         let rowElements = document.querySelectorAll('tbody tr');

//         for (let index = 0; index < rowElements.length; index++) {
//             let rowInputElements = Array.from(rowElements[index].querySelectorAll('input'));
//             areElementsDifferentPerRow = checkForDifferentElements(rowInputElements);

//             if (!areElementsDifferentPerRow) {
//                 isSolved = false;
//                 break;
//             }
//         }

//         if (isSolved) {
//             for (let i = 1; i <= rowElements.length; i++) {
//                 let colInputElements = Array.from(document.querySelectorAll(`tbody tr td:nth-child(${i}) input`));                
//                 let areElementsDifferentPerCol = checkForDifferentElements(colInputElements);

//                 if (!areElementsDifferentPerCol) {
//                     isSolved = false;
//                     break;
//                 }
//             }
//         }

//         if (isSolved) {
//             tableElement.style.border = '2px solid green';
//             endPElement.textContent = 'You solve it! Congratulations!';
//             endPElement.style.color = 'green';
//         } else {
//             tableElement.style.border = '2px solid red';
//             endPElement.textContent = 'NOP! You are not done yet...';
//             endPElement.style.color = 'red';
//         }
//     }

//     clearButtonElement.addEventListener('click', (e) => {
//         let allInputElements = Array.from(document.querySelectorAll('tbody input'));
//         allInputElements.forEach(el => el.value = '');
//         endPElement.style.color = null;
//         endPElement.textContent = '';
//         tableElement.style.border = 'none';
//     });

//     function checkForDifferentElements(inputElements) {      
//         let allNumbers = inputElements.map(e => e.value);
//         console.log(allNumbers);
//         let uniqueElements = [...new Set(allNumbers)];
//         console.log(uniqueElements);

//         if (allNumbers.length == uniqueElements.length) {
//             return true;
//         } else {
//             return false;
//         }
//     }
// }


