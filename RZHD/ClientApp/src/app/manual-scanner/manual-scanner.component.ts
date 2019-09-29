import { Component, OnInit, NgModule } from '@angular/core';
import { Router } from '@angular/router';
import { TicketrestaurantService } from '../ticketrestaurant.service';

@NgModule({
})

@Component({
  selector: 'app-manual-scanner',
  templateUrl: './manual-scanner.component.html',
  styleUrls: ['./manual-scanner.component.css']
})
export class ManualScannerComponent implements OnInit {

  ticketNumber = "";
  data;


  constructor(
    private tickrest: TicketrestaurantService,
    private router: Router) { }

  ngOnInit() {
  }
  onConfirmBtnClick() {
    this.tickrest.getRestaurantTicket(this.ticketNumber).subscribe(data => {
      if(data.status)
      {
      this.data = data.content;
      this.tickrest.setData(this.data)
      this.router.navigate(['/list-rest']);
      }
     });
    //this.dataService.loadRests(this.ticketNumber);
    /*this.dataService.getRestaurantTicket(this.ticketNumber).subscribe(data => {
      if (data.status) {
        this.router.navigate(['/list-rest']);
      }
    });*/
  }

}
