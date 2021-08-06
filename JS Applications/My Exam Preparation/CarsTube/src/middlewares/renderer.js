import { render } from '../../node_modules/lit-html/lit-html.js'

// Get the elements from index.html
let mainDivContainer = document.querySelector('#site-content');
let navigationContainer = document.querySelector('#container header');

function renderView(templateResult) {
    render(templateResult, mainDivContainer);
}

function renderNav(templateResult) {
    render(templateResult, navigationContainer);
}

export function decorateContext(context, next){
    context.renderView = renderView;
    context.renderNav = renderNav;

    next();
}