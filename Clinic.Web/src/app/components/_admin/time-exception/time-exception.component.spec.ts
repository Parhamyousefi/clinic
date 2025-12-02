import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimeExceptionComponent } from './time-exception.component';

describe('TimeExceptionComponent', () => {
  let component: TimeExceptionComponent;
  let fixture: ComponentFixture<TimeExceptionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TimeExceptionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TimeExceptionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
