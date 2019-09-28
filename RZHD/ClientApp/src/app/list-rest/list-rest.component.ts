import { Component, OnInit, ViewChild, EventEmitter, Output } from '@angular/core';
import { RestaurantService } from '../api/services';
import { CompileShallowModuleMetadata } from '@angular/compiler';
import { DataService } from '../data.service';

@Component({
  selector: 'app-list-rest',
  templateUrl: './list-rest.component.html',
  styleUrls: ['./list-rest.component.css']
})
export class ListRestComponent implements OnInit {

  isPreloaderHidden = false;

  constructor(private client : RestaurantService, private dataService : DataService) {

  }

  hidePreloader() {
    this.isPreloaderHidden = true
  }


  ngOnInit() {
    setInterval(function(parent) {
      console.log(parent.dataService.getRest());
      parent.isPreloaderHidden = parent.dataService.getRest();
      parent.dataService.log1();
    }, 1000, this);
  }
}

