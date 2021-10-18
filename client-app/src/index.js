import React from 'react';
import ReactDOM from 'react-dom';
import { Router } from 'react-router';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'font-awesome/css/font-awesome.min.css';
import {createBrowserHistory} from 'history';

import './index.css';
import App from './app/layout/App';

export const history = createBrowserHistory();

ReactDOM.render(
  <Router history={history}>
    <App />
    </Router>,
  document.getElementById('root')
);

