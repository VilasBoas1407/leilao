import { Component, OnInit } from '@angular/core';
import { LeilaoResponse } from 'src/app/shared/model/leilao.model';
import { LeilaoService } from 'src/app/shared/service/leilao.service';



@Component({
  selector: 'app-list-leilao',
  templateUrl: './list-leilao.component.html',
  styleUrls: ['./list-leilao.component.css']
})
export class ListLeilaoComponent implements OnInit {

  public lstLeiloes : LeilaoResponse[];


  constructor(
    public leilaoService : LeilaoService
  ) { }

  ngOnInit(): void {
    this.getLeiloes();
  }

  getLeiloes(){
    this.leilaoService.getAll().subscribe(data =>{
      console.log(data);
    })
  }


}
