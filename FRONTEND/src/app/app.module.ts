import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';

import { RegisterComponent } from './components/register/register.component';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RegistrationSuccessComponent } from './components/registration-success/registration-success.component';
import { RouterModule, Routes } from '@angular/router';
import { ResetCredentialsFormComponent } from './components/reset-credentials-form/reset-credentials-form.component';
import { ToastrModule, provideToastr } from 'ngx-toastr';

const routes: Routes = [
  { path: '', component: RegisterComponent },
  { path: 'success', component: RegistrationSuccessComponent },
  {path:'reset-credentials',component:ResetCredentialsFormComponent}
];
@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    RegistrationSuccessComponent,
    ResetCredentialsFormComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes),
    ToastrModule.forRoot(),
    
  ],
  providers: [provideToastr()],
  bootstrap: [AppComponent]
})
export class AppModule { }
