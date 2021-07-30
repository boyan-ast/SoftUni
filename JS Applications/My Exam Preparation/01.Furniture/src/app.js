import page from '../node_modules/page/page.mjs';

import { decorateContext } from './middlewares/renderer.js';
import createPage from './pages/createPage.js';
import dashboardPage from './pages/dashboardPage.js';
import detailsPage from './pages/detailsPage.js';
import editPage from './pages/editPage.js';
import loginPage from './pages/loginPage.js';
import myFurniturePage from './pages/myFurniturePage.js';
import navPage from './pages/navPage.js';
import registerPage from './pages/registerPage.js';


import authService from './services/authService.js';

page('/', '/dashboard');
page('/index.html', '/dashboard');

page(decorateContext);

page('/dashboard', navPage.getView, dashboardPage.getView);
page('/register', navPage.getView, registerPage.getView);
page('/login', navPage.getView, loginPage.getView);
page('/create', navPage.getView, createPage.getView);
page('/details/:id', navPage.getView, detailsPage.getView);
page('/edit/:id', navPage.getView, editPage.getView);
page('/my-furniture', navPage.getView, myFurniturePage.getView);
page('/logout', async (context) => { await authService.logout(); context.page.redirect('/dashboard') });

page.start();