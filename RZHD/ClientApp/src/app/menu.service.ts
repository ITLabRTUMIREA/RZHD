import { Injectable } from '@angular/core';
import { RestaurantService } from './api/services';
import { Observable } from 'rxjs';
import { MenuViewIEnumerableResponse } from './api/models';
import { StrictHttpResponse } from './api/strict-http-response';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  data;

  constructor(private restaurantService: RestaurantService) { }

  getRestaurantMenu(restName: number):Observable<MenuViewIEnumerableResponse>{
    return this.restaurantService.apiRestaurantRestIdGet({restId: restName});
  }
  setData(data) 
  {
    this.data = data;
  }
  getData()
  {
    return this.data;
  }
}
