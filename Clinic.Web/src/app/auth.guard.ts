import { isPlatformBrowser } from '@angular/common';
import { Injectable } from '@angular/core';
import { CanActivate, Router, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { AuthService } from './_services/auth.service';
// import { UtilService } from './_services/util.service';
export function checkRequierd() {
  let token = localStorage.getItem('token');
  return token

}
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  private tokenSubject = new BehaviorSubject<string | null>(null);
  constructor(
    private router: Router,
    private authService: AuthService
    //  private utilService: UtilService
  ) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {

    if (this.authService.isLoggedIn()) {
      return true;
    } else {
      this.router.navigate(['/login']);
    }
    // if (!checkRequierd()) {
    //   this._router.navigate(['/'], { queryParams: { returnUrl: state.url } });
    //   this.clear();
    //   return false;
    // }
    // if (this.utilService.checkUserType() === -1) {
    //   this._router.navigate(['/'], { queryParams: { returnUrl: state.url } });
    //   this.clear();
    //   return false;
    // }
    return true;
  }

  clear() {
    localStorage.removeItem('txcd94Hg_doH63');
    localStorage.removeItem('schoolId');
    localStorage.removeItem('operator');
    localStorage.removeItem('jwt');
    localStorage.removeItem('userLoginId');
    localStorage.removeItem('username');
    localStorage.removeItem('regionId');
    localStorage.removeItem('mobile');
    localStorage.removeItem('token');
  }


  logout(): void {
    this.tokenSubject.next(null);
    this.router.navigate(['/login']);
  }
}
// @Injectable({
//   providedIn: 'root'
// })
// export class AdminAuthGuard implements CanActivate {
//   constructor(private _router: Router, private utilService: UtilService) { }
//   canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
//     let roles = route.data.roles;
//     let userType = this.utilService.checkUserType();
//     if (roles && !roles.includes(userType)) {
//       let url = this._router.url;
//       this._router.navigate(['/'], { queryParams: { returnUrl: state.url } });
//       this.clear();
//       return false;
//     }
//     return true;
//   }

//   clear() {
//     localStorage.removeItem('txcd94Hg_doH63');
//     localStorage.removeItem('schoolId');
//     localStorage.removeItem('operator');
//     localStorage.removeItem('jwt');
//     localStorage.removeItem('userLoginId');
//     localStorage.removeItem('username');
//     localStorage.removeItem('regionId');
//     localStorage.removeItem('mobile');
//     localStorage.removeItem('token');
//   }
// }

