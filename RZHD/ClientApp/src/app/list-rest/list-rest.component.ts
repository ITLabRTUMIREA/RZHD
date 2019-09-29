import { Component, OnInit, ViewChild, EventEmitter, Output } from '@angular/core';
import { RestaurantService } from '../api/services';
import { CompileShallowModuleMetadata } from '@angular/compiler';

@Component({
  selector: 'app-list-rest',
  templateUrl: './list-rest.component.html',
  styleUrls: ['./list-rest.component.css']
})
export class ListRestComponent implements OnInit {

  isPreloaderHidden = false;

  constructor(private client : RestaurantService) {

  }

  hidePreloader() {
    this.isPreloaderHidden = true
  }


  ngOnInit() {
  }
}

