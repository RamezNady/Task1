import { Injectable } from '@angular/core';
import { User } from './user.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }

  url:string="http://localhost:5000/api/User"
  users:User[];
  user:User;
  s:boolean=true;


  

  getAllUsers(){
    this.http.get(this.url).toPromise().then(
      res=> {this.users = res as User[];}
    )
  }

  postUser(){
    return this.http.post(this.url,this.user);
  }


  putUser(){
    return this.http.put(this.url+"/" + this.user.id, this.user);
  }


  deleteUser(id){
    return this.http.delete(this.url+"/" + id);
  }


}
