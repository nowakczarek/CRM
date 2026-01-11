import { Component, inject } from '@angular/core';
import { CompanyService } from '../../../services/company.service';
import { ContactService } from '../../../services/contact.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Company } from '../../../models/company.model';
import { Contact } from '../../../models/contact.model';
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { LeadService } from '../../../services/lead.service';
import { Lead } from '../../../models/lead.model';
import { LeadStage } from '../../../models/enums/lead-stage';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-details',
  imports: [MatCardModule, MatButtonModule, MatIconModule, MatToolbarModule, DatePipe],
  standalone: true,
  templateUrl: './details.html',
  styleUrl: './details.css'
})
export class Details {
  private companyService = inject(CompanyService)
  private contactService = inject(ContactService)
  private leadService = inject(LeadService)

  private router = inject(Router)
  private route = inject(ActivatedRoute)
  
  company! : Company
  contacts: Contact[] = []
  leads: Lead[] = []

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('companyId')
    if (!id) return

    this.companyService.getById(id).subscribe(company => {
      this.company = company
    })

    this.contactService.getByCompanyId(id).subscribe(contacts =>{
      this.contacts = contacts
    })

    this.leadService.getByCompanyId(id).subscribe(leads => {
      this.leads = leads
    })
  }

  addContact(){
    this.router.navigate(['/contacts/new'], {queryParams: {companyId: this.company.id}})
  }

  editCompany(){
    this.router.navigate(['companies', this.company.id, 'edit'])
  }

  goToContact(id: string){
    this.router.navigate(['companies', this.company.id, 'contacts', id])
  }

  addLead(){
    this.router.navigate(['/leads/new'], {queryParams: {companyId: this.company.id}})
  }

  getStageClass(stage: LeadStage): string {
    switch (stage) {
      case LeadStage.New: return 'stage-new';
      case LeadStage.Negotiations: return 'stage-negotiations';
      case LeadStage.Won: return 'stage-won';
      case LeadStage.Lost: return 'stage-lost';
      default: return '';
    }
  }

  getStageName(stage: LeadStage): string {
    return LeadStage[stage]; 
  }

}
