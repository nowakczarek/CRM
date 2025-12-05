import { Component, inject } from '@angular/core';
import { ContactService } from '../../../services/contact.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-form',
  imports: [ReactiveFormsModule],
  templateUrl: './form.html',
  standalone: true,
  styleUrl: './form.css'
})
export class Form {
  private contactService = inject(ContactService)
  private route = inject(ActivatedRoute)
  private router = inject(Router)

  id?: string
  editing = false

  contactForm = new FormGroup({
    companyId: new FormControl<string>(``, {nonNullable: true}),
    firstName: new FormControl<string>('', {validators: Validators.required, nonNullable: true}),
    lastName: new FormControl<string>('', {validators: Validators.required, nonNullable: true}),
    email: new FormControl<string>(''),
    phoneNumber: new FormControl<string>(''),
    position: new FormControl<string>('')
  })
  
  ngOnInit(){
    this.id = this.route.snapshot.paramMap.get('contactId') ?? undefined

    const passedCompanyId = this.route.snapshot.queryParamMap.get('companyId')

    if(this.id){
      this.editing = true;
      this.contactService.getById(this.id).subscribe(contact =>
        this.contactForm.patchValue(contact)
      );
    } else if(passedCompanyId){
      this.contactForm.patchValue({ companyId: passedCompanyId });
    }
    
  }

  save(){
    if(this.contactForm.invalid) return

    if(this.editing && this.id){
      this.contactService.update(this.contactForm.getRawValue(), this.id).subscribe(() => {
        this.router.navigate(['/contacts'])
      })
    } else {
      this.contactService.create(this.contactForm.getRawValue()).subscribe(() => {
        this.router.navigate(['/contacts'])
      })
    }
  }

  cancel(){
    this.router.navigate(['/contacts'])
  }
}
