import React, { ChangeEvent, useEffect, useState }  from 'react';
import { Row, Col, Form, Button } from 'react-bootstrap';

import { useStore } from '../../../app/stores/store';
import ProductList from './ProductList';

export default function Dashboard() {
  const {productStore} = useStore();
  const {loadProducts, productRegistry} = productStore;

  useEffect(() => {
    if ((productRegistry.size <= 1)) loadProducts();
  }, [productRegistry.size, loadProducts]);

  return (
    <>
      <ProductList />
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
            
            <div className="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">
              <div className="col">
                <div className="shadow-sm card">
                  <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/Screw_for_wood.JPG/256px-Screw_for_wood.JPG" alt=""/>
                  
                  <div className="card-body d-flex flex-column">
                    <a href="#">
                      <h6 className="text-uppercase">Product name</h6>
                    </a>
                    <span class="mb-2">110.00</span>
                    <div className="mt-auto btn-group">
                      <button type="button" className="me-2 btn btn-outline-secondary fa fa-shopping-cart" style={{borderRadius: "5px"}}></button>
                      <button type="button" className="btn btn-outline-secondary" style={{borderRadius: "5px"}}>View</button>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col">
                <div className="shadow-sm card">
                  <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/Screw_for_wood.JPG/256px-Screw_for_wood.JPG" alt=""/>
                  
                  <div className="card-body d-flex flex-column">
                    <a href="#">
                      <h6 className="text-uppercase">Product name</h6>
                    </a>
                    <span class="mb-2">110.00</span>
                    <div className="mt-auto btn-group">
                      <button type="button" className="me-2 btn btn-outline-secondary fa fa-shopping-cart" style={{borderRadius: "5px"}}></button>
                      <button type="button" className="btn btn-outline-secondary" style={{borderRadius: "5px"}}>View</button>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col">
                <div className="shadow-sm card">
                  <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/Screw_for_wood.JPG/256px-Screw_for_wood.JPG" alt=""/>
                  
                  <div className="card-body d-flex flex-column">
                    <a href="#">
                      <h6 className="text-uppercase">Product name</h6>
                    </a>
                    <span class="mb-2">110.00</span>
                    <div className="mt-auto btn-group">
                      <button type="button" className="me-2 btn btn-outline-secondary fa fa-shopping-cart" style={{borderRadius: "5px"}}></button>
                      <button type="button" className="btn btn-outline-secondary" style={{borderRadius: "5px"}}>View</button>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col">
                <div className="shadow-sm card">
                  <svg className="bd-placeholder-img card-img-top" width="100%" height="225" xmlns="http://www.w3.org/2000/svg" role="img" aria-label="Placeholder: Thumbnail" preserveAspectRatio="xMidYMid slice" focusable="false"><title>Placeholder</title><rect width="100%" height="100%" fill="#55595c"/><text x="50%" y="50%" fill="#eceeef" dy=".3em">Thumbnail</text></svg>

                  <div className="card-body">
                    <p className="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                    <div className="d-flex justify-content-between align-items-center">
                      <div className="btn-group">
                        <button type="button" className="btn btn-sm btn-outline-secondary">View</button>
                        <button type="button" className="btn btn-sm btn-outline-secondary">Edit</button>
                      </div>
                      <small className="text-muted">9 mins</small>
                    </div>
                  </div>
                </div>
              </div>

              <div className="col">
                <div className="shadow-sm card">
                  <svg className="bd-placeholder-img card-img-top" width="100%" height="225" xmlns="http://www.w3.org/2000/svg" role="img" aria-label="Placeholder: Thumbnail" preserveAspectRatio="xMidYMid slice" focusable="false"><title>Placeholder</title><rect width="100%" height="100%" fill="#55595c"/><text x="50%" y="50%" fill="#eceeef" dy=".3em">Thumbnail</text></svg>

                  <div className="card-body">
                    <p className="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                    <div className="d-flex justify-content-between align-items-center">
                      <div className="btn-group">
                        <button type="button" className="btn btn-sm btn-outline-secondary">View</button>
                        <button type="button" className="btn btn-sm btn-outline-secondary">Edit</button>
                      </div>
                      <small className="text-muted">9 mins</small>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col">
                <div className="shadow-sm card">
                  <svg className="bd-placeholder-img card-img-top" width="100%" height="225" xmlns="http://www.w3.org/2000/svg" role="img" aria-label="Placeholder: Thumbnail" preserveAspectRatio="xMidYMid slice" focusable="false"><title>Placeholder</title><rect width="100%" height="100%" fill="#55595c"/><text x="50%" y="50%" fill="#eceeef" dy=".3em">Thumbnail</text></svg>

                  <div className="card-body">
                    <p className="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                    <div className="d-flex justify-content-between align-items-center">
                      <div className="btn-group">
                        <button type="button" className="btn btn-sm btn-outline-secondary">View</button>
                        <button type="button" className="btn btn-sm btn-outline-secondary">Edit</button>
                      </div>
                      <small className="text-muted">9 mins</small>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col">
                <div className="shadow-sm card">
                  <svg className="bd-placeholder-img card-img-top" width="100%" height="225" xmlns="http://www.w3.org/2000/svg" role="img" aria-label="Placeholder: Thumbnail" preserveAspectRatio="xMidYMid slice" focusable="false"><title>Placeholder</title><rect width="100%" height="100%" fill="#55595c"/><text x="50%" y="50%" fill="#eceeef" dy=".3em">Thumbnail</text></svg>

                  <div className="card-body">
                    <p className="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                    <div className="d-flex justify-content-between align-items-center">
                      <div className="btn-group">
                        <button type="button" className="btn btn-sm btn-outline-secondary">View</button>
                        <button type="button" className="btn btn-sm btn-outline-secondary">Edit</button>
                      </div>
                      <small className="text-muted">9 mins</small>
                    </div>
                  </div>
                </div>
              </div>

              <div className="col">
                <div className="shadow-sm card">
                  <svg className="bd-placeholder-img card-img-top" width="100%" height="225" xmlns="http://www.w3.org/2000/svg" role="img" aria-label="Placeholder: Thumbnail" preserveAspectRatio="xMidYMid slice" focusable="false"><title>Placeholder</title><rect width="100%" height="100%" fill="#55595c"/><text x="50%" y="50%" fill="#eceeef" dy=".3em">Thumbnail</text></svg>

                  <div className="card-body">
                    <p className="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                    <div className="d-flex justify-content-between align-items-center">
                      <div className="btn-group">
                        <button type="button" className="btn btn-sm btn-outline-secondary">View</button>
                        <button type="button" className="btn btn-sm btn-outline-secondary">Edit</button>
                      </div>
                      <small className="text-muted">9 mins</small>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col">
                <div className="shadow-sm card">
                  <svg className="bd-placeholder-img card-img-top" width="100%" height="225" xmlns="http://www.w3.org/2000/svg" role="img" aria-label="Placeholder: Thumbnail" preserveAspectRatio="xMidYMid slice" focusable="false"><title>Placeholder</title><rect width="100%" height="100%" fill="#55595c"/><text x="50%" y="50%" fill="#eceeef" dy=".3em">Thumbnail</text></svg>

                  <div className="card-body">
                    <p className="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                    <div className="d-flex justify-content-between align-items-center">
                      <div className="btn-group">
                        <button type="button" className="btn btn-sm btn-outline-secondary">View</button>
                        <button type="button" className="btn btn-sm btn-outline-secondary">Edit</button>
                      </div>
                      <small className="text-muted">9 mins</small>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col">
                <div className="shadow-sm card">
                  <svg className="bd-placeholder-img card-img-top" width="100%" height="225" xmlns="http://www.w3.org/2000/svg" role="img" aria-label="Placeholder: Thumbnail" preserveAspectRatio="xMidYMid slice" focusable="false"><title>Placeholder</title><rect width="100%" height="100%" fill="#55595c"/><text x="50%" y="50%" fill="#eceeef" dy=".3em">Thumbnail</text></svg>

                  <div className="card-body">
                    <p className="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
                    <div className="d-flex justify-content-between align-items-center">
                      <div className="btn-group">
                        <button type="button" className="btn btn-sm btn-outline-secondary">View</button>
                        <button type="button" className="btn btn-sm btn-outline-secondary">Edit</button>
                      </div>
                      <small className="text-muted">9 mins</small>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </section>
        </div>
      </div>
    </>
  );
}