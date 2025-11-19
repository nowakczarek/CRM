import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Contact, FormContact } from '../models/contact.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  private apiUrl = environment.apiBaseUrl + 'contacts'
  private http = inject(HttpClient)

  getAll() : Observable<Contact[]>{
    return this.http.get<Contact[]>(`${this.apiUrl}`) 
  }

  getById(id : string) : Observable<Contact>{
    return this.http.get<Contact>(`${this.apiUrl}/${id}`)
  }

  create(contact: FormContact) : Observable<Contact>{
    return this.http.post<Contact>(`${this.apiUrl}`, contact)
  }

  update(contact: FormContact, id: string) : Observable<Contact>{
    return this.http.put<Contact>(`${this.apiUrl}/${id}`, contact)
  }

  delete(id: string) : Observable<void>{
    return this.http.delete<void>(`${this.apiUrl}/${id}`)
  }
  
}
