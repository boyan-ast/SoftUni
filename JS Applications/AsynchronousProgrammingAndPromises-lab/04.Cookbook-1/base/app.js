window.addEventListener('load', () => {
    document.getElementsByTagName('main')[0].innerHTML = '';

    fetch('http://localhost:3030/jsonstore/cookbook/recipes')
        .then(response => response.json())
        .then(data => {
            let mainElement = document.getElementsByTagName('main')[0];
            Object.values(data).forEach(p => {
                let articleElement = document.createElement('article');
                articleElement.classList.add('preview');
                let divTitleElement = document.createElement('div');
                divTitleElement.classList.add('title');
                let h2TitleElement = document.createElement('h2');
                h2TitleElement.textContent = `${p.name}`;
                divTitleElement.appendChild(h2TitleElement);

                let divImageElement = document.createElement('div');
                divImageElement.classList.add('small');
                let imgElement = document.createElement('img');
                imgElement.setAttribute('src', `${p.img}`);
                divImageElement.appendChild(imgElement);

                articleElement.appendChild(divTitleElement);
                articleElement.appendChild(divImageElement);

                mainElement.appendChild(articleElement);

                let secondArticleElement = document.createElement('article');
                secondArticleElement.style.display = 'none';
                let secondH2Element = document.createElement('h2');
                secondH2Element.textContent = `${p.name}`;
                secondArticleElement.appendChild(secondH2Element);

                let divBandElement = document.createElement('div');
                divBandElement.classList.add('band');
                let divThumbElement = document.createElement('thumb');
                divThumbElement.classList.add('thumb');
                let secondImgElement = document.createElement('img');
                secondImgElement.setAttribute('src', `${p.img}`);
                divThumbElement.appendChild(secondImgElement);

                let divIngredientsElement = document.createElement('div');
                divIngredientsElement.classList.add('ingredients');
                let h3Element = document.createElement('h3');
                h3Element.textContent = 'Ingredients:';
                divIngredientsElement.appendChild(h3Element);
                let ulElement = document.createElement('ul');

                let recipeUrl = `http://localhost:3030/jsonstore/cookbook/details/${p._id}`;

                fetch(recipeUrl)
                    .then(res => res.json())
                    .then(result => {
                        result.ingredients.forEach(i => {
                            let liElement = document.createElement('li');
                            liElement.textContent = i;
                            ulElement.appendChild(liElement);
                        });
                    });

                divIngredientsElement.appendChild(ulElement);

                divBandElement.appendChild(divThumbElement);
                divBandElement.appendChild(divIngredientsElement);

                secondArticleElement.appendChild(divBandElement);

                mainElement.appendChild(secondArticleElement);

                articleElement.addEventListener('click', (e) => {
                    if (e.currentTarget.style.display == 'none') {
                        e.currentTarget.style.display = 'block';
                        secondArticleElement.style.display = 'none';
                    } else {
                        e.currentTarget.style.display = 'none';
                        secondArticleElement.style.display = 'block';
                    }                    
                });

                secondH2Element.addEventListener('click', (e) => {
                    if (e.currentTarget.parentElement.style.display == 'none') {
                        e.currentTarget.parentElement.style.display = 'block';
                        articleElement.style.display = 'none';
                    } else {
                        e.currentTarget.parentElement.style.display = 'none';
                        articleElement.style.display = 'block';
                    }  
                });
            })
        })
});
