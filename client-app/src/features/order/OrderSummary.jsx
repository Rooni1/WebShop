import React from 'react';
import { Link } from 'react-router-dom';

export default function OrderSummary() {
  return (
    <>
      <div className="table-responsive">
        <table className="table table-borderless">
          <thead className="py-2 border-0" style={{backgroundColor: "lightgray"}}>
              <tr>
                  <th scope="col" >
                      <div className="p-2 px-3 text-uppercase">Product</div>
                  </th>
                  <th scope="col">
                      <div className="py-2 text-uppercase">Price</div>
                  </th>
                  <th scope="col">
                      <div className="py-2 text-uppercase">Quantity</div>
                  </th>
                  <th scope="col">
                      <div className="py-2 text-uppercase">Total</div>
                  </th>
                  <th scope="col" className="border-0">
                      <div className="py-2 text-uppercase">Remove</div>
                  </th>
              </tr>
          </thead>
          <tbody>
              <tr>
                  <th scope="row">
                      <div className="p-2">
                          <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/Screw_for_wood.JPG/256px-Screw_for_wood.JPG" alt=""
                              className="img-fluid" style={{maxHeight: "50px"}} />
                          <div className="ml-3 align-middle d-inline-block">
                              <h5 className="mb-0">
                              <Link to={`/shop/${1}`}>
                                  To shop
                              </Link>
                              </h5>
                              <span
                                  className="text-muted font-weight-normal d-block" style={{fontStyle: "italic"}}>Type:
                                  Type</span>
                          </div>
  
                      </div>
                  </th>
                  <td className="align-middle"><strong>100.00</strong></td>
                  <td className="align-middle">
                      <div className="d-flex align-items-center justify-content-start">
                          <i className="me-2 fa fa-minus-circle text-warning"
                              style={{cursor: "pointer", fontSize: "2em"}}></i>
                          <span className="font-weight-bold" style={{fontSize: "1.5em"}}>
                              2
                          </span>
                          <i className="mx-2 fa fa-plus-circle text-warning"
                              style={{cursor: "pointer", fontSize: "2em"}}></i>
                      </div>
                  </td>
                  <td className="align-middle">
                      <strong>200.00</strong></td>
                  <td className="text-center align-middle">
                    <div className="d-flex justify-content-start ms-4">
                      <a className="text-danger">
                          <i class="fa fa-trash" style={{fontSize: "2em", cursor: "pointer"}}></i>
                      </a>
                    </div>
                  </td>
              </tr>
              <tr style={{borderTop: "thin solid"}}>
                  <th scope="row">
                      <div className="p-2">
                          <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/Screw_for_wood.JPG/256px-Screw_for_wood.JPG" alt=""
                              className="img-fluid" style={{maxHeight: "50px"}} />
                          <div className="ml-3 align-middle d-inline-block">
                              <h5 className="mb-0">
                              <Link to={`/shop/${1}`}>
                                  To shop
                              </Link>
                              </h5>
                              <span
                                  className="text-muted font-weight-normal d-block" style={{fontStyle: "italic"}}>Type:
                                  Type</span>
                          </div>
  
                      </div>
                  </th>
                  <td className="align-middle"><strong>100.00</strong></td>
                  <td className="align-middle">
                      <div className="d-flex align-items-center justify-content-start">
                          <i className="me-2 fa fa-minus-circle text-warning"
                              style={{cursor: "pointer", fontSize: "2em"}}></i>
                          <span className="font-weight-bold" style={{fontSize: "1.5em"}}>
                              2
                          </span>
                          <i className="mx-2 fa fa-plus-circle text-warning"
                              style={{cursor: "pointer", fontSize: "2em"}}></i>
                      </div>
                  </td>
                  <td className="align-middle">
                      <strong>200.00</strong></td>
                  <td className="text-center align-middle">
                    <div className="d-flex justify-content-start ms-4">
                      <a className="text-danger">
                          <i class="fa fa-trash" style={{fontSize: "2em", cursor: "pointer"}}></i>
                      </a>
                    </div>
                  </td>
              </tr>
          </tbody>
        </table>
      </div>
    </>
  );
};