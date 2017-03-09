import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'pos-app',
    template: '<router-outlet></router-outlet>',
    providers: []
})
export class AppComponent implements OnInit {

    constructor() {
        console.log('AppComponent -> constructor');
    }

    ngOnInit() {
        console.log('AppComponent -> ngOnInit');
    }
}