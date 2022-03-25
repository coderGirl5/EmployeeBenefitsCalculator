import { TestBed } from '@angular/core/testing';

import { BenefitCalculatorServiceService } from './benefit-calculator-service.service';

describe('BenefitCalculatorServiceService', () => {
  let service: BenefitCalculatorServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BenefitCalculatorServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
