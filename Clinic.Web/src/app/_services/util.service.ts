import { Injectable } from '@angular/core';

export const RoleMap = new Map([
  ['QE5#AGj@@UV+!Ad2@!msuv6!', 1], //Admin
  ['cMI(3H!++nysmyT5CwXe*sVf', 2], //Doctor
  ['M)tCXD%Y@uEQTj*@FLmuD)P$', 3] //Secretary
])

@Injectable({
  providedIn: 'root'
})

export class UtilService {

  constructor() { }


  checkUserType() {
    let secret = localStorage.getItem('xP98_g#d94H0w');
    return RoleMap.get(secret) || -1;
  }



  getBase64(file: any) {
    if (!file) {
      return new Promise((resolve, reject) => {
        resolve('');
      });
    }
    return new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onload = () => {
        resolve(reader.result);
      };
    });
  }
}
