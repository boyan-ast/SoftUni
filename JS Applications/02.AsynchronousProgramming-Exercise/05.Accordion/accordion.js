window.addEventListener('load', solution);

function solution() {
    let listUrl = 'http://localhost:3030/jsonstore/advanced/articles/list';

    fetch(listUrl)
        .then(response => response.json())
        .then(articlesInfo => {
            let mainSectionElement = document.getElementById('main');

            articlesInfo.forEach(articleInfo => {
                let accordionDivElement = document.createElement('div');
                accordionDivElement.classList.add('accordion');

                let headDivElement = document.createElement('div');
                headDivElement.classList.add('head');

                let spanElement = document.createElement('span');
                spanElement.textContent = articleInfo.title;

                let buttonElement = document.createElement('button');
                buttonElement.classList.add('button');
                buttonElement.id = articleInfo._id;
                buttonElement.textContent = 'MORE';

                buttonElement.addEventListener('click', showMore);

                headDivElement.appendChild(spanElement);
                headDivElement.appendChild(buttonElement);

                accordionDivElement.appendChild(headDivElement);

                mainSectionElement.appendChild(accordionDivElement);
            })
        })
        .catch(error => {
            let mainSectionElement = document.getElementById('main');
            mainSectionElement.textContent = 'Error';
        });
}

function showMore(e) {
    let buttonElement = e.currentTarget;
    let accordionDivElement = buttonElement.parentElement.parentElement;

    if (buttonElement.textContent == 'MORE') {
        let buttonId = buttonElement.id;

        let articleDetailsUrl = `http://localhost:3030/jsonstore/advanced/articles/details/${buttonId}`;

        fetch(articleDetailsUrl)
            .then(response => response.json())
            .then(articleDetails => {
                let extraDivElement = document.createElement('div');
                extraDivElement.classList.add('extra');
                extraDivElement.style.display = 'block';

                let pElement = document.createElement('p');
                pElement.textContent = `${articleDetails.content}`;

                extraDivElement.appendChild(pElement);

                accordionDivElement.appendChild(extraDivElement);
                buttonElement.textContent = 'LESS';
            });
    } else {
        let extraDivElement = accordionDivElement.querySelector('.extra');
        extraDivElement.remove();
        buttonElement.textContent = 'MORE';
    }
}