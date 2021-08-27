import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MedicineListComponent } from './medicine-list/medicine-list.component';
import { ToastrModule } from 'ngx-toastr';
import { HttpClientModule } from '@angular/common/http';
import { AddMeddicineComponent } from './add-meddicine/add-meddicine.component';


@NgModule({
  declarations: [
    AppComponent,
    MedicineListComponent,
    AddMeddicineComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ToastrModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
