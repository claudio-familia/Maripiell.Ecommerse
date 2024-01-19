import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatCardModule } from '@angular/material/card';

import { CouponsRoutingModule } from './coupons-routing.module';
import { CouponsComponent } from './index/coupons.component';
import { CouponFormComponent } from './form/coupon-form.component';
import { MatButtonModule } from '@angular/material/button';


@NgModule({
  declarations: [
    CouponsComponent,
    CouponFormComponent
  ],
  imports: [
    CommonModule,
    CouponsRoutingModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatCardModule,
    MatButtonModule
  ]
})
export class CouponsModule { }
