import page from '../node_modules/page/page.mjs';

import { decorateContext } from './middlewares/renderer.js';
import allSongsPage from './pages/allSongsPage.js';
import createPage from './pages/createPage.js';
import homePage from './pages/homePage.js';
import loginPage from './pages/loginPage.js';
import mySongsPage from './pages/mySongsPage.js';
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
page('/create', navPage.getView, createPage.getView);
page('/all-songs', navPage.getView, allSongsPage.getView);
page('/my-songs', navPage.getView, mySongsPage.getView);

// Example for logout
page('/logout', async (context) => { await authService.logout(); context.page.redirect('/home') });

page.start();