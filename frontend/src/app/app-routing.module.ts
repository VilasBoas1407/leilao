import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';




//Page Components
import { HomeComponent } from './views/home/home.component';

const routes: Routes = [
  {
    path: '',
    component : HomeComponent
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
