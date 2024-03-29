import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginResponse } from '../models/user/login-response.type';
import { tap } from 'rxjs';
import { environment } from '../../environments/environment';
import { UserRegister } from '../models/user/user-register';

@Injectable({
  providedIn: 'root',
})
export class LoginService {
  private url: string = environment.api;

  constructor(private httpClient: HttpClient) {}

  login(email: String, password: string) {
    return this.httpClient
      .post<LoginResponse>(this.url + '/User/Login', { email, password })
      .pipe(
        tap((value) => {
          sessionStorage.setItem('auth-token', value.token);
        })
      );
  }

  register(userRegister: UserRegister) {
    return this.httpClient.post<string>(
      this.url + '/User/Register',
      userRegister
    );
  }

  changePassword(oldPassword: string, newPassword: string) {
    return this.httpClient.put<LoginResponse>(
      this.url + '/User/ChangePassword',
      {
        oldPassword,
        newPassword,
      }
    );
  }
}
