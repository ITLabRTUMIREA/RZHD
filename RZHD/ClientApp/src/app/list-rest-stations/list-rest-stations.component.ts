import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-list-rest-stations',
  templateUrl: './list-rest-stations.component.html',
  styleUrls: ['./list-rest-stations.component.css']
})
export class ListRestStationsComponent implements OnInit {

  data = {title: "Шаурма Хауз", img: 'шаурма'};

  constructor() { }

  ngOnInit() {
  }

}
