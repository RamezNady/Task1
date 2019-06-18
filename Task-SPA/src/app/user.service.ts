import { Injectable } from '@angular/core';
import { User } from './user.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { localStorage.setItem('flag',null); }

  url:string="http://localhost:5000/api/User"
  users:User[];
  user:User;
  flag = localStorage.getItem('flag');
  

  token : any = localStorage.getItem('token');
  headers_object:any = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': "Bearer "+this.token
  });
  

  

  getAllUsers(){
    this.http.get(this.url,{headers:this.headers_object}).toPromise().then(
      res=> {this.users = res as User[];}
    )
  }

  postUser(){
    return this.http.post(this.url,this.user,{headers:this.headers_object});
  }


  putUser(){
    return this.http.put(this.url+"/" + this.user.id, this.user,{headers:this.headers_object});
  }


  deleteUser(id){
    return this.http.delete(this.url+"/" + id,{headers:this.headers_object});
  }


}
