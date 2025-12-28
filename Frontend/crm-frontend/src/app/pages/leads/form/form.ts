import { Component, inject } from '@angular/core';
import { LeadService } from '../../../services/lead.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { LeadStage } from '../../../models/enums/lead-stage';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatOptionModule } from '@angular/material/core';
import { MatIconModule } from '@angular/material/icon';
import { CompanyService } from '../../../services/company.service';
import { ContactService } from '../../../services/contact.service';
import { Company } from '../../../models/company.model';
import { Contact } from '../../../models/contact.model';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-form',
  imports: [ReactiveFormsModule, MatCardModule, MatFormFieldModule, MatOptionModule, MatIconModule, MatInputModule, MatSelectModule, MatButtonModule],
  templateUrl: './form.html',
  styleUrl: './form.css'
})
export class Form {

  private leadService = inject(LeadService)
  private companyService = inject(CompanyService)
  private contactService = inject(ContactService)
  private router = inject(Router)
  private route = inject(ActivatedRoute)

  editing = false
  leadId? : string
  leadStages = Object.values(LeadStage).filter(value => typeof value === 'string')

  companies: Company[] = []
  contacts: Contact[] = []
  filteredContacts: Contact[] = []

  leadForm = new FormGroup({
    companyId: new FormControl<string>('', {validators: Validators.required, nonNullable: true}),
    contactId: new FormControl<string>('', {validators: Validators.required, nonNullable: true}),
    title: new FormControl<string>('', {validators: Validators.required, nonNullable: true}),
    value: new FormControl<number>(0, {validators: Validators.required, nonNullable: true}),
    stage: new FormControl<LeadStage>(LeadStage.New, {validators: Validators.required, nonNullable: true})
  })

  ngOnInit(){
    this.loadDropdownData()
    this.setupLogic()

    this.leadForm.get('companyId')?.valueChanges.subscribe(companyId => {
      this.filterContactsByCompany(companyId)
    })
    
  }

  private loadDropdownData() {
    this.companyService.getAll().subscribe(r => this.companies = r)
    this.contactService.getAll().subscribe(r => {
      this.contacts = r
      if(this.leadForm.get('companyId')?.value){
        this.filterContactsByCompany(this.leadForm.get('companyId')?.value!)
      }
    })
  }

  private filterContactsByCompany(companyId: string){
    this.filteredContacts = this.contacts.filter(c => c.companyId === companyId)
  }

  private setupLogic() {
    this.leadId = this.route.snapshot.paramMap.get('leadId') ?? undefined
    const passedCompanyId = this.route.snapshot.paramMap.get('companyId')
    const passedContactId = this.route.snapshot.paramMap.get('contactId')

    if(this.leadId){
      this.editing = true
      this.leadService.getById(this.leadId).subscribe(r =>
        this.leadForm.patchValue(r)
      )
    } else if(passedCompanyId && passedContactId){
      this.leadForm.patchValue({companyId: passedCompanyId, contactId: passedContactId})
      this.leadForm.get('companyId')?.disable()
      this.leadForm.get('contactId')?.disable()
    }

  }

  save(){

    if(this.editing){
      this.leadService.update(this.leadId!, this.leadForm.getRawValue()).subscribe(() =>
        this.router.navigate([''])
      )
    } else {
      this.leadService.create(this.leadForm.getRawValue()).subscribe(() =>
        this.router.navigate([''])
      )
    }
  }

  cancel(){
    this.router.navigate(['/leads'])
  }

  
getIndexFromLeadStage(name: string): number {
  return LeadStage[name as keyof typeof LeadStage] as number
}


}
