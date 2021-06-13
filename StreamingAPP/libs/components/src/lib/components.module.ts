import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { CardListComponent } from './card-list/card-list.component';
import { HeaderComponent } from './header/header.component';
import { InputComponent } from './input/input.component';
import { LabelComponent } from './label/label.component';

const COMPONENTS = [
  CardListComponent,
  HeaderComponent,
  InputComponent,
  LabelComponent
];

@NgModule({

  declarations: [COMPONENTS, ],
  imports:[CommonModule],
  exports:[COMPONENTS]
})
export class JfvComponentsModule { }
