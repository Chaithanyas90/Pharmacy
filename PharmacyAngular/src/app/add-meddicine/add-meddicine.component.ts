import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-meddicine',
  templateUrl: './add-meddicine.component.html',
  styleUrls: ['./add-meddicine.component.css']
})
export class AddMeddicineComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  public addItemForm = new FormGroup({
    fullName: new FormControl('', Validators.required),
    brand: new FormControl('', Validators.required),
    price: new FormControl('', Validators.required),
    expiryDate: new FormControl('', Validators.required),
    quantity: new FormControl('', Validators.required),
    notes: new FormControl('', Validators.required),
  });

  get validateForms(){
    return this.addItemForm.controls;
  }

  addItem(){
    console.log("---", this.addItemForm.value)
  }

}
