import { Component, inject } from '@angular/core';
import { CompanyService } from '../../../services/company.service';
import { Router } from '@angular/router';
import { Company } from '../../../models/company.model';

@Component({
  selector: 'app-list',
  imports: [],
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
}
