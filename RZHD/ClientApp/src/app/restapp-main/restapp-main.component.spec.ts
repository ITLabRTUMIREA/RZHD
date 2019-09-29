import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RestappMainComponent } from './restapp-main.component';

describe('RestappMainComponent', () => {
  let component: RestappMainComponent;
  let fixture: ComponentFixture<RestappMainComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RestappMainComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RestappMainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
