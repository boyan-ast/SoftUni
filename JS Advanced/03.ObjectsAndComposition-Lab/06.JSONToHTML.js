function fromJSONToHTMLTable(input) {
    let data = JSON.parse(input);
    let result = ['<table>'];

    let keys = Object.keys(data[0]);

    let headings = '   <tr>';

    for (let key of keys) {
        headings += `<th>${escapeHtml(key)}</th>`;
    }
    headings += '</tr>';
    result.push(headings);

    for (let obj of data) {
        let row = '   <tr>';
        for (let value of Object.values(obj)) {
            row += `<td>${escapeHtml(value)}</td>`;
        }

        row += '</tr>';
        result.push(row);
    }
    result.push('</table>');

    return result.join('\n');

    function escapeHtml(value) {
        return value
            .toString()
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }
}

console.log(fromJSONToHTMLTable('[{"Name":"Stamat","Score":5.5},{"Name":"Rumen","Score":6}]'));