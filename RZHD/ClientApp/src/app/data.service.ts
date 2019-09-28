import { Injectable } from '@angular/core';
import { RestaurantService } from './api/services';

import { Router } from '@angular/router';
import { ThrowStmt } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class DataService {


    private user: any;
    private ticketError: boolean;
    private rest: any;


    constructor(private restaurantService: RestaurantService, private router : Router) {}

    async loadRests(ticketNumber: string) {
      this.ticketError = false;
      console.log("Ticket number --- " + ticketNumber);
        const result = await this.restaurantService.apiRestaurantTicketGet$Response({ticket: ticketNumber}).toPromise();
        
        console.log("Status --- " + result.body.status);
        console.log("Content --- " + result.body.content);
        
        if(result.body.status) {
          this.rest = result.body.status;
          
        } else {
          this.ticketError = true;
          this.router.navigate(['manual-scanner']);
        }

    }

    log1() {
      console.log(this.rest);
    }


    getTicketError() {
      return this.ticketError;
    }

    getRest() {
      return this.rest;
    }

    getUser() {
          
      return this.user;
  }

}
