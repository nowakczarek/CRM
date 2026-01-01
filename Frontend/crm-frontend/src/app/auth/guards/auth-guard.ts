import { CanActivateFn, Router } from '@angular/router';
import { Auth } from '../services/auth';
import { inject } from '@angular/core';

export const authGuard: CanActivateFn = () => {
  const authService = inject(Auth)
  const router = inject(Router)

  console.log("AuthGuard triggered")
  console.log('Token: ', authService.getToken())

  if (authService.isLoggedIn())
  {
    console.log("Access granted")
    return true
  }

  console.log("Redirecting to login")
  router.navigate(['login'])
  return false;
};
