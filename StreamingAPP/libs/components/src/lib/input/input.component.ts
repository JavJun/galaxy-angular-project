import { Component, Input, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'jfv-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.scss']
})
export class InputComponent implements OnInit {

  @Input() brand: string;
  @Input() place: string;

  constructor() { }

  ngOnInit(): void {
  }

}
