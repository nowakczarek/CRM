import { Component, inject } from '@angular/core';
import { ContactService } from '../../../services/contact.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-form',
  imports: [],
  templateUrl: './form.html',
  standalone: true,
  styleUrl: './form.css'
})
export class Form {
  private contactService = inject(ContactService)
  private route = inject(ActivatedRoute)

  ngOnInit(){
    const id = this.route.snapshot.paramMap.get('id')

    if(!id) return

    this.contactService.getById(id)
  }
}
