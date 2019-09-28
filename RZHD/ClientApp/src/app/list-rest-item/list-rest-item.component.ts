import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-list-rest-item',
  templateUrl: './list-rest-item.component.html',
  styleUrls: ['./list-rest-item.component.css']
})
export class ListRestItemComponent implements OnInit {

  @Input() data: any;

  constructor() { }

  ngOnInit() {
  }

}
