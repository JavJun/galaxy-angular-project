import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AutenticaRequestModel } from '../shared/models/autentica-request.model';
import { LoginService } from '../shared/services/login.service'
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  modelo: AutenticaRequestModel = {
    credencial : "",
    clave: ""
  };
  closeModal: string;
  msg:string;
  constructor(private loginService: LoginService, private router: Router,private modalService: NgbModal) { }

  ngOnInit(): void {
  }


  autentica(form: NgForm,content){
    console.log(form)
    this.loginService.autentica(this.modelo).subscribe(
      (resp)=> {
      console.log("respuesta", resp);

      localStorage.setItem("token", JSON.stringify(resp.token));
      this.router.navigate(["movies"]);
    },
    (error)=> { console.warn("ocurrio error", error.error)
                this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((res) => {
                  this.msg=error.error;
                  this.closeModal = `Closed with: ${res}`;
                }, (res) => {
                  this.closeModal = `Dismissed ${this.getDismissReason(res)}`;
                });
              }
    );
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }

}
