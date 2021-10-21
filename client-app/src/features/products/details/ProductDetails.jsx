import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';
import { useParams } from 'react-router';

import { useStore } from '../../../app/stores/store';

export default observer(function ProductDetails() {
  const {productStore} = useStore();
  const {selectedProduct: product, loadProduct, loadingInitial} = productStore;
  const { id } = useParams();

  useEffect(() => {
    if (id) loadProduct(id);
  }, [id, loadProduct]);

  if (loadingInitial || !product) return (<div></div>);

  return (
    <>
      <div className="row">
        <div className="col-4 ms-4">
          <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/Screw_for_wood.JPG/256px-Screw_for_wood.JPG" alt="" className="img-fluid"></img>
        </div>
        <div className="col-4">
          <h3>{product.name}</h3>
          <p>{product.productPrice}</p>
          <div className="d-flex justify-content-start align-items-center">
            <i className="fa fa-minus-circle text-warning me-2" style={{cursor: "pointer;", fontSize: "2em"}}></i>
            <span className="font-weight-bold" style={{fontSize: "1.5em"}}>2</span>
            <i className="mx-2 fa fa-plus-circle text-warning" style={{cursor: "pointer;", fontSize: "2em"}}></i>
            <button className="btn btn-outline-secondary btn-lg ms-4">Add to cart</button>
          </div>
        </div>
        <div className="mt-5 row ms-2">
            <div className="ml-3 col-12">
              <h4>Description</h4>
              <p>{product.productDescription}</p>
            </div>
          </div>
      </div>
    </>
  );
});
