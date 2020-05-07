import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './layout/Layout'
import MapPage  from './pages/MapPage';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={MapPage} />
        <Route path='/Map' component={MapPage} />
        </Layout>
    );
  }
}
