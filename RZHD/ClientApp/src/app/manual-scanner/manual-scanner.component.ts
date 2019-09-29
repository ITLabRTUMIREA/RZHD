import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';


@Component({
  selector: 'app-manual-scanner',
  templateUrl: './manual-scanner.component.html',
  styleUrls: ['./manual-scanner.component.css']
})
export class ManualScannerComponent implements OnInit {

  ticketNumber = "";

  constructor(private router: Router) { }

  ngOnInit() {
    
  }

  onConfirmBtnClick() {
    this.router.navigate(['/list-rest']);
  }

}
