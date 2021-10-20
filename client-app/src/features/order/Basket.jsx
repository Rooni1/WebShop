import React from 'react';
import { Link } from 'react-router-dom';
import OrderSummary from './OrderSummary';
import OrderTotals from './OrderTotals';

export default function Basket() {
  return (
    <>
      <div className="container mt-2">
        <div>
          <div className="pb-5">
            <div className="container">
              <div className="row">
                <div class="col-12 pb-5 mb-1">
                    <OrderSummary />
                </div>
              </div>
              
              <div className="row">
                <div className="col-6 offset-6">
                  <OrderTotals />
                  <div className="d-grid">
                    <Link to={`/shop`} className="ms-0 btn btn-outline-danger btn-block">
                        Proceed to checkout
                    </Link>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </>
  );
};
