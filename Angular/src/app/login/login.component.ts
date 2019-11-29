import { Component, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
    providedIn: 'root'
})

@Component({ templateUrl: 'login.component.html' })
export class LoginComponent {
    readonly rootURL = 'http://localhost:56115/api';
    list: LoginComponent[];
    constructor(private http:HttpClient){}
    Details(){
        this.http.get(this.rootURL +'DataDetails')
        .toPromise()
        .then(res => this.list = res as LoginComponent[])

    }
}


