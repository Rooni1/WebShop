import React, { ChangeEvent, useEffect, useState }  from 'react';
import { Row, Col, Form, Button } from 'react-bootstrap';

import { useStore } from '../../../app/stores/store';
import { history } from '../../..';
import ProductList from './ProductList';

export default function Dashboard() {
  const {productStore} = useStore();
  const {loadProducts, productRegistry} = productStore;

  useEffect(() => {
    if ((productRegistry.size <= 1)) loadProducts();
  }, [productRegistry.size, loadProducts]);

  function handleClick(id) {
    history.push('/shop/' + id);
  };

  return (
    <>
      
      <div className="container">
        <div className="row">
          
          <section className="col-3">
            <h5 className="ml-3 text-warning">Brands</h5>
            <ul class="list-group my-3">
              <li class="list-group-item active" aria-current="true">An active item</li>
              <li class="list-group-item">A second item</li>
              <li class="list-group-item">A third item</li>
              <li class="list-group-item">A fourth item</li>
              <li class="list-group-item">And a fifth one</li>
            </ul>
            <h5 className="ml-3 text-warning">Types</h5>
            <ul class="list-group my-3">
              <li class="list-group-item active" aria-current="true">An active item</li>
              <li class="list-group-item">A second item</li>
              <li class="list-group-item">A third item</li>
              <li class="list-group-item">A fourth item</li>
              <li class="list-group-item">And a fifth one</li>
            </ul>
          </section>
          
          <section className="col-9">
            <div className="pb-2 row">
              <div class="col-4 d-flex align-items-center">
                <header>
                  <span>Showing <strong>10</strong> of <strong>16</strong> Results</span>
                </header>
              </div>
              <div className="mt-2 col-8">
                  <div className="row">
                    <div className="col d-flex justify-content-sm-end">
                      <input className="form-control" style={{width: "300px"}} placeholder="Search" 
                        type="text" />
                      <button className="ms-2 btn btn-outline-primary">Search</button> 
                      <button className="ms-2 btn btn-outline-success">Reset</button>
                    </div>
                  </div>
              </div> 
            </div>
            
            <ProductList />
          </section>
        </div>
      </div>
    </>
  );
}