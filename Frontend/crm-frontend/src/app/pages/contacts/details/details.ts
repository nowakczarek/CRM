import { Component, inject } from '@angular/core';
import { ContactService } from '../../../services/contact.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactWithCompanyName } from '../../../models/contact.model';
import { ActivityService } from '../../../services/activity.service';
import { FullActivity } from '../../../models/activity.model';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { DatePipe } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { ActivityType } from '../../../models/enums/activity-type';

@Component({
  selector: 'app-details',
  imports: [MatButtonModule, MatCardModule, DatePipe, MatIconModule, MatToolbarModule],
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

  goToCompany(){
    this.router.navigate(['/companies', this.contact.companyId])
  }


  editContact(){
    this.router.navigate(['/companies', this.contact.companyId, 'contacts', this.contact.id, 'edit'])
  }

  getActivityTypeName(type: number): string {
    return ActivityType[type]
  }

  getActivityIcon(type: number){
    const typeName = ActivityType[type]

    switch(typeName) {
      case 'Call': return 'phone_in_talk';
      case 'Email': return 'mail_outline';
      case 'VideoCall': return 'videocam';
      case 'Meeting': return 'groups';
      default: return 'event_note';
    }
  }

}
