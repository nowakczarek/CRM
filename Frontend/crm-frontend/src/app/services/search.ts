import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { GlobalSearchDto } from '../models/search.model';

@Injectable({
  providedIn: 'root'
})
export class Search {
  private apiUrl = environment.apiBaseUrl + 'search'
  private httpClient = inject(HttpClient)

  searchGlobal(phrase: string): Observable<GlobalSearchDto> {
    return this.httpClient.get<GlobalSearchDto>(`${this.apiUrl}/search=${phrase}`)
  }
}
