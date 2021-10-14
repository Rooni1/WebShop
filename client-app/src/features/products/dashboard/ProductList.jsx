import { observer } from 'mobx-react-lite';
import React, { useState, useEffect } from 'react';
import { Row, Button } from 'react-bootstrap';

import { useStore } from '../../../app/stores/store';

export default observer(function ProductList() {
  const {productStore} = useStore();
  const {products, productRegistry} = productStore;
  const [list, setList] = useState([]);
  
  useEffect(() => {
    console.log('list');
    setList(products);
  }, [productRegistry.size, products]);

  return (
    <Row className="mt-4 table-responsive ms-0">
        <table className="table table-bordered">
          <thead>
              <tr>
                  <td className="col-sm-1 fw-bold">Id</td>
                  <td className="col-sm-4 fw-bold">Name</td>
                  <td className="col-sm-7"></td>
              </tr>
          </thead>
          <tbody>
            {list && list.map(product => (
              <tr key={product.id}>
                <td className="col-sm-1">{product.id}</td>
                <td className="col-sm-4">{product.name}</td>
                <td className="text-center col-sm-7">
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </Row>
  )
});