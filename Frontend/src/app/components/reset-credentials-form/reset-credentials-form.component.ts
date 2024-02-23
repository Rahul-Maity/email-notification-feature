import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-reset-credentials-form',
  templateUrl: './reset-credentials-form.component.html',
  styleUrl: './reset-credentials-form.component.css'
})
export class ResetCredentialsFormComponent {
  formData: any = {};
  constructor(private http:HttpClient,private toastr:ToastrService,private router:Router){}
  resetCredentials() {
    this.http.post('http://localhost:5299/api/ResetCredentials/reset', this.formData, { responseType: 'text' })
      .subscribe(
        response => {
          console.log('Reset credentials successful:', response); 
          this.toastr.success('Your password have been resetted successfully', 'credentials updated');
          this.router.navigate(['/success'])
        },
        error => {
          console.error('Reset credentials failed:', error);
          // Handle reset error
         
        }
      );
  }
}
