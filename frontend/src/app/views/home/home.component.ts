import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ErrorComponent } from 'src/app/components/modal/error/error.component';
import { UserResponse } from 'src/app/shared/model/user.model';

import { UserService } from 'src/app/shared/service/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})



export class HomeComponent implements OnInit {

  user : UserResponse;
  public userForm : FormGroup;


  constructor(
    private fb : FormBuilder,
    public userService : UserService,
    public dialog: MatDialog,
  ) { }

  ngOnInit(): void {
    this.userForm = this.fb.group({
      DS_USUARIO : ['',[Validators.required]],
      DS_SENHA : ['',[Validators.required]]
    });
  }

  openErrorDialog(message : string) {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.data = {
      message: message
    }
    this.dialog.open(ErrorComponent,dialogConfig);

  }

  doLogin(){
    if(this.userForm.status == "INVALID")
      this.openErrorDialog('Favor preencher todos os campos!')
    else{
      this.userService.doLogin(this.userForm.value.DS_USUARIO,this.userForm.value.DS_SENHA).subscribe(data =>{
        console.log(data);
        if(data.valid){
          this.user = data;
        }
        else{
         this.openErrorDialog(data.message)
        }
      });
    }
  }

}
