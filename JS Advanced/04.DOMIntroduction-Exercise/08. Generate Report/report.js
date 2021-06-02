function generateReport() {
    let checkboxElements = document.querySelectorAll('input[type="checkbox"]');
    let checkboxes = Array.from(checkboxElements);

    let dataElements = document.querySelectorAll('tbody tr');

    const selectedObjects = [];

    for (let row of dataElements) {

        let obj = {};

        for (let i = 0; i< row.children.length; i++) {
            if(checkboxes[i].checked) {
                obj[checkboxes[i].name] = row.children[i].textContent;
            }
        }

        selectedObjects.push(obj);
    }

    document.getElementById('output').textContent = JSON.stringify(selectedObjects);
}