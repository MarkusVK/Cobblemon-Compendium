import { TestBed } from '@angular/core/testing';

import { Cobblemon } from './cobblemon';

describe('Cobblemon', () => {
  let service: Cobblemon;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Cobblemon);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
