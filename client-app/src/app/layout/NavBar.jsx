import React from 'react';

import { Row, Col, Navbar, Nav } from 'react-bootstrap';
import { history } from '../..';

function handleClick() {
  history.push('/basket/');
};

export default function NavBar() {
  return (
    <div className="p-3 mb-3 bg-white shadow-sm d-flex flex-column flex-md-row align-items-center justify-content-between px-md-4 border-bottom">
      <div className="d-flex flex-column align-items-center">
        <h5 className="my-0 mr-md-auto font-weight-normal">E-commerce</h5>
      </div>
      <div className="d-flex flex-column flex-md-row align-items-center">
        <nav className="my-2 my-md-0 mr-md-3 text-uppercase" style={{fontSize: "larger;"}}>
          <a className="p-2 text-dark" href="#">Home</a>
          <a className="p-2 text-dark" href="#">Shop</a>
          <a className="p-2 text-dark" href="#">Contact</a>
        </nav>
      </div>
      <div className="d-flex justify-content-center">  
        <a className="position-relative me-2 ">
          <i className="fa fa-shopping-cart fa-2x text-dark" onClick={handleClick}></i>
          <div className="mt-2 cart-no">5</div>
        </a>
        <a className="btn btn-outline-primary">Login</a>
        <a className="ms-2 btn btn-outline-secondary">Sign up</a>
      </div>
    </div>
  )
}