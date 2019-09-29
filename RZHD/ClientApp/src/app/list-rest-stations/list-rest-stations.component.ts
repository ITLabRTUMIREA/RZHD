import { Component, OnInit, Input } from '@angular/core';
import { TicketrestaurantService } from '../ticketrestaurant.service';

@Component({
  selector: 'app-list-rest-stations',
  templateUrl: './list-rest-stations.component.html',
  styleUrls: ['./list-rest-stations.component.css']
})
export class ListRestStationsComponent implements OnInit {

  data = {title: "Шаурма Хауз", img: 'шаурма'};

  constructor(private tickrest: TicketrestaurantService) { }

  ngOnInit() {
    console.log(this.tickrest.getItem());
    this.data = this.tickrest.getItem()
  }

}
