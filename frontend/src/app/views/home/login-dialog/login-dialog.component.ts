import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import { ErrorComponent } from 'src/app/components/modal/error/error.component';
import { UserService } from 'src/app/shared/service/user.service';

@Component({
  selector: 'app-login-dialog',
  templateUrl: './login-dialog.component.html',
  styleUrls: ['./login-dialog.component.css']
})
export class LoginDialogComponent implements OnInit {

  public userForm : FormGroup;

  constructor(
    public dialogLogin: MatDialogRef<LoginDialogComponent>,
    public userService : UserService,
    public dialog: MatDialog,
    private fb : FormBuilder
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

  Register(){
    if(this.userForm.status == "INVALID")
      this.openErrorDialog('Favor preencher todos os campos!')
    else{
      this.userService.register(this.userForm.value).subscribe(result =>{
        console.log(result);
        if(result.valid){
          this.dialogLogin.close(true);
        }
        else{
          this.openErrorDialog(result.message);
          this.dialogLogin.close(true);
        }
      });
    }
  }
  closeDialog(){
    this.dialogLogin.close(true);
  }
}
