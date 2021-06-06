function focused() {
    let inputElements = document.querySelectorAll('div > input:nth-child(2)');

    for (let el of inputElements) {
        el.addEventListener('focus', (e) => {
            e.currentTarget.parentNode.classList.add('focused');
        });
    }

    for (let el of inputElements) {
        el.addEventListener('blur', (e) => {
            e.currentTarget.parentNode.classList.remove('focused');
        });
    }
}