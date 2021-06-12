function solve() {
    let taskInputElement = document.getElementById('task');
    let descriptionInputElement = document.getElementById('description');
    let dateInputElement = document.getElementById('date');
    let addButtonElement = document.getElementById('add');

    addButtonElement.addEventListener('click', addElement);

    function addElement(e) {
        e.preventDefault();
        let task = taskInputElement.value;
        let description = descriptionInputElement.value;
        let date = dateInputElement.value;

        if (task.trim() !== '' && description.trim() !== '' && date.trim() !== '') {
            let openSectionDivElement = document.querySelector('.wrapper section:nth-child(2) div:nth-child(2)');

            let articleElement = document.createElement('article');
            let h3Element = document.createElement('h3');
            h3Element.textContent = task;
            let firstPElement = document.createElement('p');
            firstPElement.textContent = `Description: ${description}`;
            let secondPElement = document.createElement('p');
            secondPElement.textContent = `Due Date: ${date}`;

            let divElement = document.createElement('div');
            divElement.classList.add('flex');
            let startButtonElement = document.createElement('button');
            startButtonElement.textContent = 'Start';
            startButtonElement.classList.add('green');

            startButtonElement.addEventListener('click', startTask);

            let deleteButtonElement = document.createElement('button');
            deleteButtonElement.textContent = 'Delete';
            deleteButtonElement.classList.add('red');

            deleteButtonElement.addEventListener('click', deleteTask);

            divElement.appendChild(startButtonElement);
            divElement.appendChild(deleteButtonElement);

            articleElement.appendChild(h3Element);
            articleElement.appendChild(firstPElement);
            articleElement.appendChild(secondPElement);
            articleElement.appendChild(divElement);

            openSectionDivElement.appendChild(articleElement);

            taskInputElement.value = '';
            descriptionInputElement.value = '';
            dateInputElement.value = '';
        }
    }

    function startTask(e) {
        let inProgresSectionDivElement = document.querySelector('.wrapper section:nth-child(3) div:nth-child(2)');

        let articleElement = e.currentTarget.parentElement.parentElement;
        let firstButtonElement = e.currentTarget;
        firstButtonElement.classList.remove('green');
        firstButtonElement.classList.add('red');
        firstButtonElement.textContent = 'Delete';
        firstButtonElement.removeEventListener('click', startTask);
        firstButtonElement.addEventListener('click', deleteTask);

        let secondButtonElement = e.currentTarget.nextSibling;
        secondButtonElement.classList.remove('red');
        secondButtonElement.classList.add('orange');
        secondButtonElement.textContent = 'Finish';
        secondButtonElement.removeEventListener('click', deleteTask);
        secondButtonElement.addEventListener('click', finishTask);

        inProgresSectionDivElement.appendChild(articleElement);
    }

    function deleteTask(e) {
        e.currentTarget.parentElement.parentElement.remove();
    }

    function finishTask(e) {
        let completeSectionDivElement = document.querySelector('.wrapper section:nth-child(4) div:nth-child(2)');
        let articleElement = e.currentTarget.parentElement.parentElement;
        let divElement = e.currentTarget.parentElement;
        divElement.remove();
        completeSectionDivElement.appendChild(articleElement);
    }

}