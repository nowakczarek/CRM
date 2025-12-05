import { Component, inject } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { Auth } from '../auth/services/auth';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './layout.html',
  styleUrl: './layout.css'
})
export class Layout {
  
  private auth = inject(Auth)
  private router = inject(Router)

  logout(){
    this.auth.logout()
    this.router.navigate(['/login'])
  }

}
