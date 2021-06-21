function solve() {
    let nameInputElement = document.querySelector('.form-control input[name="lecture-name"]');
    let dateInputElement = document.querySelector('.form-control input[name="lecture-date"]');
    let moduleSelectElement = document.querySelector('.form-control select[name="lecture-module"]');
    let addButtonElement = document.querySelector('.form-control>button');

    addButtonElement.addEventListener('click', addLecture);

    function addLecture(e) {
        e.preventDefault();

        let lectureName = nameInputElement.value;
        let date = dateInputElement.value;
        let module = moduleSelectElement.value;

        if (lectureName.trim() !== '' && date.trim() !== '' && module !== 'Select module') {
            let divModuleElement = document.querySelector('div.modules');

            let liElement = document.createElement('li');
            liElement.classList.add('flex');
            let h4Element = document.createElement('h4');

            let dateRegex = /(?<year>\d{4})-(?<month>\d{2})-(?<day>\d{2})T(?<hours>\d{2}):(?<minutes>\d{2})/;
            let match = date.match(dateRegex);

            h4Element.textContent =
                `${lectureName} - ${match.groups.year}/${match.groups.month}/${match.groups.day} - ${match.groups.hours}:${match.groups.minutes}`;

            let delButtonElement = document.createElement('button');
            delButtonElement.classList.add('red');
            delButtonElement.textContent = 'Del';

            delButtonElement.addEventListener('click', deleteLecture);

            liElement.appendChild(h4Element);
            liElement.appendChild(delButtonElement);

            let h3DivElements = Array.from(document.querySelectorAll('.modules .module>h3'));

            if (h3DivElements.filter(el => el.textContent == `${module.toUpperCase()}-MODULE`).length == 0) {
                let divElement = document.createElement('div');
                divElement.classList.add('module');
                let h3moduleElement = document.createElement('h3');
                h3moduleElement.textContent = `${module.toUpperCase()}-MODULE`;
                let ulElement = document.createElement('ul');

                ulElement.appendChild(liElement);
                divElement.appendChild(h3moduleElement);
                divElement.appendChild(ulElement);

                divModuleElement.appendChild(divElement);
            } else {
                let moduleDivElement = Array.from(h3DivElements.filter(el => el.textContent == `${module.toUpperCase()}-MODULE`))[0].parentElement;
                let ulElement = moduleDivElement.querySelector('ul'); 
                ulElement.appendChild(liElement);

                Array.from(ulElement.children)
                    .sort((a, b) => a.textContent.split(' - ')[1].localeCompare(b.textContent.split(' - ')[1]))
                    .forEach(li => ulElement.appendChild(li));
            }

            function deleteLecture(e) {
                let liElement = e.target.parentElement;
                let ulElement = liElement.parentElement;
                liElement.remove();

                if (ulElement.children.length == 0) {
                    ulElement.parentElement.remove();
                }
            }
        }

        nameInputElement.value = '';
        dateInputElement.value = '';
        moduleSelectElement.value = 'Select module';
    }
};