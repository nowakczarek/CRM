import { Component, inject } from '@angular/core';
import { ActivityService } from '../../../services/activity.service';
import { Activity, FullActivity } from '../../../models/activity.model';
import { DatePipe } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list',
  imports: [DatePipe],
  templateUrl: './list.html',
  styleUrl: './list.css'
})
export class List {

  private activityService = inject(ActivityService)
  private router = inject(Router)

  activities : FullActivity[] = []

  ngOnInit(){
    this.activityService.getAll().subscribe(res =>
      this.activities = res
    )
  }

  create(){
    this.router.navigate(['/activities/new'])
  }

  editActivity(id: string){
    this.router.navigate(['/activities' + id + 'edit'])
  }

  goToCompany(id : string){

  }

  goToContact(id : string){

  }

}
