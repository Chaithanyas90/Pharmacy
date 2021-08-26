import { AppConstants } from './../app-constants';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor(private http: HttpClient) { }

  getMedicineList(){
    return this.http.get(`${AppConstants.baseUrl}api/Medicines/GetMedicineList`);
  }
}
