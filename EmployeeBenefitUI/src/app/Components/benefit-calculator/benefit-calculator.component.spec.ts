import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BenefitCalculatorComponent } from './benefit-calculator.component';

describe('BenefitCalculatorComponent', () => {
  let component: BenefitCalculatorComponent;
  let fixture: ComponentFixture<BenefitCalculatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BenefitCalculatorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BenefitCalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
