import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'jfv-label',
  templateUrl: './label.component.html',
  styleUrls: ['./label.component.scss']
})
export class LabelComponent implements OnInit {

  @Input() brand: string;
  constructor() { }

  ngOnInit(): void {
  }

}
