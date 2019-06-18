import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { Globals } from '../globals';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  constructor(private service:UserService,private globals:Globals) { }

  ngOnInit() {
    this.service.getAllUsers();
    if (!this.globals.role) {
      this.service.token = '';
    }
  }


  fillData(item){
    this.service.user.id = item.id;
    this.service.user.name = item.name;
    this.service.user.state= item.state;
  }

  delete(id){
    this.service.deleteUser(id).subscribe(
      res => {this.service.getAllUsers()},
      err => {console.log(err)}
    )
  }




}
