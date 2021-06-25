function solve() {
    let lectureInputElement = document.querySelector('.form-control input[name="lecture-name"]');
    let dateInputElement = document.querySelector('.form-control input[name="lecture-date"]');
    let moduleInputElement = document.querySelector('.form-control select[name="lecture-module"]');
    let addBtnElement = document.querySelector('.form-control > button');

    addBtnElement.addEventListener('click', addLecture);


    function addLecture(e) {
        e.preventDefault();
        let lecture = lectureInputElement.value;
        let dateInfo = dateInputElement.value;
        let module = moduleInputElement.value;

        if (lecture.trim() != '' && dateInfo.trim() != '' && module != 'Select module') {
            let divModulesElement = document.querySelector('.user-view.section-view div.modules');

            // Create the li element
            let liElement = document.createElement('li');
            liElement.classList.add('flex');
            let h4Element = document.createElement('h4');
            let [date, time] = dateInfo.split('T');
            date = date.replace(/\-/g, '/');
            h4Element.textContent = `${lecture} - ${date} - ${time}`;
            let delButtonElement = document.createElement('button');
            delButtonElement.classList.add('red');
            delButtonElement.textContent = 'Del';

            delButtonElement.addEventListener('click', (e) => {
                let liRemoveElement = e.currentTarget.parentElement;
                let ulElement = liRemoveElement.parentElement;

                liRemoveElement.remove();

                if (Array.from(ulElement.children).length == 0) {
                    ulElement.parentElement.remove();
                }
            });

            liElement.appendChild(h4Element);
            liElement.appendChild(delButtonElement);

            let allModuleDivElements = Array.from(divModulesElement.querySelectorAll('div.module'));

            let existingModuleDivElement = allModuleDivElements.find(el => Array.from(el.children)[0].textContent.startsWith(module.toUpperCase()));

            if (existingModuleDivElement !== undefined) {
                let existingUlElement = existingModuleDivElement.querySelector('ul');
                existingUlElement.appendChild(liElement);

                Array.from(existingUlElement.children)
                    .sort((a, b) =>
                        Array.from(a.children)[0].textContent.split(' - ')[1].localeCompare(Array.from(b.children)[0].textContent.split(' - ')[1]))
                    .forEach(li => existingUlElement.appendChild(li));
            } else {
                let divModuleElement = document.createElement('div');
                divModuleElement.classList.add('module');
                let h3Element = document.createElement('h3');
                h3Element.textContent = `${module.toUpperCase()}-MODULE`;

                let ulElement = document.createElement('ul');

                ulElement.appendChild(liElement);

                divModuleElement.appendChild(h3Element);
                divModuleElement.appendChild(ulElement);
                divModuleElement.appendChild(ulElement);

                divModulesElement.appendChild(divModuleElement);
            }
        }

        lectureInputElement.value = '';
        dateInputElement.value = '';
        moduleInputElement.value = 'Select module';
    }
}