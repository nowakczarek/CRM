import { Component, inject } from '@angular/core';
import { CompanyService } from '../../../services/company.service';
import { ContactService } from '../../../services/contact.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Company } from '../../../models/company.model';
import { Contact } from '../../../models/contact.model';

@Component({
  selector: 'app-details',
  imports: [],
  standalone: true,
  templateUrl: './details.html',
  styleUrl: './details.css'
})
export class Details {
  private companyService = inject(CompanyService)
  private contactService = inject(ContactService)
  private router = inject(Router)
  private route = inject(ActivatedRoute)
  
  company! : Company
  contacts: Contact[] = []

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id')
    if (!id) return

    this.companyService.getById(id).subscribe(company => {
      this.company = company
    })

    this.contactService.getByCompanyId(id).subscribe(contacts =>{
      this.contacts = contacts
    })
  }

  addContact(){
    this.router.navigate(['/contacts/new'], {queryParams: {companyId: this.company.id}})
  }

  editCompany(){
    this.router.navigate(['companies', this.company.id, 'edit'])
  }

  goToContact(id: string){
    this.router.navigate(['contacts', id])
  }

}
