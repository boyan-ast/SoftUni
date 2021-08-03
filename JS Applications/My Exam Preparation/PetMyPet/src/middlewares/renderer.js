import { render } from '../../node_modules/lit-html/lit-html.js'

let mainDivContainer = document.getElementById('site-content');
let navigationContainer = document.querySelector('#site-header nav.navbar');

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