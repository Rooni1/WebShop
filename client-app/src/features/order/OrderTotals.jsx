//
// Time-stamp: <2021-10-31 18:18:50 stefan>
//

import React, { useState, useEffect } from 'react';
import { observer } from 'mobx-react-lite';

import { useStore } from '../../app/stores/store';

export default observer(function OrderTotal() {
  const {orderStore} = useStore();
  const {total} = orderStore;

  const [totalSum, setTotalSum] = useState(0);

  useEffect(() => {
    setTotalSum(total);
  }, [total]);

  return (
    <>
      <div className="px-4 text-uppercase"
	style={{padding: "1.20em", backgroundColor: "lightgray", fontWeight: "bold"}}>
	  Order Summary
      </div>
      <div className="p-4">
	  <ul className="mb-4 list-unstyled">
	      <li className="py-3 d-flex justify-content-between border-bottom">
		  <strong className="text-muted">Order subtotal</strong>
		  <strong>{totalSum}</strong>
	      </li>
	      <li className="py-3 d-flex justify-content-between border-bottom">
		  <strong className="text-muted">Shipping and handling</strong>
		  <strong>{totalSum ? 10 : 0}</strong>
	      </li>
	      <li className="py-3 d-flex justify-content-between border-bottom">
		  <strong className="text-muted">Total</strong>
		  <strong>{totalSum ? totalSum + 10 : 0}</strong>
	      </li>
	  </ul>
      </div>
    </>
  );
  })
