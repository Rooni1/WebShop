import React from 'react';

import './App.css';

import NavBar from './NavBar';
import ProductDashboard from '../../features/products/dashboard/ProductsDashboard';

function App() {

  return (
    <>
      <NavBar />
      <ProductDashboard />
    </>
  );
};

export default App;
