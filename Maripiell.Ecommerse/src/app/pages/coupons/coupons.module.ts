import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';

import { CouponsRoutingModule } from './coupons-routing.module';
import { CouponsComponent } from './index/coupons.component';
import { CouponFormComponent } from './form/coupon-form.component';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import { CoreModule } from 'src/app/core/core.module';
import { MatIconModule } from '@angular/material/icon';


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
    MatButtonModule,
    ReactiveFormsModule,
    MatIconModule,
    CoreModule
  ]
})
export class CouponsModule { }
