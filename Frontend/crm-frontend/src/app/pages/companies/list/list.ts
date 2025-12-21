import { Component, inject } from '@angular/core';
import { CompanyService } from '../../../services/company.service';
import { Router } from '@angular/router';
import { Company } from '../../../models/company.model';
import { DatePipe } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from "@angular/material/button";

@Component({
  selector: 'app-list',
  imports: [DatePipe, MatIconModule, MatCardModule, MatMenuModule, MatButtonModule],
  standalone: true,
  templateUrl: './list.html',
  styleUrl: './list.css'
})
export class List {
  private companyService = inject(CompanyService)
  private router = inject(Router)

  companies: Company[] = []

  ngOnInit() {
    this.companyService.getAll().subscribe(res => {
      this.companies = res
    })
  }

  goToCompany(id: string) {
    this.router.navigate(['/companies', id])
  }

  newCompany() {
    this.router.navigate(['/companies/new'])
  }
  
  editCompany(id: string) {
    this.router.navigate(['/companies', id, 'edit']);
  }
}
