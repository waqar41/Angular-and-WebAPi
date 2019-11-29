import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
//import { DataDetailService } from '../login/login.service';
import {HttpService} from '../http.service';
@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  brews: object;

  constructor(private _http: HttpService) { }

  ngOnInit() {
    
         
      // Simple GET request with response type <any>
      this._http.myMethod().subscribe(data => {
        this.brews = data;
        console.log(this.brews);
      }); 
    }

}
