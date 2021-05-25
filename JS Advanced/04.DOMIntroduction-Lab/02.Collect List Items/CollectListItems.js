function extractText() {
    const liCollection = document.querySelectorAll('ul#items li');
    
    const liContent = Array.from(liCollection);

    let result = [];

    liContent.forEach(e => result.push(e.textContent));

    document.getElementById('result').value = result.join('\n');
}