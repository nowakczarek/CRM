import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

interface LoginResponse {
  token: string
}

@Injectable({
  providedIn: 'root'
})
export class Auth {
  private apiUrl = environment.apiBaseUrl + 'auth'
  private http = inject(HttpClient)

  login(email: string, password: string) : Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.apiUrl}/login`, { email , password })
  }

  logout() {
    localStorage.removeItem('token');
  }

  saveToken(token: string) {
    localStorage.setItem('token', token)
  }

  getToken(): string | null {
    return localStorage.getItem('token')
  }

  isLoggedIn() : boolean {
    return !!this.getToken()
  }

}
