import { observer } from 'mobx-react-lite';
import React, { useState, useEffect } from 'react';

import { useStore } from '../../app/stores/store';
import OrderSummaryItem from './OrderSummaryItem';

export default observer(function OrderSummary() {
  const {orderStore} = useStore();
  const {basketItems} = orderStore;

  const [items, setItems] = useState(basketItems);

  useEffect(() => {
    setItems(basketItems);
  }, [basketItems.size, basketItems]);

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
            {items && items.map(item => <OrderSummaryItem basketItem={item} />)}
          </tbody>
        </table>
        
      </div>
    </>
  );
});