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
            <div class="d-grid gap-2 mt-2">
                <button className="btn btn-outline-secondary btn-block">Lägg i varukorg</button>
                <button className="btn btn-outline-secondary">Till listan</button>
              </div>
          </div>
        </div>
        <div className="col-4">
          <div className="d-flex justify-content-start align-items-center">
            <div className="ml-3 col-12">
              <h5>Produktnamn</h5>
              <p>{product.name}</p>
              <h5>Produktbeskrivning</h5>
              <p>{product.productDescription}</p>
              <h5>Pris</h5>
              <p>{product.productPrice}</p>
            </div>
          </div>
        </div>
      </div>
    </>
  );
});
