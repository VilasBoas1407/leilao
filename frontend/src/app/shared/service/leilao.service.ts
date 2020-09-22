import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LeilaoResponse } from '../model/leilao.model';
import { ListLeilaoResponse } from '../model/list-leilao.model';

@Injectable({
  providedIn: 'root'
})
export class LeilaoService {

  apiUrl = 'https://localhost:44344/api/';

  httpOptions = {
    headers : new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };
  
  constructor(
    private httpClient: HttpClient
  ) { }

  public register(Leilao: any) : Observable<LeilaoResponse>{
    return this.httpClient.post<LeilaoResponse>(this.apiUrl+'leilao', Leilao, this.httpOptions);
  }

  public getAll() : Observable<ListLeilaoResponse>{
    return this.httpClient.get<ListLeilaoResponse>(this.apiUrl + 'leilao/GetAll');
  }

  public delete(ID_LEILAO: number) {
      return this.httpClient.delete(this.apiUrl + 'leilao?ID_LEILAO=' + ID_LEILAO);
  }

  public update(Leilao: any){
    return this.httpClient.put(this.apiUrl + 'leilao', Leilao,this.httpOptions);
  }
}
