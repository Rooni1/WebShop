import React, { ChangeEvent, useEffect, useState }  from 'react';
import { Row, Col, Form, Button } from 'react-bootstrap';

import { useStore } from '../../../app/stores/store';
import ProductList from './ProductList';

export default function Dashboard() {
  const {productStore} = useStore();
  const {loadProducts, productRegistry} = productStore;

  useEffect(() => {
    if ((productRegistry.size <= 1)) loadProducts();
  }, [productRegistry.size, loadProducts]);

  return (
    <>
      <ProductList />
    </>
  );
}