import page from '../node_modules/page/page.mjs';

import { decorateContext } from './middlewares/renderer.js';
import navPage from './pages/navPage.js';

import templatePage from './pages/templatePage.js';

import authService from './services/authService.js';

// Redirect to the initial page
page('/', '/home');
page('/index.html', '/home');

page(decorateContext);
page(navPage.getView);

page('/template', templatePage.getView);

// Example for logout
page('/logout', async (context) => { await authService.logout(); context.page.redirect('/home') });

page.start();