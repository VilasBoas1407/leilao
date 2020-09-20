import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-login-dialog',
  templateUrl: './login-dialog.component.html',
  styleUrls: ['./login-dialog.component.css']
})
export class LoginDialogComponent implements OnInit {

  constructor(
    public dialogLogin: MatDialogRef<LoginDialogComponent>
  ) { }

  ngOnInit(): void {
  }
  closeDialog(){
    this.dialogLogin.close(true);
  }
}