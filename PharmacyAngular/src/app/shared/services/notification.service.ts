import { Injectable } from '@angular/core';
//import { ToastrService } from 'ngx-toastr';
@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  //constructor(private toast : ToastrService) { }

  successMessage(message:string, title:string){
    //this.toast.success(message, title);
  }

  showErrorMessage(message:string, title:string){
    //this.toast.error(message, title);
  }

  showWarningMessage(message:string, title:string){
    //this.toast.warning(message, title);
  }

  showINfoMessage(message:string, title:string){
    //this.toast.info(message, title);
  }

}
