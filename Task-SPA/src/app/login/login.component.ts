import { Component, OnInit } from '@angular/core';
import { ActorService } from '../actor.service';
import { Globals } from '../globals';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private service:ActorService,private globals:Globals) { }

  ngOnInit() {

  }


  Login(){
    this.service.loginActor().subscribe(
      (response:any) => {localStorage.setItem('token',response.token); this.globals.role=true;},
      err => {console.log(err);}
    );
    this.service.actor.name=null;
    this.service.actor.password=null;



  }

}
