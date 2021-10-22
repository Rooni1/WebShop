import React from 'react';
import { Route, Switch, useLocation } from 'react-router';

import './App.css';

import NavBar from './NavBar';
import ProductDashboard from '../../features/products/dashboard/ProductsDashboard';
import ProductDetails from '../../features/products/details/ProductDetails';
import Basket from '../../features/order/Basket';
import OrderConfirm from '../../features/order/OrderConfirm';

function App() {
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
              <Route path='/basket' component={Basket} />
              <Route exact path='/orderconfirm' component={OrderConfirm} />
            </Switch>
          </>
        
        )}
      />
    </>
  );
};

export default App;
