import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListRestStationsComponent } from './list-rest-stations.component';

describe('ListRestStationsComponent', () => {
  let component: ListRestStationsComponent;
  let fixture: ComponentFixture<ListRestStationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListRestStationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListRestStationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
