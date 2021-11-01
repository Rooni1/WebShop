import { createContext, useContext } from "react";

import ProductStore from "./productStore";
import OrderStore from './orderStore';

export const store = {
  productStore: new ProductStore(),
  orderStore: new OrderStore()
}

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
