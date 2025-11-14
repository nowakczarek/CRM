import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Auth } from '../services/auth';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {

  constructor(private authService: Auth, private router: Router) {}

  email = ''
  password = ''
  error = ''

  onSubmit () {
    this.authService.login(this.email, this.password).subscribe({
      next: (res) => {
        this.authService.saveToken(res.token)
        this.router.navigate(['dashboard'])
      },
      error: () => (this.error = 'Invalid email or password')
    })
  }

}
