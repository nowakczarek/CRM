import { Component, inject } from '@angular/core';
import { ActivityService } from '../../../services/activity.service';
import { Activity, FullActivity } from '../../../models/activity.model';
import { DatePipe } from '@angular/common';
import { Router } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-list',
  imports: [DatePipe, MatCardModule, MatIconModule, MatMenuModule, MatButtonModule],
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
    this.router.navigate(['activities', id, 'edit'])
  }

  goToCompany(id : string){
    this.router.navigate(['/companies', id])
  }

  goToContact(id : string){

  }

}
