import { Component, OnInit, ViewChild, EventEmitter, Output } from '@angular/core';
import { CompileShallowModuleMetadata } from '@angular/compiler';
import { TicketrestaurantService } from '../ticketrestaurant.service';

@Component({
  selector: 'app-list-rest',
  templateUrl: './list-rest.component.html',
  styleUrls: ['./list-rest.component.css']
})
export class ListRestComponent implements OnInit {

  isPreloaderHidden = false;

  constructor(
    private tickrest: TicketrestaurantService
    ) {

  }
  data = [
    {title: 'KFC', img: 'kfc'},
    {title: 'Macdonalds', img: 'мак'}

  ];

  hidePreloader() {
    this.isPreloaderHidden = true
  }


  ngOnInit() {
    console.log(this.tickrest.getData());
    this.data = this.tickrest.getData()
    // setInterval(function(parent) {
    //   console.log(parent.dataService.getRest());
    //   parent.isPreloaderHidden = parent.dataService.getRest();
    //   parent.dataService.log1();
    // }, 1000, this);
    // this.dataService.getRestaurantTicket("ХХ1234567 123456").subscribe(data => {
    //   console.log(data);
    //   this.data = data.content;
    //   console.log(this.data);
    //   this.isPreloaderHidden = false;
    // });
    //console.log(this.dataService)
    //this.data = this.dataService.getRest().content;
  }
}

