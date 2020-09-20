import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserResponse } from 'src/app/shared/model/user.model';
import { UserService } from 'src/app/shared/service/user.service';



@Component({
  selector: 'app-list-leilao',
  templateUrl: './list-leilao.component.html',
  styleUrls: ['./list-leilao.component.css']
})
export class ListLeilaoComponent implements OnInit {

  public leilaoForm : FormGroup;
  public lstUsers : UserResponse[];

  constructor(
    private fb : FormBuilder,
    public userService : UserService
  ) { }

  ngOnInit(): void {

    this.leilaoForm = this.fb.group({
        DS_NOME_LEILAO : ['', Validators.required],
        VL_INICIAL : [0, Validators.required],
        FL_PRODUTO_USADO : [0],
        ID_USUARIO_RESPONSAVEL : [0, Validators.required],
        DT_ABERTURA : ['', Validators.required],
        DT_FINALIZACAO : ['', Validators.required]
    });

    this.getUsers();
  }

  getUsers() {
    this.userService.getUsers().subscribe(data => {
      if(data.length > 0){
        this.lstUsers = data;
      }
      else{
        //Erro Dialog
      }
    })
  }

}
