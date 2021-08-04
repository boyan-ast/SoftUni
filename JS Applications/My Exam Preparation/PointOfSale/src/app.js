import page from '../node_modules/page/page.mjs';

import { decorateContext } from './middlewares/renderer.js';
import createPage from './pages/createPage.js';
import editPage from './pages/editPage.js';
import loginPage from './pages/loginPage.js';
import navPage from './pages/navPage.js';

import authService from './services/authService.js';

page('/', '/overview');
page('/index.html', '/overview');

page(decorateContext);
page(navPage.getView);

page('/login', loginPage.getView);
page('/overview', createPage.getView);
page('/edit/:id', editPage.getView);
page('/logout', async (context) => { await authService.logout(); context.page.redirect('/login') });

page.start();