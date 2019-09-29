import { TestBed } from '@angular/core/testing';

import { TicketrestaurantService } from './ticketrestaurant.service';

describe('TicketrestaurantService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TicketrestaurantService = TestBed.get(TicketrestaurantService);
    expect(service).toBeTruthy();
  });
});
