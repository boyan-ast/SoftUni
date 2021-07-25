import page from '../node_modules/page/page.mjs';

import { decorateContext } from './middlewares/renderer.js';
import dashboardPage from './pages/dashboardPage.js';
import registerPage from './pages/registerPage.js'
import navPage from './pages/navPage.js';
import loginPage from './pages/loginPage.js';
import authService from './services/authService.js';
import detailsPage from './pages/detailsPage.js';
import createPage from './pages/createPage.js';
import editPage from './pages/editPage.js';
import myFurniturePage from './pages/myFurniturePage.js';

page('/', '/dashboard');
page('/index.html', '/dashboard');

page('/dashboard', decorateContext, navPage.getView, dashboardPage.getView);
page('/register', decorateContext, navPage.getView, registerPage.getView);
page('/login', decorateContext, navPage.getView, loginPage.getView);
page('/logout', async (context) => { await authService.logout(); context.page.redirect('/login') });
page('/details/:id', decorateContext, navPage.getView, detailsPage.getView);
page('/create', decorateContext, navPage.getView, createPage.getView);
page('/edit/:id', decorateContext, navPage.getView, editPage.getView);
page('/my-furniture', decorateContext, navPage.getView, myFurniturePage.getView);

page.start();