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
          <div className="row">
            <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/Screw_for_wood.JPG/256px-Screw_for_wood.JPG" alt="" className="img-fluid"></img>
          </div>
          <div className="row">
            <div className="col-4">
              <button className="btn btn-outline-secondary btn-lg">Till listan</button>
            </div>
          </div>
        </div>
        <div className="col-4">
          <div className="d-flex justify-content-start align-items-center">
            <div className="ml-3 col-12">
              <h4>Produktnamn</h4>
              <p>{product.name}</p>
              <h4>Produktbeskrivning</h4>
              <p>{product.productDescription}</p>
              <h4>Pris</h4>
              <p>{product.productPrice}</p>
              <button className="btn btn-outline-secondary btn-lg">Lägg i varukorg</button>
            </div>
          </div>
        </div>
      </div>
    </>
  );
});
