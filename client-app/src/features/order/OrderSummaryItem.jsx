//
// Time-stamp: <2021-10-31 18:18:20 stefan>
//

import React, { useState } from 'react';
import { Link } from 'react-router-dom';

import { useStore } from '../../app/stores/store';

export default function OrderSummaryItem(props) {
  const {orderStore} = useStore();
  const {updateBasketItem} = orderStore;

  const [quantity, setQuantity] = useState(props.basketItem.quantity);

  function changeQuantity(item, value) {
    const updatedItem = updateBasketItem(item, value);
    console.log(updatedItem.quantity);
    setQuantity(updatedItem.quantity);
  };

  function deleteItem(id) {
    let deleteFunction = orderStore.deleteBasketItem;
    let bindedFunction = deleteFunction.bind(orderStore);
    bindedFunction(id);
  };

  return (
    <tr>
      <th scope="row">
	  <div className="p-2">
	      <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/Screw_for_wood.JPG/256px-Screw_for_wood.JPG" alt=""
		  className="img-fluid" style={{maxHeight: "50px"}} />
	      <div className="ml-3 align-middle d-inline-block">
		  <h5 className="mb-0">
		  <Link to={`/shop/${props.basketItem.id}`}>
		      {props.basketItem.name}
		  </Link>
		  </h5>
	      </div>
	  </div>
      </th>
      <td className="align-middle"><strong>{props.basketItem.productPrice}</strong></td>
      <td className="align-middle">
	  <div className="d-flex align-items-center justify-content-start">
	      <i onClick={() => changeQuantity(props.basketItem, quantity - 1)}
		className="me-2 fa fa-minus-circle text-warning" style={{cursor: "pointer", fontSize: "2em"}}></i>
	      <span className="font-weight-bold" style={{fontSize: "1.5em"}}>
		  {quantity}
	      </span>
	      <i onClick={() => changeQuantity(props.basketItem, quantity + 1)}
		className="mx-2 fa fa-plus-circle text-warning" style={{cursor: "pointer", fontSize: "2em"}}></i>
	  </div>
      </td>
      <td className="align-middle">
	  <strong>{props.basketItem.productPrice * quantity}</strong></td>
      <td className="text-center align-middle">
	<div className="d-flex justify-content-start ms-4">
	  <a className="text-danger">
	      <i onClick={() => deleteItem(props.basketItem.id)} className="fa fa-trash" style={{fontSize: "2em", cursor: "pointer"}}></i>
	  </a>
	</div>
      </td>
    </tr>
  );
};
