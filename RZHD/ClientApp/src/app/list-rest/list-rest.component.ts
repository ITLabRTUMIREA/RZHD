import { Component, OnInit, ViewChild, EventEmitter, Output } from '@angular/core';
import { RestaurantService } from '../api/services';
import { CompileShallowModuleMetadata } from '@angular/compiler';
import { SampleService } from '../sample.service';

@Component({
  selector: 'app-list-rest',
  templateUrl: './list-rest.component.html',
  styleUrls: ['./list-rest.component.css']
})
export class ListRestComponent implements OnInit {

  isPreloaderHidden = false;

  constructor(
    private sample: SampleService,
    private client: RestaurantService) {

  }
  data = [
    {title: 'KFC', img: 'kfc'},
    {title: 'Macdonalds', img: 'мак'}

  ];

  hidePreloader() {
    this.isPreloaderHidden = true
  }


  ngOnInit() {
    // setInterval(function(parent) {
    //   console.log(parent.dataService.getRest());
    //   parent.isPreloaderHidden = parent.dataService.getRest();
    //   parent.dataService.log1();
    // }, 1000, this);
    // this.dataService.getRestaurantTicket("ХХ1234567 123456").subscribe(data => {
    //   console.log(data);
    //   this.data = data.content;
    //   console.log(this.data);
    //   this.isPreloaderHidden = false;
    // });
    //console.log(this.dataService)
    //this.data = this.dataService.getRest().content;
  }
}

