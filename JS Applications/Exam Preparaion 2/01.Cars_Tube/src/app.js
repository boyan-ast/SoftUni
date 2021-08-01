import page from '../node_modules/page/page.mjs';

import { decorateContext } from './middlewares/renderer.js';
import allListingsPage from './pages/allListingsPage.js';
import createPageTemplate from './pages/createPageTemplate.js';
import detailsPage from './pages/detailsPage.js';
import editPage from './pages/editPage.js';
import homePage from './pages/homePage.js';
import loginPage from './pages/loginPage.js';
import myListingsPage from './pages/myListingsPage.js';
import navPage from './pages/navPage.js';
import registerPage from './pages/registerPage.js';
import searchPage from './pages/searchPage.js';

import authService from './services/authService.js';

page('/', '/home');
page('/index.html', '/home');

page(decorateContext);

page('/home', navPage.getView, homePage.getView);
page('/register', navPage.getView, registerPage.getView);
page('/login', navPage.getView, loginPage.getView);
page('/all-listings', navPage.getView, allListingsPage.getView);
page('/create', navPage.getView, createPageTemplate.getView);
page('/details/:id', navPage.getView, detailsPage.getView);
page('/edit/:id', navPage.getView, editPage.getView);
page('/my-listings', navPage.getView, myListingsPage.getView);
page('/search', navPage.getView, searchPage.getView);
page('/logout', async (context) => { await authService.logout(); context.page.redirect('/home') });

page.start();