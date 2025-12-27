import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ActivityService } from '../../../services/activity.service';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivityType } from '../../../models/enums/activity-type';
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';

@Component({
  selector: 'app-form',
  imports: [ReactiveFormsModule, MatSelectModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatCardModule, MatIconModule],
  templateUrl: './form.html',
  styleUrl: './form.css'
})
export class Form {
  private router = inject(Router)
  private route = inject(ActivatedRoute)
  private activityService = inject(ActivityService)

  activityId?: string
  editing = false

  activityTypes = Object.values(ActivityType).filter(value => typeof value === 'string')

  activityForm = new FormGroup({
    companyId : new FormControl<string>('', {nonNullable: true}),
    contactId : new FormControl<string>('', {nonNullable: true}),
    type : new FormControl<ActivityType>(ActivityType.Other, {nonNullable: true}),
    subject : new FormControl<string>('', {validators: Validators.required, nonNullable: true}),
    description : new FormControl<string | null>('')
  })

  ngOnInit(){
    this.activityId = this.route.snapshot.paramMap.get('activityId') ?? undefined
    const passedCompanyId = this.route.snapshot.paramMap.get('companyId')
    const passedContactId = this.route.snapshot.paramMap.get('contactId')

    if(this.activityId){
      this.editing = true
      this.activityService.getById(this.activityId).subscribe(activity =>
        this.activityForm.patchValue(activity)
      )
    } else if(passedCompanyId && passedContactId){
      this.activityForm.patchValue({companyId: passedCompanyId, contactId: passedContactId})
    }
  }

  save(){
    const payload = this.activityForm.getRawValue()
    console.log(payload)
    this.activityService.create(this.activityForm.getRawValue()).subscribe(() => {
      this.router.navigate(['activities'])
    })
  }

  cancel(){
    this.router.navigate(['/activities'])
  }

  getIndexFromName(name: string): number{
    return ActivityType[name as keyof typeof ActivityType] as number
  }

}
