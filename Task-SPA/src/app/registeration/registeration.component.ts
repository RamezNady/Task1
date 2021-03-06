import { Component, OnInit } from '@angular/core';
import { ActorService } from '../actor.service';

@Component({
  selector: 'app-registeration',
  templateUrl: './registeration.component.html',
  styleUrls: ['./registeration.component.css']
})
export class RegisterationComponent implements OnInit {

  constructor(private service:ActorService) { }

  ngOnInit() {
    this.service.actor={
      name :null,
      password :null
    }
  }

  Regist(){
    this.service.registerActor().subscribe(
      response => {alert("You are Registered Now");},
      err => {console.log(err)}
    )
  }



}
