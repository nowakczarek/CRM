import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Company, FormCompany } from '../models/company.model';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  private apiUrl = environment.apiBaseUrl +'companies'
  private http = inject(HttpClient)

  getAll() : Observable<Company[]>{
    return this.http.get<Company[]>(`${this.apiUrl}`)
  }

  getById(id: string): Observable<Company>{
    return this.http.get<Company>(`${this.apiUrl}/${id}`)
  }

  create(company: FormCompany): Observable<Company> {
    return this.http.post<Company>(`${this.apiUrl}`, company)
  }

  update(id: string, company: FormCompany): Observable<Company>{
    return this.http.put<Company>(`${this.apiUrl}/${id}`, company)
  }

  delete(id: string): Observable<void>{
    return this.http.delete<void>(`${this.apiUrl}/${id}`)
  }
}
