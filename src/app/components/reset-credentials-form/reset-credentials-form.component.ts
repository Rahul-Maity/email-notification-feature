import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-reset-credentials-form',
  templateUrl: './reset-credentials-form.component.html',
  styleUrl: './reset-credentials-form.component.css'
})
export class ResetCredentialsFormComponent {
  formData: any = {};
  constructor(private http:HttpClient){}
  resetCredentials() {
    this.http.post<any>('http://localhost:5299/api/ResetCredentials/reset', this.formData)
      .subscribe(
        response => {
          console.log('Reset credentials successful:', response); 
          // Add any additional handling after successful reset
        },
        error => {
          console.error('Reset credentials failed:', error);
          // Handle reset error
        }
      );
  }
}
