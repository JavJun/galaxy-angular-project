import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'jfv-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  @Input() brand: string;
  constructor() { }

  ngOnInit(): void {
  }

}
