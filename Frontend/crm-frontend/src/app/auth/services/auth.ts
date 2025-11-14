import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

interface LoginResponse {
  token: string
}

@Injectable({
  providedIn: 'root'
})
export class Auth {
  private apiUrl = 'https://localhost:7058/api/auth'

  constructor(private http: HttpClient) {}

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
