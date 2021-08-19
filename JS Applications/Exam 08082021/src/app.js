import page from '../node_modules/page/page.mjs';

import { decorateContext } from './middlewares/renderer.js';

import createPage from './pages/createPage.js';
import dashboardPage from './pages/dashboardPage.js';
import detailsPage from './pages/detailsPage.js';
import editPage from './pages/editPage.js';
import loginPage from './pages/loginPage.js';
import myBooksPage from './pages/myBooksPage.js';
import navPage from './pages/navPage.js';
import registerPage from './pages/registerPage.js';

import authService from './services/authService.js';

page('/', '/dashboard');
page('/index.html', '/dashboard');

page(decorateContext);
page(navPage.getView);

page('/login', loginPage.getView);
page('/register', registerPage.getView);
page('/create', createPage.getView);
page('/dashboard', dashboardPage.getView);
page('/details/:id', detailsPage.getView);
page('/edit/:id', editPage.getView);
page('/my-books', myBooksPage.getView);

page('/logout', async (context) => { await authService.logout(); context.page.redirect('/dashboard') });

page.start();