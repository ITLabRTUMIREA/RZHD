import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BasketRestComponent } from './basket-rest.component';

describe('BasketRestComponent', () => {
  let component: BasketRestComponent;
  let fixture: ComponentFixture<BasketRestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BasketRestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BasketRestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
