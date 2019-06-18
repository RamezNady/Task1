import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Actor } from './actor';

@Injectable({
  providedIn: 'root'
})
export class ActorService {


  constructor(private http:HttpClient) {
    
   }

  url:string="http://localhost:5000/api/actor"
  actor1:Actor;
  actor2:Actor;


  registerActor(){
    return this.http.post(this.url+'/register',this.actor1);
  }


  loginActor(){
    return this.http.post(this.url+'/login',this.actor2);
  }



}
