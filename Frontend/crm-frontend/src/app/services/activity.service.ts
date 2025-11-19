import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Activity, FormActivity } from '../models/activity.model';

@Injectable({
  providedIn: 'root'
})
export class ActivityService {
  
  private http = inject(HttpClient)
  private apiUrl = environment.apiBaseUrl + 'activities'

  getAll() : Observable<Activity[]>{
    return this.http.get<Activity[]>(`${this.apiUrl}`)
  }

  getById(id: string) : Observable<Activity>{
    return this.http.get<Activity>(`${this.apiUrl}/${id}`)
  }

  create(activity: FormActivity) : Observable<Activity>{
    return this.http.post<Activity>(`${this.apiUrl}`, activity)
  }

  update(id: string, activity: FormActivity) : Observable<Activity>{
    return this.http.put<Activity>(`${this.apiUrl}/${id}`, activity)
  }

  delete(id: string) : Observable<void>{
    return this.http.delete<void>(`${this.apiUrl}/${id}`)
  }
}
