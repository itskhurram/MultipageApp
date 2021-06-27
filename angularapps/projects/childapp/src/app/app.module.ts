import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BannerModule } from '../../../../src/app/banner/banner.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { SigninComponent } from './signin/signin.component';
import { SingupComponent } from './singup/singup.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    SigninComponent,
    SingupComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BannerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
