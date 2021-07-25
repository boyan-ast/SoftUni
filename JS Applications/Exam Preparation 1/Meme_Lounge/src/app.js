import page from '../node_modules/page/page.mjs';

import { decorateContext } from './middlewares/renderer.js';
import allMemesPage from './pages/allMemesPage.js';
import createPage from './pages/createPage.js';
import detailsPage from './pages/detailsPage.js';
import editPage from './pages/editPage.js';
import loginPage from './pages/loginPage.js';
import navPage from './pages/navPage.js';
import profilePage from './pages/profilePage.js';
import registerPage from './pages/registerPage.js';
import welcomePage from './pages/welcomePage.js';
import authService from './services/authService.js';

page('/', '/home');
page('/index.html', '/home');

page('/home', decorateContext, navPage.getView, welcomePage.getView);
page('/login', decorateContext, navPage.getView, loginPage.getView);
page('/register', decorateContext, navPage.getView, registerPage.getView);
page('/logout', async (context) => { await authService.logout(); context.page.redirect('/home') });
page('/create', decorateContext, navPage.getView, createPage.getView);
page('/allMemes', decorateContext, navPage.getView, allMemesPage.getView);
page('/details/:id', decorateContext, navPage.getView, detailsPage.getView);
page('/edit/:id', decorateContext, navPage.getView, editPage.getView);
page('/profile', decorateContext, navPage.getView, profilePage.getView);

page.start();