import { Component, inject } from '@angular/core';
import { ContactService } from '../../../services/contact.service';

@Component({
  selector: 'app-details',
  imports: [],
  templateUrl: './details.html',
  styleUrl: './details.css'
})
export class Details {
  private contactService = inject(ContactService)

  ngOnInit(){

  }
  

}
