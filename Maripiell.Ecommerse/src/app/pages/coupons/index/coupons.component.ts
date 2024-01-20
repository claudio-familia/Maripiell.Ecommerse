import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatTable } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { CouponsDataSource, CouponsItem } from './coupons-datasource';
import { HttpClient } from '@angular/common/http';
import { Subscription, delay } from 'rxjs';

@Component({
  selector: 'mall-coupons',
  templateUrl: './coupons.component.html',
  styleUrls: ['./coupons.component.scss'],
})
export class CouponsComponent implements OnInit, OnDestroy {
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatTable) table!: MatTable<CouponsItem>;
  subscription: Subscription = new Subscription();
  dataSource?: CouponsDataSource = new CouponsDataSource([]);

  displayedColumns = ['id', 'code', 'discountAmount', 'minAmount', 'action'];

  nameColumns: any = {
    id: 'ID',
    code: 'Code',
    discountAmount: 'Discount',
    minAmount: 'Min',
  };

  constructor(private http: HttpClient) {}

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
    this.dataSource!.disconnect();
  }

  ngOnInit(): void {
    this.getData();
  }

  getData(): void {
    this.subscription.add(
      this.http
        .get<CouponsItem[]>('https://localhost:7001/Coupon')
        .pipe(delay(2000))
        .subscribe((data) => {
          this.dataSource = new CouponsDataSource(data);
          this.initDataSource();
        })
    );
  }

  initDataSource(): void {
    if (this.dataSource) {
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
      this.table.dataSource = this.dataSource;
    }
  }

  deleteCoupon(id: number) {
    console.log('deleteCoupon', id)
    this.http.delete<CouponsItem>('https://localhost:7001/Coupon/'+id).subscribe(data => {
      console.log(data);
      this.getData();
    });
  }
}
