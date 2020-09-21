import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ListUserResponse } from '../model/list-user.model';
import { MessageResponse } from '../model/message.model';
import { UserResponse } from '../model/user.model';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  apiUrl = 'https://localhost:44344/api/';

  httpOptions = {
    headers : new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(
    private httpClient: HttpClient
  ) { }

  public doLogin(DS_USUARIO: string, DS_SENHA: string): Observable<UserResponse> {
    return this.httpClient.get<UserResponse>(this.apiUrl + `user?DS_USUARIO=${DS_USUARIO}&DS_SENHA=${DS_SENHA}`)
  }

  public register(User: any): Observable<MessageResponse>{
    return this.httpClient.post<MessageResponse>(this.apiUrl + 'user',User,this.httpOptions);
  }
  public getUsers() : Observable<ListUserResponse>{
    return this.httpClient.get<ListUserResponse>(this.apiUrl+ 'users');
  }
}
