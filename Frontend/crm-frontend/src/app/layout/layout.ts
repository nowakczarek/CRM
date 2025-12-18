import { Component, inject } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { Auth } from '../auth/services/auth';
import { MatButtonModule } from "@angular/material/button";
import { MatIconModule, MatIconRegistry } from '@angular/material/icon';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-layout',
  standalone: true,
  imports: [RouterModule, MatButtonModule, MatIconModule],
  templateUrl: './layout.html',
  styleUrl: './layout.css'
})
export class Layout {
  
  private auth = inject(Auth)
  private router = inject(Router)
  private iconRegistry = inject(MatIconRegistry)
  private sanitizer = inject(DomSanitizer)
  
  ngOnInit(){
    this.iconRegistry.addSvgIcon(
      'logout_icon.svg',
      this.sanitizer.bypassSecurityTrustResourceUrl('logout_icon.svg')
    )
    this.iconRegistry.addSvgIcon(
      'search_icon.svg',
      this.sanitizer.bypassSecurityTrustResourceUrl('search_icon.svg')
    )
  }

  logout(){
    this.auth.logout()
    this.router.navigate(['/login'])
  }

}
