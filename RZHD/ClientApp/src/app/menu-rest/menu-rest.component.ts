import { Component, OnInit } from '@angular/core';
import { TicketrestaurantService } from '../ticketrestaurant.service';
import { MenuService } from '../menu.service';

@Component({
  selector: 'app-menu-rest',
  templateUrl: './menu-rest.component.html',
  styleUrls: ['./menu-rest.component.css']
})
export class MenuRestComponent implements OnInit {

  olddata
  data
  //data = {title: "Шаурма Хауз", img: 'шаурма'};

  constructor(private tickrest: TicketrestaurantService,
    private men: MenuService) { }

  ngOnInit() {
    this.olddata = this.tickrest.getItem() 
    console.log(this.olddata)
    this.men.getRestaurantMenu(this.olddata.id).subscribe(data => {
      console.log(data)
      if(data.status)
      {
      this.data = data.content;
      this.men.setData(this.data)
      }
      console.log(this.men.getData())
     });
  }

}
