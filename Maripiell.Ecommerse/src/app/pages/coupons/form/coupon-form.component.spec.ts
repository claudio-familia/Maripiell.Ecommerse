import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CouponFormComponent } from './coupon-form.component';

describe('FormComponent', () => {
  let component: CouponFormComponent;
  let fixture: ComponentFixture<CouponFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CouponFormComponent]
    });
    fixture = TestBed.createComponent(CouponFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
