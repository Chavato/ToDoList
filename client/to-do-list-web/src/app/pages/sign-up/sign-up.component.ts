import { Component } from '@angular/core';
import { DefaultLoginLayoutComponent } from '../../components/default-login-layout/default-login-layout.component';
import { PrimaryInputComponent } from '../../components/primary-input/primary-input.component';
import { Router } from '@angular/router';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { UserRegister } from '../../models/user/user-register';
import { LoginService } from '../../services/login.service';
import { tap } from 'rxjs';

@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [
    DefaultLoginLayoutComponent,
    PrimaryInputComponent,
    ReactiveFormsModule,
  ],
  providers: [ToastrService, LoginService],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.scss',
})
export class SignUpComponent {
  signInForm!: FormGroup;

  hidePassword: boolean = true;

  constructor(
    private router: Router,
    private toastService: ToastrService,
    private loginService: LoginService
  ) {
    this.signInForm = new FormGroup({
      userName: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [
        Validators.minLength(4),
        Validators.required,
      ]),
      confirmPassword: new FormControl('', [
        Validators.minLength(4),
        Validators.required,
      ]),
    });
  }

  navigate() {
    this.router.navigate(['login']);
  }

  submit() {
    const userRegister: UserRegister = {
      userName: this.signInForm.value.userName,
      email: this.signInForm.value.email,
      password: this.signInForm.value.password,
      confirmPassword: this.signInForm.value.confirmPassword,
    };

    this.loginService.register(userRegister).subscribe({
      next: (value) => {
        this.router.navigate(['/login']);
        this.toastService.success(value);
      },
      error: (error) => this.toastService.error(error.error.detail),
    });
  }
}
