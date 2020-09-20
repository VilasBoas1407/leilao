import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

//Page Components
import { HomeComponent } from './views/home/home.component';
import { LeilaoComponent } from './views/leilao/leilao.component';


const routes: Routes = [
  {
    path: '',
    component : HomeComponent
  },
  {
    path:'leilao',
    component: LeilaoComponent
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
