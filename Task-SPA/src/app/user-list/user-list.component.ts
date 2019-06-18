import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  constructor(private service:UserService) { }

  ngOnInit() {
    this.service.getAllUsers();
  }


  fillData(item){
    this.service.user.id = item.id;
    this.service.user.name = item.name;
    this.service.user.statue= item.statue;
  }

  delete(id){
    this.service.deleteUser(id).subscribe(
      res => {this.service.getAllUsers()},
      err => {console.log(err)}
    )
  }




}
