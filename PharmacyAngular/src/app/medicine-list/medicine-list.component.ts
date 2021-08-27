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

  public medicineList: Medicine[] = [];
  public filteredMedicineList: Medicine[] = [];
  private _searchString:string;
  get searchString(): string{ return this._searchString;} 
  set searchString(value:string)
  {
    this._searchString = value;
    this.filteredMedicineList = this.filteredMedicines(value);
  }

  filteredMedicines(searchString)
  {
    return  this.medicineList.filter(medicine => medicine.fullName.toLowerCase().indexOf(searchString.toLowerCase()) !== -1) 
  }
  headers: any = ["id", "fullName", "brand", "price", "expiryDate", "quantity"];

  constructor(private appService:AppService, private notificationService: NotificationService) { }

  ngOnInit(): void {
    this.getMedicineList();    
  }

  getBackgroundColor(medicine:Medicine){
    
    var color:string;
    if(medicine.quantity < 10){
      color = "yellow";
    }
    return color;
  }
  getMedicineList(){
    this.appService.getMedicineList().subscribe((response) => 
    {
      if(response && response[AppConstants.response.responseResult] == "Success")
      {
        this.medicineList = response[AppConstants.response.listInfo];
        this.filteredMedicineList = this.medicineList;
      }else{
        this.notificationService.showErrorMessage("Error occured while fetching the list of medicines", "Medicine List");
      }
    },
    (error) => {
      this.notificationService.showErrorMessage("Error occured while fetching the list of medicines", "Medicine List");
    });
  }
}
