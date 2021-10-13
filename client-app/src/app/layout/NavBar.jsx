import React from 'react';

import { Row, Col, Navbar, Nav } from 'react-bootstrap';

export default function NavBar() {
  return (
    <Row>
      <Col xs={12} md={12}>
      <Navbar  className="navbar-dark fixed-top bg-primary ps-5 pe-5">
         <Navbar.Brand className="p-0" href="#home">E-commerce</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="ms-auto">
              <Nav.Link className="text-white" href="/">Home</Nav.Link>
              <Nav.Link className="text-white" href="/">Products</Nav.Link>
              <Nav.Link className="text-white" href="/">Basket</Nav.Link>
              <Nav.Link className="text-white" href="/">Checkout</Nav.Link>
              <Nav.Link className="text-white" href="/">City</Nav.Link>
            </Nav>
          </Navbar.Collapse>
      </Navbar>
      </Col>
    </Row>
  )
}