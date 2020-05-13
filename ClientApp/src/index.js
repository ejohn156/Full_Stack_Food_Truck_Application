import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import CombinedStore from './Store/index'
import {createStore} from 'redux'
import { Provider } from 'react-redux'

const Store = createStore(CombinedStore)

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
    <Provider store={Store}>
    <App />
    </Provider>
  </BrowserRouter>,
  rootElement);

registerServiceWorker();

