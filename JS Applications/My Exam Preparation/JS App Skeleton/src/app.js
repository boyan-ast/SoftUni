import page from '../node_modules/page/page.mjs';

import { decorateContext } from './middlewares/renderer.js';

import navTemplatePage from './pages/navTemplatePage.js';
import templatePage from './pages/templatePage.js';

import authService from './services/authService.js';

// Redirect to the initial page
page('/', '/home');
page('/index.html', '/home');

page(decorateContext);

page('/template', navTemplatePage.getView, templatePage.getView);

// Example for logout
page('/logout', async (context) => { await authService.logout(); context.page.redirect('/home') });

page.start();