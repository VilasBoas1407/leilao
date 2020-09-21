import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LeilaoResponse } from '../model/leilao.model';

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

  public getAll() : Observable<LeilaoResponse[]>{
    return this.httpClient.get<LeilaoResponse[]>(this.apiUrl + 'leilao/GetAll');
  }

}
