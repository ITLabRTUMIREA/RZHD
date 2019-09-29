import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-menu-rest',
  templateUrl: './menu-rest.component.html',
  styleUrls: ['./menu-rest.component.css']
})
export class MenuRestComponent implements OnInit {

  data = {title: "Шаурма Хауз", img: 'шаурма'};

  constructor() { }

  ngOnInit() {
  }

}
