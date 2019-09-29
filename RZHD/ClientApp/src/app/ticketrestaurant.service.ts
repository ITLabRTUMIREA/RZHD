import { Injectable } from '@angular/core';
import { RestaurantService } from './api/services';
import { Observable } from 'rxjs';
import { RestaurantViewIEnumerableResponse } from './api/models';
import { StrictHttpResponse } from './api/strict-http-response';

@Injectable({
  providedIn: 'root'
})
export class TicketrestaurantService {
  data;
  itemdata;
  constructor(private restaurantService: RestaurantService) { }

  getRestaurantTicket(ticketNumber: string):Observable<RestaurantViewIEnumerableResponse>{
    return this.restaurantService.apiRestaurantTicketGet({ticket: ticketNumber});
  }
  setData(data) 
  {
    this.data = data;
  }
  getData()
  {
    return this.data;
  }
  setItem(data)
  {
    this.itemdata = data
  }
  getItem()
  {
    return this.itemdata;
  }
}
