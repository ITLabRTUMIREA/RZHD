import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManualScannerComponent } from './manual-scanner.component';

describe('ManualScannerComponent', () => {
  let component: ManualScannerComponent;
  let fixture: ComponentFixture<ManualScannerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManualScannerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManualScannerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
