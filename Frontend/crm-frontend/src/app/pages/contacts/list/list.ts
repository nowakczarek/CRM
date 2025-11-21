import { Component, inject } from '@angular/core';
import { ContactService } from '../../../services/contact.service';
import { Contact } from '../../../models/contact.model';
import { Router } from '@angular/router';
import { CompanyService } from '../../../services/company.service';
import { Company } from '../../../models/company.model';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-list',
  imports: [FormsModule],
  standalone: true,
  templateUrl: './list.html',
  styleUrl: './list.css'
})
export class List {
  private contactService = inject(ContactService)
  private companyService = inject(CompanyService)
  private router = inject(Router)

  contacts: Contact[] = []
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

  goToCompany(companyId: string){
    this.router.navigate(['/companies', companyId])
  }



}
