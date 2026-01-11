import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { LeadService } from '../../../services/lead.service';
import { FullLead, Lead } from '../../../models/lead.model';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { LeadStage } from '../../../models/enums/lead-stage';
import { DatePipe } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-list',
  imports: [MatCardModule, MatIconModule, MatMenuModule, DatePipe, MatButtonModule],
  templateUrl: './list.html',
  styleUrl: './list.css'
})
export class List {

  private router = inject(Router)
  private leadService = inject(LeadService)

  leads : FullLead[] = []
  lead!: Lead
  totalValue = 0
  activeLeads = 0

  ngOnInit(){
    this.leadService.getAll().subscribe(r =>{
      this.leads = r 
      this.leads.forEach(lead =>  {
        if( lead.stage == LeadStage.New || lead.stage == LeadStage.Negotiations) {
          this.totalValue += lead.value
          this.activeLeads += 1
        }
      }
      )
    })
  }

  getStageName(stage: LeadStage): string{
    return LeadStage[stage]
  }

  getStageClass(stage: LeadStage): string{
    return 'stage-' + LeadStage[stage].toLocaleLowerCase()
  }

  newLead(){
    this.router.navigate(['leads/new'])
  }

  editLead(id: string){
    this.leadService.getById(id).subscribe(r => {
      this.lead = r
      this.router.navigate(['/companies', this.lead.companyId, 'contacts', this.lead.contactId, 'leads', id, 'edit'])
    })
  }

}
