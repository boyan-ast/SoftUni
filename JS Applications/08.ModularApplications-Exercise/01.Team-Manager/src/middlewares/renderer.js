import { render } from '../../node_modules/lit-html/lit-html.js';

let navigationElement = document.getElementById('titlebar');

let mainElement = document.querySelector('main');

function renderView(templateResult) {
    render(templateResult, mainElement);
}

function renderNav(templateResult) {
    render(templateResult, navigationElement);
}

export function decorateContext(context, next) {
    context.renderView = renderView;
    context.renderNav = renderNav;

    next();
}