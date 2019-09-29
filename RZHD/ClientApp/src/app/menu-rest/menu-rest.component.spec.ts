import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuRestComponent } from './menu-rest.component';

describe('MenuRestComponent', () => {
  let component: MenuRestComponent;
  let fixture: ComponentFixture<MenuRestComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MenuRestComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuRestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
