import React, { useState, useEffect } from 'react';
import { observer } from 'mobx-react-lite';
import { Link } from 'react-router-dom';

import { useStore } from '../../app/stores/store';

import { history } from '../..';



export default observer(function NavBar() {
  const {orderStore} = useStore();
  const {basketItems} = orderStore;

  const [basketSize, setBasketSize] = useState(0);

  useEffect(() => {
    setBasketSize(basketItems.length);
  }, [basketItems.length]);

  function handleClick() {
    history.push('/basket/');
  };

  return (
    <div className="p-3 mb-3 bg-white shadow-sm d-flex flex-column flex-md-row align-items-center justify-content-between px-md-4 border-bottom">
      <div className="d-flex flex-column align-items-center">
	<h5 className="my-0 mr-md-auto font-weight-normal">E-commerce</h5>
      </div>
      <div className="d-flex flex-column flex-md-row align-items-center">
	<nav className="my-2 my-md-0 mr-md-3 text-uppercase" style={{fontSize: "larger;"}}>
	  <a className="p-2 text-dark" href="#">Home</a>
	  <Link to={`/shop`} className="p-2 text-dark">
	    Shop
	  </Link>
	</nav>
      </div>
      <div className="d-flex justify-content-center">
	<a className="position-relative me-2 ">
	  <i className="fa fa-shopping-cart fa-2x text-dark" onClick={handleClick}></i>
	  {basketItems.length ?
	    <div className="mt-2 cart-no">{basketSize}</div>
	    : <div></div>
	  }
	</a>
	<a className="btn btn-outline-primary">Login</a>
	<a className="ms-2 btn btn-outline-secondary">Sign up</a>
      </div>
    </div>
  )
});
