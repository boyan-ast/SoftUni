function getArticleGenerator(articles) {
    let all = articles;

    return function () {
        let divElement = document.getElementById('content');
        
        if (all.length > 0) {
            let articleElement = document.createElement('article');
            articleElement.textContent = all.shift();
            divElement.appendChild(articleElement);
        }
    };
}


