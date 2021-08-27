import { NotificationService } from './../shared/services/notification.service';
import { AppConstants } from '../shared/app-constants';
import { Medicine } from './../shared/models/medicine.model';
import { Component, OnInit } from '@angular/core';
import { AppService } from '../shared/services/app.service';

@Component({
  selector: 'app-medicine-list',
  templateUrl: './medicine-list.component.html',
  styleUrls: ['./medicine-list.component.css']
})
export class MedicineListComponent implements OnInit {

  public MedicineList: Medicine[] = [];
  searchString:string = ""
  title:any = 'CustomTable';

  headers: any = ["id", "fullName", "brand", "price", "expiryDate", "quantity"];

  constructor(private appService:AppService, private notificationService: NotificationService) { }

  ngOnInit(): void {
    this.getMedicineList();    
  }

  getMedicineList(){
    this.appService.getMedicineList().subscribe((response) => 
    {
      if(response && response[AppConstants.response.responseResult] == "Success")
      {
        this.MedicineList = response[AppConstants.response.listInfo]
      }else{
        this.notificationService.showErrorMessage("Error occured while fetching the list of medicines", "Medicine List");
      }
    },
    (error) => {
      this.notificationService.showErrorMessage("Error occured while fetching the list of medicines", "Medicine List");
    });
  }
}
