import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { FormLead, FullLead, Lead } from '../models/lead.model';

@Injectable({
  providedIn: 'root'
})
export class LeadService {
  private apiUrl = environment.apiBaseUrl + 'leads'
  private http = inject(HttpClient)

  getAll() : Observable<FullLead[]>{
    return this.http.get<FullLead[]>(`${this.apiUrl}`)
  }

  getById(id: string) : Observable<Lead>{
    return this.http.get<Lead>(`${this.apiUrl}/${id}`)
  }
  
  create(lead: FormLead) : Observable<Lead>{
    return this.http.post<Lead>(`${this.apiUrl}`, lead)
  } 

  update(id: string, lead: FormLead) : Observable<Lead>{
    return this.http.put<Lead>(`${this.apiUrl}/${id}`, lead)
  }

  delete(id: string) : Observable<void>{
    return this.http.delete<void>(`${this.apiUrl}/${id}`)
  }
}
