function lockedProfile() {
    let buttonElements = document.querySelectorAll('.profile button');

    for (let btn of buttonElements) {
        btn.addEventListener('click', showMore);
    }

    function showMore (e) {
        let buttonElement = e.currentTarget;
        let divElement = buttonElement.parentNode;
        let hiddenDivElement = divElement.querySelector('div > div');

        if (!divElement.getElementsByTagName('input')[0].checked && buttonElement.textContent == 'Show more') {
            hiddenDivElement.style.display = 'inline-block';
            buttonElement.textContent = 'Hide it';
        } else if (!divElement.getElementsByTagName('input')[0].checked && buttonElement.textContent == 'Hide it') {            
            hiddenDivElement.style.display = 'none';
            buttonElement.textContent = 'Show more';
        }
    }
}