import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  items = [];
  count = 0;
  rest;
  stat;
  ids=[];
  addToCart(product) {
    this.count+=product[1];
    this.items.push(product);
  }

  getItems() {
    return this.items;
  }

  clearCart() {
    this.items = [];
    this.count=0
    return this.items;
  }
  addId(id){
    this.ids.push(id)
  }
  getId()
  {
    return this.ids;
  }
  getCount(){
    return this.count
  }
  setRest(item)
  {
this.rest=item
  }
  getRest()
  {
  return this.rest
  }
  setStation(item){
this.stat=item
  }
  getStation(){
    return this.stat
      }
  constructor() { }
}
