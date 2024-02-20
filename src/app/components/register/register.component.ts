import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {


  constructor(private http: HttpClient) {}

  register(user: any) {
    const newUser = {
      email: user.email,
      password: user.password
    };

    this.http.post<any>('https://localhost:5001/api/register', newUser)
      .subscribe(
        response => {
          console.log('Registration successful:', response);
          alert('Registration successful! Please check your email for confirmation.');
        },
        error => {
          console.error('Registration failed:', error);
          alert('Registration failed. Please try again later.');
        }
      );
  }
}