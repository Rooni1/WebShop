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

  loadProduct = async (id) => {
    let product = this.getProduct(id);
    if (product) {
      this.selectedProduct = product;
      return product;
    } else {
      this.loadingInitial = true;
      try {
        product = await agent.Products.details(id);
        this.setProduct(product);
        //runInAction(() => {
          this.selectedProduct = product;
        //});        
        this.setLoadingInitial(false);
        return product;
      } catch (error) {
        console.log(error);
        //this.setLoadingInitial(false);
      }
    }
  }

  setProduct = (product) => {
    this.productRegistry.set(product.id, product);
  }

  getProduct = (id) => {
    return this.productRegistry.get(id);
  }

  setLoadingInitial = (state) => {
    this.loadingInitial = state;
  }
}