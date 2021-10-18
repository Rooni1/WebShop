import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';
import { Row, Col, Form, Button } from 'react-bootstrap';
import { useParams } from 'react-router';
import { useStore } from '../../../app/stores/store';

export default observer(function PersonDetails() {
  const {productStore} = useStore();
  //const {selectedPerson: person, loadPerson, loadingInitial} = personStore;
  const { id } = useParams();

  /**useEffect(() => {
    if (id) loadPerson(id);
  }, [id, loadPerson]);

  if (loadingInitial || !person) return (<div></div>);
**/
  return (
    <>
      <div className="row">
        <div className="col-4 ms-4">
          <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/c/cb/Screw_for_wood.JPG/256px-Screw_for_wood.JPG" alt="" className="img-fluid"></img>
        </div>
        <div className="col-4">
          <h3>Product name</h3>
          <p>100.00</p>
          <div className="d-flex justify-content-start align-items-center">
            <i className="fa fa-minus-circle text-warning me-2" style={{cursor: "pointer;", fontSize: "2em"}}></i>
            <span className="font-weight-bold" style={{fontSize: "1.5em"}}>2</span>
            <i className="fa fa-plus-circle text-warning mx-2" style={{cursor: "pointer;", fontSize: "2em"}}></i>
            <button className="btn btn-outline-secondary btn-lg ms-4">Add to cart</button>
          </div>
        </div>
        <div className="row ms-2 mt-5">
            <div className="col-12 ml-3">
              <h4>Description</h4>
              <p>Product Description</p>
            </div>
          </div>
      </div>
    </>
  );
});
