import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MoviesRoutingModule } from './movies-routing.module';
import { MoviesComponent } from './movies.component';
import { JfvComponentsModule } from '@jfloresv/components';
import { MovieListComponent } from './movie-list/movie-list.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [MoviesComponent, MovieListComponent],
  imports: [
    CommonModule,
    MoviesRoutingModule,
    JfvComponentsModule,
    FormsModule
  ],
  exports:[
    MovieListComponent
  ]
})
export class MoviesModule { }
