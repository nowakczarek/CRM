import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CompanyService } from '../../../services/company.service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './form.html',
  styleUrl: './form.css'
})
export class Form {
  private router = inject(Router)
  private route = inject(ActivatedRoute)
  private companyService = inject(CompanyService)

  id? : string
  editing = false

  companyForm = new FormGroup({
    name: new FormControl<string>('', {validators: Validators.required, nonNullable: true}),
    industry: new FormControl<string | null>(null),
    nip: new FormControl<string>('', {validators: Validators.required, nonNullable:true}),
    website: new FormControl<string | null>(null),
    phoneNumber: new FormControl<string | null>(null),
    address: new FormControl<string | null>(null),
  })

  ngOnInit(){
    this.id = this.route.snapshot.paramMap.get('id') ?? undefined

    if(this.id){
      this.editing = true
      this.companyService.getById(this.id).subscribe(company =>
        this.companyForm.patchValue(company)
        )
    }
  }

  save(){
    console.log("save clicked")
    console.log("valid:", this.companyForm.valid)
    console.log(this.companyForm.value)
    if(this.companyForm.invalid) return

    if(this.editing && this.id){
      this.companyService.update(this.id, this.companyForm.getRawValue()).subscribe(() => {
        this.router.navigate(['/companies'])
      })
    } else {
      this.companyService.create(this.companyForm.getRawValue()).subscribe(() => {
        this.router.navigate(['/companies'])
      })
    }
  }

  cancel(){
    this.router.navigate(['/companies'])
  }

}
