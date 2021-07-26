import page from '../node_modules/page/page.mjs';

import { decorateContext } from './middlewares/renderer.js';
import browsePage from './pages/browsePage.js';
import homePage from './pages/homePage.js';
import loginPage from './pages/loginPage.js';
import navPage from './pages/navPage.js';
import registerPage from './pages/registerPage.js';
import authService from './services/authService.js';

page('/', '/home');
page('index.html', '/home');

page('/home', decorateContext, navPage.getView, homePage.getView);
page('/register', decorateContext, navPage.getView, registerPage.getView);
page('/login', decorateContext, navPage.getView, loginPage.getView);
page('/logout', async (context) => {await authService.logout(); context.page.redirect('/home')});
page('/browse', decorateContext, navPage.getView, browsePage.getView);


page.start();