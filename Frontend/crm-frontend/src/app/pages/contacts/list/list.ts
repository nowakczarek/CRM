import { Component, inject } from '@angular/core';
import { ContactService } from '../../../services/contact.service';
import { ContactWithCompanyName } from '../../../models/contact.model';
import { Router } from '@angular/router';
import { CompanyService } from '../../../services/company.service';
import { Company } from '../../../models/company.model';
import { FormsModule } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';

@Component({
  selector: 'app-list',
  imports: [FormsModule, DatePipe, MatIconModule, MatCardModule, MatMenuModule, MatButtonModule, MatFormFieldModule, MatSelectModule],
  standalone: true,
  templateUrl: './list.html',
  styleUrl: './list.css'
})
export class List {
  private contactService = inject(ContactService)
  private companyService = inject(CompanyService)
  private router = inject(Router)

  contacts: ContactWithCompanyName[] = []
  companies: Company[] = []
  selectedCompanyId: string | null = null;

  ngOnInit(){
    this.contactService.getAll().subscribe(res => {
      this.contacts = res
    })

    this.companyService.getAll().subscribe(res => {
      this.companies = res
    })
  }

  newContact(){
    if(!this.selectedCompanyId) {
      alert("Select a company first!")
      return
    }

    this.router.navigate(['contacts/new'], {
      queryParams: {companyId: this.selectedCompanyId}
    })
  }

  editContact(id: string){
    this.router.navigate(['contacts', id, 'edit'])
  }

  goToCompany(companyId: string){
    this.router.navigate(['/companies', companyId])
  }

  goToDetails(id: string){
    this.router.navigate(['/contacts', id])
  }

}
