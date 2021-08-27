import { AddMeddicineComponent } from './add-meddicine/add-meddicine.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MedicineListComponent } from './medicine-list/medicine-list.component';


const routes: Routes = [
  { path: '', redirectTo: 'medicineList', pathMatch: 'full' },
  { path: 'medicineList', component: MedicineListComponent },
  { path: 'addItem', component: AddMeddicineComponent },
  { path: '**', redirectTo: 'medicineList' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
