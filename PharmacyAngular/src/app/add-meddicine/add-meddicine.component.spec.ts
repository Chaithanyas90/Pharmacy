import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddMeddicineComponent } from './add-meddicine.component';

describe('AddMeddicineComponent', () => {
  let component: AddMeddicineComponent;
  let fixture: ComponentFixture<AddMeddicineComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddMeddicineComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddMeddicineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
