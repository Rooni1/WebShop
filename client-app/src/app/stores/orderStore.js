import { makeAutoObservable, runInAction } from "mobx";

import agent from "../api/agent";

export default class OrderStore {
  basketRegistry = new Map();
  total = 0;
  //selectedPerson:  undefined;
  //editMode = false;
  //loading = false;
  //loadingInitial = false;

  constructor() {
    makeAutoObservable(this)
  }

  get basketItems() {
    return Array.from(this.basketRegistry.values());
  }

  addBasketItem = (product) => {
    let basketItem = this.getBasketItem(product.id);
    if (basketItem) {
      const quantity = basketItem.quantity + 1;
      basketItem.quantity = quantity;
      this.basketRegistry.set(basketItem.id, basketItem);
    }
    else {
      const newBasketItem =  this.mapProductItemToBasketItem(product, 1);
      this.basketRegistry.set(product.id, newBasketItem);
    }
    this.total = this.basketItems.reduce((total, next, idx, array) => 
      {
        return total + (array[idx].productPrice * array[idx].quantity)
      }, 0
    );
  }

  updateBasketItem = (item, value) => {
    if (!((item.quantity + value) < 2)) {
      item.quantity = value;
      this.basketRegistry.set(item.id, item);
      this.total = this.basketItems.reduce((total, next, idx, array) => 
        {
          return total + (array[idx].productPrice * array[idx].quantity)
        }, 0
      );
    }
    return item;
  }

  deleteBasketItem(id) {
    this.basketRegistry.delete(id);
    this.total = this.basketItems.reduce((total, next, idx, array) => 
      {
        return total + (array[idx].productPrice * array[idx].quantity)
      }, 0
    );
  }

  mapProductItemToBasketItem = (product, quantity) => {
    return {
      id: product.id, 
      name: product.name,
      quantity: quantity,
      productPrice: product.productPrice
    }
  }

  getBasketItem = (id) => {
    return this.basketRegistry.get(id);
  }

  placeOrder = () => {
    let order = {OrderItems : []}
    this.basketItems.map(item => order.OrderItems.push(
      {
        "ProductId": parseInt(item.id),
        "Quantity": item.quantity
      }));
    
    console.log('debug');
    agent.placeOrder(order);
    this.basketRegistry = new Map();
  }
};