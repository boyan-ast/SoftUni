import page from '../node_modules/page/page.mjs';

import { decorateContext } from './middlewares/renderer.js';
import addPage from './pages/addPage.js';
import detailsPage from './pages/detailsPage.js';
import editPage from './pages/editPage.js';
import homePage from './pages/homePage.js';
import loginPage from './pages/loginPage.js';
import navPage from './pages/navPage.js';
import registerPage from './pages/registerPage.js';


import authService from './services/authService.js';

// Redirect to the initial page
page('/', '/home');
page('/index.html', '/home');
page(decorateContext);

page('/home', navPage.getView, homePage.getView);
page('/register', navPage.getView, registerPage.getView);
page('/login', navPage.getView, loginPage.getView);
page('/logout', async (context) => { await authService.logout(); context.page.redirect('/login') });
page('/add-movie', navPage.getView, addPage.getView);
page('/details/:id', navPage.getView, detailsPage.getView);
page('/edit/:id', navPage.getView, editPage.getView);


page.start();