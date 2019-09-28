import { Component, OnInit } from '@angular/core';
import { DataService } from '../data.service';

@Component({
  selector: 'app-scanner-guide',
  templateUrl: './scanner-guide.component.html',
  styleUrls: ['./scanner-guide.component.css'],
  providers: [DataService]
})
export class ScannerGuideComponent implements OnInit {

  constructor(private dataService: DataService) { 
    //if(!this.dataService.getUser().logged) {

    //}
  
  }

  ngOnInit() {
  }

}
