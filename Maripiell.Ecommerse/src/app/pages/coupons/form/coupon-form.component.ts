import { HttpClient } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, UntypedFormGroup, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { CouponsItem } from '../index/coupons-datasource';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'mall-form',
  templateUrl: './coupon-form.component.html',
  styleUrls: ['./coupon-form.component.scss']
})
export class CouponFormComponent implements OnDestroy, OnInit {

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private activatedRoute: ActivatedRoute
  ) { }

  couponForm: FormGroup = this.fb.group({
    code: ["", Validators.required],
    discountAmount: [0, [Validators.required]],
    minAmount: [0, [Validators.required, Validators.min(500)]],
  });
  currentId: number = 0;

  submitCoupon(): void {
    if (this.couponForm.valid) {
      this.isEdit ? this.updateCoupon() : this.createCoupon();
    } else {
      alert("There is an error");
    }
  }

  createCoupon(): void {
    this.http.post<CouponsItem>("https://localhost:7001/Coupon", this.couponForm.value).subscribe(data => {
      console.log(data)
    });
  }

  updateCoupon(): void {
    const data = {
      ...this.couponForm.value,
      id: this.currentId
    }
    this.http.put<CouponsItem>("https://localhost:7001/Coupon", data).subscribe(data => {
      console.log(data)
    });
  }

  get isEdit() {
    return this.currentId > 0;
  }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params => {
      const id = params["id"];
      this.http.get<CouponsItem>("https://localhost:7001/Coupon/"+id).subscribe(data => {
        this.currentId = id;
        const values: any = {...data};
        delete values.id;
        this.couponForm.setValue(values);
      });
    });
  }

  ngOnDestroy(): void {
  }
}
