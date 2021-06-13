import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ViewsRoutingModule } from './views-routing.module';
import { ViewsComponent } from './views.component';
import { JfvComponentsModule } from '@jfloresv/components';
import { MovieListComponent } from './movies/movie-list/movie-list.component';


@NgModule({
  declarations: [ViewsComponent],
  imports: [
    CommonModule,
    ViewsRoutingModule,
    JfvComponentsModule
  ]
})
export class ViewsModule { }
