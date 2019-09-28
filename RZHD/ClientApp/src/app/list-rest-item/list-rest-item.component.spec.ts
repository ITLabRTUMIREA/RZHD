import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListRestItemComponent } from './list-rest-item.component';

describe('ListRestItemComponent', () => {
  let component: ListRestItemComponent;
  let fixture: ComponentFixture<ListRestItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListRestItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListRestItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
