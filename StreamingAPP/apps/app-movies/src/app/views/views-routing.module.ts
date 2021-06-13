import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ViewsComponent } from './views.component';

// const routes: Routes = [{ path: '', component: ViewsComponent }];

const routes: Routes = [
  {
    path: "", component: ViewsComponent, children: [
      {
        path: "movies",
        loadChildren: () => import("./movies/movies.module").then(t => t.MoviesModule)
      }
    ]
  }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ViewsRoutingModule { }
