import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CouponsComponent } from './index/coupons.component';
import { CouponFormComponent } from './form/coupon-form.component';

const routes: Routes = [
  {
    path: "",
    component: CouponsComponent
  },
  {
    path: "create",
    component: CouponFormComponent
  },
  {
    path: "edit/:id",
    component: CouponFormComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CouponsRoutingModule { }
