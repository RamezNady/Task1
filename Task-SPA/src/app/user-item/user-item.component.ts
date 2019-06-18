import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { Globals } from '../globals';

@Component({
  selector: 'app-user-item',
  templateUrl: './user-item.component.html',
  styleUrls: ['./user-item.component.css']
})
export class UserItemComponent implements OnInit {

  constructor(private service:UserService,private globals:Globals) { }

  ngOnInit() {
    this.service.user={
      id : 0,
      name :null,
      state :true
    }

    if (!this.globals.role) {
      this.service.token = '';
    }
  }





  mySubmit()
  {
    if(this.service.user.id==0)
    {
      this.service.postUser().subscribe(
        resolve => {this.service.getAllUsers()},
        err => {console.log(err)}
      )
      this.service.user={
        id : 0,
        name :null,
        state :true
      }
    }
    else
    {
      this.service.putUser().subscribe(
        res => {this.service.getAllUsers()},
        err => {console.log(err)}
      )    
      this.service.user={
        id : 0,
        name :null,
        state :true
      }
      }
  }


  Logout(){
    this.globals.role = false;
  }
}
