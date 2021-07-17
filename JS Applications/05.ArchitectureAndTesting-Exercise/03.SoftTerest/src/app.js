import { setupHomepage } from './views/homepage.js';
import { setupCreate } from './views/create.js';
import { setupDashboard } from './views/dashboard.js';
import { setupDetails } from './views/details.js';
import { setupLogin } from './views/login.js';
import { setupRegister } from './views/register.js';
import { setupLogout } from './views/logout.js';

let mainElement = document.querySelector('main');
let navElement = document.querySelector('nav');

const views = {};

const links = {};

const navigation = {
    goTo,
    setUserNav
};

registerView('homepage', document.getElementById('home-page'), setupHomepage, 'homepageLink');
registerView('create', document.getElementById('create-page'), setupCreate, 'createLink');
registerView('dashboard', document.getElementById('dashboard-holder'), setupDashboard, 'dashboardLink');
registerView('details', document.getElementById('details-page'), setupDetails, 'detailsLink');
registerView('login', document.getElementById('login-page'), setupLogin, 'loginLink');
registerView('register', document.getElementById('register-page'), setupRegister, 'registerLink');
registerView('logout', document.getElementById('home-page'), setupLogout, 'logoutLink');

document.getElementById('views').remove();

setupNavigation();
goTo('homepage');

function registerView(name, section, setup, linkId) {
    const view = setup(section, navigation);
    views[name] = view;
    if (linkId) {        
        links[linkId] = name;
    }
}

async function goTo(name, ...params) {
    [...mainElement.children].forEach(el => el.remove());

    const view = views[name];
    const section = await view(...params);
    mainElement.appendChild(section);
}

function setupNavigation() {
    setUserNav();

    navElement.addEventListener('click', (e) => {
        e.preventDefault();
        let viewName = links[e.target.id];
        if (viewName) {
            goTo(viewName);
        }
    });
}

function setUserNav() {
    let token = sessionStorage.getItem('authToken');
    if (token !== null) {
        Array.from(navElement.querySelectorAll('.user-nav')).forEach(e => e.style.display = 'list-item');
        Array.from(navElement.querySelectorAll('.guest-nav')).forEach(e => e.style.display = 'none');

    } else {
        Array.from(navElement.querySelectorAll('.user-nav')).forEach(e => e.style.display = 'none');
        Array.from(navElement.querySelectorAll('.guest-nav')).forEach(e => e.style.display = 'list-item');
    }
}