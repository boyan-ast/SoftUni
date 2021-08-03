import page from '../node_modules/page/page.mjs';

import { decorateContext } from './middlewares/renderer.js';
import categoryPage from './pages/categoryPage.js';
import createPage from './pages/createPage.js';
import dashboardPage from './pages/dashboardPage.js';
import detailsPage from './pages/detailsPage.js';
import editPage from './pages/editPage.js';
import homePage from './pages/homePage.js';
import loginPage from './pages/loginPage.js';
import myPetsPage from './pages/myPetsPage.js';
import navPage from './pages/navPage.js';
import registerPage from './pages/registerPage.js';

page('/', '/home');
page('/index.html', '/home');

page(decorateContext);
page(navPage.getView);

page('/home', homePage.getView);
page('/register', registerPage.getView);
page('/login', loginPage.getView);
page('/dashboard', dashboardPage.getView);
page('/create', createPage.getView);
page('/category/:category', categoryPage.getView);
page('/details/:id', detailsPage.getView);
page('/edit/:id', editPage.getView);
page('/my-pets', myPetsPage.getView);

page.start();