import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ListUserResponse } from 'src/app/shared/model/list-user.model';
import { UserResponse } from 'src/app/shared/model/user.model';
import { LeilaoService } from 'src/app/shared/service/leilao.service';
import { UserService } from 'src/app/shared/service/user.service';

@Component({
  selector: 'app-leilao-dialog',
  templateUrl: './leilao-dialog.component.html',
  styleUrls: ['./leilao-dialog.component.css']
})
export class LeilaoDialogComponent implements OnInit {

  public leilaoForm : FormGroup;
  public lstUsers : ListUserResponse;
  public leilao : any;

  labelButton : string;
  dataInicio : any;
  dataFim : any;

  constructor(
    private fb : FormBuilder,
    public userService : UserService,
    public leilaoService : LeilaoService,
    public dialog: MatDialog,
    public dialogRegister: MatDialogRef<LeilaoDialogComponent>,
    @Inject(MAT_DIALOG_DATA) data) {
      if(data != null)
        this.leilao = data.leilaoData;
   }

  ngOnInit(): void {

    if(this.leilao != null){

      this.labelButton = 'Atualizar';
      this.leilaoForm = this.fb.group({
        ID_LEILAO : [this.leilao.ID_LEILAO],
        DS_NOME_LEILAO : [this.leilao.DS_NOME_LEILAO, Validators.required],
        VL_INICIAL : [ this.leilao.VL_INICIAL, Validators.required],
        FL_PRODUTO_USADO : [this.leilao.FL_PRODUTO_USADO],
        ID_USUARIO_RESPONSAVEL : [this.leilao.ID_USUARIO_RESPONSAVEL, Validators.required],
        DT_ABERTURA : [this.leilao.DT_ABERTURA, Validators.required],
        DT_FINALIZACAO : [this.leilao.DT_FINALIZACAO, Validators.required]
      });
    }
    else{
      this.labelButton = 'Cadastrar';
      this.leilaoForm = this.fb.group({
        DS_NOME_LEILAO : ['', Validators.required],
        VL_INICIAL : [, Validators.required],
        FL_PRODUTO_USADO : [0],
        ID_USUARIO_RESPONSAVEL : [0, Validators.required],
        DT_ABERTURA : ['', Validators.required],
        DT_FINALIZACAO : ['', Validators.required]
      });
    }
    this.getUsers();
  }

  closeDialog(){
    window.location.reload();
    this.dialogRegister.close(true);
  }
  
  getUsers() {
    this.userService.getUsers().subscribe(data => {
        this.lstUsers = data;
    })
  }

  Register(){

    if(this.leilaoForm.valid){  

      var DT_ABERTURA = this.leilaoForm.value.DT_ABERTURA.split('/');
      var DT_FINALIZACAO = this.leilaoForm.value.DT_FINALIZACAO.split('/');
      this.leilaoForm.value.DT_ABERTURA = new Date(DT_ABERTURA[2], DT_ABERTURA[1] - 1, DT_ABERTURA[0]); 
      this.leilaoForm.value.DT_FINALIZACAO = new Date(DT_FINALIZACAO[2], DT_FINALIZACAO[1] - 1, DT_FINALIZACAO[0]); 
      
      if(this.labelButton == 'Cadastrar'){
        this.leilaoService.register(this.leilaoForm.value).subscribe(result =>{
          window.location.reload();
          this.dialogRegister.close(true);
        });
      }
      else{
        this.leilaoService.update(this.leilaoForm.value).subscribe(result =>{
          window.location.reload();
          this.dialogRegister.close(true);
        });
      }
    }
   
  }
}
