import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { LeilaoDialogComponent } from './leilao-dialog/leilao-dialog.component';

@Component({
  selector: 'app-leilao',
  templateUrl: './leilao.component.html',
  styleUrls: ['./leilao.component.css']
})
export class LeilaoComponent implements OnInit {

  token : string;
  idUser : string;

  constructor(
    private router: Router,
    public dialog: MatDialog,
  ) { }

  ngOnInit(): void {
    this.token = localStorage.getItem('token');
    if(this.token == null || this.token == undefined)
      this.router.navigate(['']);
  }
  
  openLeilaoDialog(){
    this.dialog.open(LeilaoDialogComponent);
  }
  
  logOut(){
    localStorage.removeItem('token');
    this.router.navigate(['']);
  }

}
