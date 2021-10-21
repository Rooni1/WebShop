import { observer } from 'mobx-react-lite';
import React from 'react';
import { Link } from 'react-router-dom';

import OrderSummary from './OrderSummary';
import OrderTotals from './OrderTotals';
import { useStore } from '../../app/stores/store';

export default observer(function Basket() {
  const {orderStore} = useStore();
  const {basketItems} = orderStore;

  
  if (!basketItems.length) return (
    <div className="container mt-2">
      <div>
        <div className="pb-5">
          <div className="container">
            <div className="row">
              <p>There are no items in your basket</p>
            </div>
          </div>
        </div>
      </div>
    </div>  
  )
  
  
  return (
    <>
      <div className="container mt-2">
        <div>
          <div className="pb-5">
            <div className="container">
              <div className="row">
                <div className="pb-5 mb-1 col-12">
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
});
