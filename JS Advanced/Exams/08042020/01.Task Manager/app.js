function solve() {
    let taskInputElement = document.getElementById('task');
    let descriptionInputElement = document.getElementById('description');
    let dateInputElement = document.getElementById('date');
    let addButtonElement = document.getElementById('add');

    addButtonElement.addEventListener('click', addTask);

    function addTask(e) {
        e.preventDefault();
        let task = taskInputElement.value;
        let description = descriptionInputElement.value;
        let date = dateInputElement.value;

        if (task.trim() !== '' && description.trim() !== '' && date.trim() !== '') {
            let openSectionDivElement = document.querySelector('.wrapper section:nth-child(2) div:nth-child(2)');

            let articleElement = document.createElement('article');
            let h3Element = document.createElement('h3');
            h3Element.textContent = task;
            let pDescriptionElement = document.createElement('p');
            pDescriptionElement.textContent = `Description: ${description}`;
            let pDateElement = document.createElement('p');
            pDateElement.textContent = `Due Date: ${date}`;
            let divButtonsElement = document.createElement('div');
            divButtonsElement.classList.add('flex');

            let firstButtonElement = document.createElement('button');
            firstButtonElement.classList.add('green');
            firstButtonElement.textContent = 'Start';

            firstButtonElement.addEventListener('click', startTask);

            let secondButtonElement = document.createElement('button');
            secondButtonElement.classList.add('red');
            secondButtonElement.textContent = 'Delete';

            secondButtonElement.addEventListener('click', deleteElement);

            divButtonsElement.appendChild(firstButtonElement);
            divButtonsElement.appendChild(secondButtonElement);

            articleElement.appendChild(h3Element);
            articleElement.appendChild(pDescriptionElement);
            articleElement.appendChild(pDateElement);
            articleElement.appendChild(divButtonsElement);

            openSectionDivElement.appendChild(articleElement);

            function startTask(e) {
                let inProgressSectionDivElement = document.querySelector('div#in-progress');

                firstButtonElement.removeEventListener('click', startTask);
                firstButtonElement.textContent = 'Delete';
                firstButtonElement.classList.remove('green');
                firstButtonElement.classList.add('red');

                firstButtonElement.addEventListener('click', deleteElement);

                secondButtonElement.removeEventListener('click', deleteElement)
                secondButtonElement.textContent = 'Finish';
                secondButtonElement.classList.remove('red');
                secondButtonElement.classList.add('orange');

                secondButtonElement.addEventListener('click', finishTask);

                inProgressSectionDivElement.appendChild(articleElement);
            }

            function deleteElement(e) {
                articleElement.remove();
            }

            function finishTask(e) {
                let completeSectionDivElement = document.querySelector('.wrapper section:nth-child(4) div:nth-child(2)');
                divButtonsElement.remove();
                completeSectionDivElement.appendChild(articleElement);
            }
        }

        taskInputElement.value = '';
        descriptionInputElement.value = '';
        dateInputElement.value = '';
    }
}