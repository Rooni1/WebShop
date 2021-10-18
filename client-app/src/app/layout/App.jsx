import React from 'react';
import { Route, Switch, useLocation } from 'react-router';

import './App.css';

import NavBar from './NavBar';
import ProductDashboard from '../../features/products/dashboard/ProductsDashboard';
import ProductDetails from '../../features/products/details/ProductDetails';


function App() {
  const location = useLocation();
  return (
    <>
      <Route
        path={'/(.+)'}
        render={() => (
          <>
            <NavBar />
            <Switch>
              <Route exact path='/shop' component={ProductDashboard} />
              <Route path='/shop/:id' component={ProductDetails} />
            </Switch>
          </>
        
        )}
      />
    </>
  );
};

export default App;
