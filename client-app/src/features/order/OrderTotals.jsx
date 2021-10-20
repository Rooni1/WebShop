
export default function OrderTotal() {
  
  return (
    <>
      <div className="px-4 text-uppercase" 
        style={{padding: "1.20em", backgroundColor: "lightgray", fontWeight: "bold"}}>
          Order Summary
      </div>
      <div className="p-4">
          <p className="mb-4" style={{fontStyle: "italic"}}>Shipping costs will be added depending on choices made during checkout</p>
          <ul className="mb-4 list-unstyled">
              <li className="py-3 d-flex justify-content-between border-bottom">
                  <strong className="text-muted">Order subtotal</strong>
                  <strong>1000.00</strong>
              </li>
              <li className="py-3 d-flex justify-content-between border-bottom">
                  <strong class="text-muted">Shipping and handling</strong>
                  <strong>200.00</strong>
              </li>
              <li className="py-3 d-flex justify-content-between border-bottom">
                  <strong class="text-muted">Total</strong>
                  <strong>1200.00</strong>
              </li>
          </ul>
      </div>
    </>
  );
  }
