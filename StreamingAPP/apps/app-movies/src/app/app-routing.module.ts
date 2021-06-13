import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AutenticaGuard } from './commons/guards/autentica.guard';

const routes: Routes = [
  {
  path: "", canActivate: [AutenticaGuard],
  loadChildren: () => import('./views/views.module').then(m => m.ViewsModule)
  },
  {
    path: "ext",
    loadChildren: () => import("./external/external.module").then(t => t.ExternalModule)
  },
  // { path: 'views', loadChildren: () => import('./views/views.module').then(m => m.ViewsModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
