import { Component, OnInit, NgModule } from '@angular/core';
import { Router } from '@angular/router';
import { SampleService } from '../sample.service';

@NgModule({
})

@Component({
  selector: 'app-manual-scanner',
  templateUrl: './manual-scanner.component.html',
  styleUrls: ['./manual-scanner.component.css']
})
export class ManualScannerComponent implements OnInit {

  ticketNumber = "";


  constructor(
    private sample: SampleService,
    private router: Router) { }

  ngOnInit() {
  }
  onConfirmBtnClick() {
    //this.dataService.loadRests(this.ticketNumber);
    /*this.dataService.getRestaurantTicket(this.ticketNumber).subscribe(data => {
      if (data.status) {
        this.router.navigate(['/list-rest']);
      }
    });*/
  }

}
