import { Component, OnInit } from '@angular/core';
import { CartService } from '../cart.service'

@Component({
  selector: 'app-basket-rest',
  templateUrl: './basket-rest.component.html',
  styleUrls: ['./basket-rest.component.css']
})
export class BasketRestComponent implements OnInit {

  price=0;
  data;
  constructor(private cart: CartService) { }

  ngOnInit() {
    this.price= this.cart.getCount();
    this.data= this.cart.getItems();
  }

}
