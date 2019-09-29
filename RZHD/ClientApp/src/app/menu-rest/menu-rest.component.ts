import { Component, OnInit } from '@angular/core';
import { TicketrestaurantService } from '../ticketrestaurant.service';
import { MenuService } from '../menu.service';
import { CartService } from '../cart.service'
import { RestaurantService } from '../api/services';
//import { CreateOrderRequest } from '../api.models/CreateOrderRequest';

@Component({
  selector: 'app-menu-rest',
  templateUrl: './menu-rest.component.html',
  styleUrls: ['./menu-rest.component.css']
})
export class MenuRestComponent implements OnInit {
  product=[]
  olddata
  data

  constructor(private tickrest: TicketrestaurantService,
    private cart: CartService,
    private men: MenuService,
    private rest: RestaurantService) { }

  ngOnInit() {
    this.olddata = this.tickrest.getItem() 
    this.men.getRestaurantMenu(this.olddata.id).subscribe(data => {
      if(data.status)
      {
      this.data = data.content;
      this.men.setData(this.data)
      }
     });
  }
  Click(item){
    this.product = [item.name, item.price]
    this.cart.addId(item.id);
    this.cart.addToCart(this.product);
    this.cart.setRest(this.olddata.name);
    this.cart.setStation(this.olddata.stationTime[0].station.name);
  }
  Click2(){
     /*const temp = {
      productsId : this.cart.getId(),
      stationsId: [this.cart.getStation()],
      restaurantsId: [this.cart.getRest()],
      totalPrice: this.cart.getCount()
    }

    this.rest.apiRestaurantAdminPost$Json({body:temp}).subscribe(data => {
      if (data.status)
      {console.log("ok")}
     });*/
  }
}
