import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { LeilaoResponse } from 'src/app/shared/model/leilao.model';
import { LeilaoService } from 'src/app/shared/service/leilao.service';
import { LeilaoDialogComponent } from '../leilao-dialog/leilao-dialog.component';



@Component({
  selector: 'app-list-leilao',
  templateUrl: './list-leilao.component.html',
  styleUrls: ['./list-leilao.component.css']
})
export class ListLeilaoComponent implements OnInit {

  public lstLeiloes : LeilaoResponse[];
  dataInicio : any;
  dataFim : any;
  displayedColumns: string[] = ['DS_NOME_LEILAO', 'DS_NOME_RESPONSAVEL','DT_ABERTURA','DT_FINALIZACAO', 'FL_PRODUTO_USUADO', 'VL_INICIAL', 'DELETE', 'UPDATE'];

  constructor(
    public leilaoService : LeilaoService,
    public dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getLeiloes();
  }

  getLeiloes(){
    this.leilaoService.getAll().subscribe(data =>{
  
      this.lstLeiloes = data.lstLeilao;
      this.lstLeiloes.forEach(element => {
        this.dataInicio = new Date(element.DT_ABERTURA);
        this.dataFim = new Date(element.DT_FINALIZACAO);
        element.DT_ABERTURA = this.dataInicio.toLocaleDateString();
        element.DT_FINALIZACAO = this.dataFim.toLocaleDateString();
      });
    });
  };

  deleteLeilao(ID_LEILAO : number){
    //Implementar mensagem de error se der tempo
    this.leilaoService.delete(ID_LEILAO).subscribe();
    this.getLeiloes();
    window.location.reload();
  }

  editLeilao(Leilao : any){
    const dialogConfig = new MatDialogConfig();

    dialogConfig.data = {
      leilaoData : Leilao
    }

    this.dialog.open(LeilaoDialogComponent, dialogConfig);
  }
}
