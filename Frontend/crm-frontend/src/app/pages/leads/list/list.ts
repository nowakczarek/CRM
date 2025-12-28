import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { LeadService } from '../../../services/lead.service';
import { FullLead, Lead } from '../../../models/lead.model';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { LeadStage } from '../../../models/enums/lead-stage';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-list',
  imports: [MatCardModule, MatIconModule, MatMenuModule, DatePipe],
  templateUrl: './list.html',
  styleUrl: './list.css'
})
export class List {

  private router = inject(Router)
  private leadService = inject(LeadService)

  leads : FullLead[] = []
  totalValue = 0

  ngOnInit(){
    this.leadService.getAll().subscribe(r =>
      this.leads = r 
    )
  }

  getStageName(stage: LeadStage): string{
    return LeadStage[stage]
  }

  getStageClass(stage: LeadStage): string{
    return 'stage=' + LeadStage[stage].toLocaleLowerCase()
  }

  newLead(){
    this.router.navigate(['leads/new'])
  }

  editLead(id: string){

  }

  goToDetails(id: string){

  }

}
