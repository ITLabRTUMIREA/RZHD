import { Component, OnInit, Input } from '@angular/core';
import { TicketrestaurantService } from '../ticketrestaurant.service';

@Component({
  selector: 'app-list-rest-item',
  templateUrl: './list-rest-item.component.html',
  styleUrls: ['./list-rest-item.component.css']
})
export class ListRestItemComponent implements OnInit {

  @Input() data: any;

  constructor(
    private tickrest: TicketrestaurantService
  ) { }

  ngOnInit() {
  }
test()
{
  console.log("pressed")
this.tickrest.setItem(this.data)
}
}
