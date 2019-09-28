import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ScannerGuideComponent } from './scanner-guide.component';

describe('ScannerGuideComponent', () => {
  let component: ScannerGuideComponent;
  let fixture: ComponentFixture<ScannerGuideComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ScannerGuideComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ScannerGuideComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
