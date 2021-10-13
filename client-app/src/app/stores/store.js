import { createContext, useContext } from "react";

import ProductStore from "./productStore";

export const store = {
  productStore: new ProductStore()
}

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}