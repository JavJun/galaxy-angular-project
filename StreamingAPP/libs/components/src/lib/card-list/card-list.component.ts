import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'jfv-card-list',
  templateUrl: './card-list.component.html',
  styleUrls: ['./card-list.component.scss']
})
export class CardListComponent implements OnInit {

  @Input() listMovies: [];
  constructor() { }

  ngOnInit(): void {
    console.log('Lib',this.listMovies);
  }

}
