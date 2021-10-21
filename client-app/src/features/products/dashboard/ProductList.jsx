import { observer } from 'mobx-react-lite';
import React, { useState, useEffect } from 'react';

import { useStore } from '../../../app/stores/store';
import { history } from '../../..';

export default observer(function ProductList() {
  const {productStore, orderStore} = useStore();
  const {products, productRegistry} = productStore;
  const {addBasketItem} = orderStore;
  const [list, setList] = useState([]);
  
  useEffect(() => {
    setList(products);
  }, [productRegistry.size, products]);

  function addItem(product) {
    addBasketItem(product, product.id);
    history.push('/basket');
  };
  
  function handleClick(id) {
    history.push('/shop/' + id);
  };

  return (
    <div className="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">
      {list && list.map(product => (
        <div className="col" key={product.id}>
          <div className="shadow-sm card">
            <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/Screw_for_wood.JPG/256px-Screw_for_wood.JPG" alt=""/>
            
            <div className="card-body d-flex flex-column">
              <a href="#">
                <h6 className="text-uppercase">{product.name}</h6>
              </a>
              <span class="mb-2">{product.productPrice}</span>
              <div className="mt-auto btn-group">
                <button type="button" onClick={() => addItem(product)} className="me-2 btn btn-outline-secondary fa fa-shopping-cart" style={{borderRadius: "5px"}}></button>
                <button type="button" onClick={() => handleClick(product.id)} className="btn btn-outline-secondary" style={{borderRadius: "5px"}}>View</button>
              </div>
            </div>
          </div>
        </div>
      ))}
    </div>
  )
});