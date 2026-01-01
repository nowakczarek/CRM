import { Component, inject } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { Auth } from '../auth/services/auth';
import { MatButtonModule } from "@angular/material/button";
import { MatIconModule} from '@angular/material/icon';
import { GlobalSearch } from "../global-search/global-search";

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [RouterModule, MatButtonModule, MatIconModule, GlobalSearch],
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
