import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { RestaurantView } from './api/models';

@Injectable({
  providedIn: 'root'
})
export class SampleService {

  private currentRestaurantObserver = new BehaviorSubject<RestaurantView>(null);
   
  public currentRestaurant = this.currentRestaurantObserver.asObservable();


  constructor() {
  }

  public setRestaurant(restaurant: RestaurantView): void {
    this.currentRestaurantObserver.next(restaurant);
  }

}
