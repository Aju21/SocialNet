import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerFlag: any = false;
  values: any;

  constructor() { }

  ngOnInit() {
  }

  registerToggle() {
    this.registerFlag = true;
  }

  cancelRegisterMode(registerMode: boolean) {
    this.registerFlag = registerMode;
  }

}
