import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { AutenticaRequestModel } from '../models/autentica-request.model';
import { Observable, of, throwError } from 'rxjs';
import { environment } from '../../../../../environments/environment';
import { catchError, map } from "rxjs/operators";
import { AutenticaResponseModel } from '../models/autentica-response.model'
@Injectable({
  providedIn: 'root'
})
export class LoginService {

  urlServicio: string = environment.urlBackend;
  constructor(private http: HttpClient) { }

  autentica(login: AutenticaRequestModel): Observable<AutenticaResponseModel>{

    const ruta : string = `${this.urlServicio}auth`
    let loginJson : string = JSON.stringify(login);

    let misHeaders : HttpHeaders = new HttpHeaders();
    misHeaders = misHeaders.append("Content-Type", "application/json");
    return this.http.post<AutenticaResponseModel>(ruta, loginJson, {headers: misHeaders})
    .pipe(
      catchError(err => {
        if (err === 400){
          //return throwError("Error al autenticar las credenciales");
          return of([]);
        }
        return throwError(err);

      }),
      map((rpta: any) => {
        return {
          token: rpta.token,
          codigo: rpta.idUsuario
        }
      })
    );

  }
}
