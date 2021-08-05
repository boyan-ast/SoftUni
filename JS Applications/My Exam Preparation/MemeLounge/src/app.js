import page from '../node_modules/page/page.mjs';

import { decorateContext } from './middlewares/renderer.js';
import allMemesPage from './pages/allMemesPage.js';
import createPage from './pages/createPage.js';
import detailsPage from './pages/detailsPage.js';
import editPage from './pages/editPage.js';
import homePage from './pages/homePage.js';
import loginPage from './pages/loginPage.js';
import navPage from './pages/navPage.js';
import profilePage from './pages/profilePage.js';
import registerPage from './pages/registerPage.js';

import authService from './services/authService.js';

page('/', '/home');
page('/index.html', '/home');

page(decorateContext);
page(navPage.getView);

page('/home', homePage.getView);
page('/login', loginPage.getView);
page('/register', registerPage.getView);
page('/all-memes', allMemesPage.getView);
page('/create', createPage.getView);
page('/details/:id', detailsPage.getView);
page('/edit/:id', editPage.getView);
page('/my-profile', profilePage.getView);

page('/logout', async (context) => { await authService.logout(); context.page.redirect('/home') });

page.start();