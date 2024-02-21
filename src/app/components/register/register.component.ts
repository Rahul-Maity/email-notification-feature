import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  formData: any = {};

  constructor(private http:HttpClient) {}

  submitForm() {
   
    this.http.post<any>('http://localhost:5299/api/Email', this.formData)
      .subscribe(
        response => {
          console.log('Registration successful:', response); 
          // Add any additional handling after successful registration
        },
        error => {
          console.error('Registration failed:', error);
          // Handle registration error
        }
      );
  }
}