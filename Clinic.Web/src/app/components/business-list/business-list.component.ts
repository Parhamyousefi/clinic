import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { SharedModule } from '../../share/shared.module';
import { MainService } from '../../_services/main.service';

@Component({
  selector: 'app-business-list',
  standalone: true,
  imports: [SharedModule, RouterLink],
  templateUrl: './business-list.component.html',
  styleUrl: './business-list.component.css'
})
export class BusinessListComponent implements OnInit {

  constructor(
    private router: Router,
    private mainService: MainService
  ) { }

  clinicsList: any = [];

  ngOnInit(): void {
    this.getClinics();
  }

  async getClinics() {
    try {
      let res = await this.mainService.getClinics().toPromise();
      this.clinicsList = res;
    }
    catch {
    }
  }

  goToNewBusiness(id) {
    this.router.navigate(['/new-business', id]);
  }
}