import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration-success',
  templateUrl: './registration-success.component.html',
  styleUrls:[ './registration-success.component.css']
})
export class RegistrationSuccessComponent {
constructor(private router:Router){}
  resetCredentials() {
    this.router.navigate(['/reset-credentials']);
  }

}
