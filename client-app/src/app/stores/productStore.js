import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";

export default class ProductStore {
  productRegistry = new Map();
  selectedProduct = undefined;
  editMode = false;
  loadingInitial = false;

  constructor() {
    makeAutoObservable(this)
  }

  get products() {
    return Array.from(this.productRegistry.values());
  }

  loadProducts = async () => {
    this.loadingInitial = true;
    try {
      await agent.productList().then(data => data.forEach(product => this.setProduct(product)));
      this.setLoadingInitial(false);      
    } catch (error) {
      console.log(error);
      this.setLoadingInitial(false);
    }
  }

  setProduct = (product) => {
    console.log('debug');
    this.productRegistry.set(product.id, product);
  }

  setLoadingInitial = (state) => {
    this.loadingInitial = state;
  }
}