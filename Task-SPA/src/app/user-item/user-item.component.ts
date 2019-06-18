import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-user-item',
  templateUrl: './user-item.component.html',
  styleUrls: ['./user-item.component.css']
})
export class UserItemComponent implements OnInit {

  constructor(private service:UserService) { }

  ngOnInit() {
    this.service.user={
      id : 0,
      name :null,
      state :true
    }
  }


  mySubmit()
  {
    if(this.service.user.id==0)
    {
      this.service.postUser().subscribe(
        resolve => {alert("Done");this.service.getAllUsers()},
        err => {console.log(err)}
      )
    }
    else
    {
      this.service.putUser().subscribe(
        res => {this.service.getAllUsers()},
        err => {console.log(err)}
      )    
    }
  }
}
