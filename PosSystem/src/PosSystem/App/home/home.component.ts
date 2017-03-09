import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'home',
    templateUrl:'app/home/home.html'
})
export class HomeComponent implements OnInit {

    constructor() {
        console.log('HomeComponent -> constructor');

    }

    ngOnInit() {
        console.log('HomeComponent -> ngOnInit');

    }
}