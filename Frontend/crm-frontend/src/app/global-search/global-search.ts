import { Component, inject } from '@angular/core';
import { Search } from '../services/search';
import { Router } from '@angular/router';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { debounceTime, distinctUntilChanged, of, switchMap } from 'rxjs';
import { GlobalSearchDto } from '../models/search.model';
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { MatAutocompleteModule } from '@angular/material/autocomplete';

@Component({
  selector: 'app-global-search',
  imports: [MatFormFieldModule, MatIconModule, MatInputModule, ReactiveFormsModule, MatAutocompleteModule],
  templateUrl: './global-search.html',
  styleUrl: './global-search.css'
})
export class GlobalSearch {
  private searchService = inject(Search)
  private router = inject(Router)

  searchControl = new FormControl('')
  results: GlobalSearchDto | null = null

  ngOnInit() {
    this.searchControl.valueChanges.pipe(
      debounceTime(500),
      distinctUntilChanged(),
      switchMap(value => {
        if(!value || value.length < 2) return of(null)
        return this.searchService.searchGlobal(value)
      })
    ).subscribe(res => this.results = res)
  }

  onSearch(type: string, id: string) {
    this.router.navigate([`/${type}`, id])
    this.searchControl.setValue('', {emitEvent: false})
  }

}
