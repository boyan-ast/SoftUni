function toggle() {
    let buttonText = document.getElementsByClassName('button')[0].textContent;

    if (buttonText == 'More') {
        document.getElementById('extra').style.display = 'block';
        document.getElementsByClassName('button')[0].textContent = 'Less';
    } else if (buttonText == 'Less') {
        document.getElementById('extra').style.display = 'none';
        document.getElementsByClassName('button')[0].textContent = 'More';
    }   
}