import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';
import {Router} from '@angular/router';


@Component({
  selector: 'app-manual-scanner',
  templateUrl: './manual-scanner.component.html',
  styleUrls: ['./manual-scanner.component.css'],
  providers: [DataService]
})
export class ManualScannerComponent implements OnInit {

  ticketNumber = "";


  constructor(private dataService: DataService, private router: Router) { }

  ngOnInit() {
    
  }

  onConfirmBtnClick() {
    this.dataService.loadRests(this.ticketNumber);
    this.router.navigate(['/list-rest']);
  }

}
