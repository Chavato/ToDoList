import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginResponse } from '../types/login-response.type';
import { tap } from 'rxjs';
import { environment } from '../../environments/environment';

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

  changePassword(oldPassword: string, newPassword: string) {
    return this.httpClient
      .put<LoginResponse>(this.url + '/User/ChangePassword', {
        oldPassword,
        newPassword,
      })
      .pipe(
        tap(() => {
        })
      );
  }
}
