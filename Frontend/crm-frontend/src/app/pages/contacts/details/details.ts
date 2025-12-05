import { Component, inject } from '@angular/core';
import { ContactService } from '../../../services/contact.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactWithCompanyName } from '../../../models/contact.model';
import { ActivityService } from '../../../services/activity.service';
import { FullActivity } from '../../../models/activity.model';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-details',
  imports: [MatButtonModule, MatCardModule, DatePipe],
  templateUrl: './details.html',
  styleUrl: './details.css'
})
export class Details {
  private contactService = inject(ContactService)
  private activityService = inject(ActivityService)

  private route = inject(ActivatedRoute)
  private router = inject(Router)

  contact! : ContactWithCompanyName
  activities : FullActivity[] = []

  ngOnInit(){
    const id = this.route.snapshot.paramMap.get('contactId')
    
    if(!id) return

    this.contactService.getById(id).subscribe(contact => {
      this.contact = contact
    })

    this.activityService.getAllByContactId(id).subscribe(activities => {
      this.activities = activities
    })
  }

  addActivity(){
    this.router.navigate(['/companies', this.contact.companyId, 'contacts', this.contact.id, 'activities', 'new'])
  }

  editActivity(id: string){
    this.router.navigate(['/companies', this.contact.companyId, 'contacts', this.contact.id, 'activities', id, 'edit'])
  }

  editContact(){

  }

  goBack(){

  }

  

}
