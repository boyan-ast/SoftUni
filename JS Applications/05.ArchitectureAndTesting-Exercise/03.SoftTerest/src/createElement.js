export function createElement(tag, attributes, ...params) {
    let el = document.createElement(tag);
    let firstParam = params[0];

    if (params.length === 1 && typeof (firstParam) !== 'object') {
        if (tag == 'input' || tag == 'textarea') {
            el.value = firstParam;
        } else {
            el.textContent = firstParam;
        }
    } else {
        el.append(...params);
    }

    if (attributes !== undefined) {
        Object.keys(attributes).forEach(key => {
            el.setAttribute(key, attributes[key]);
        });
    }

    return el;
}