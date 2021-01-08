import { Component, OnInit, Inject } from '@angular/core';
import { HttpService } from 'src/app/http.service'
import { HttpClient } from '@angular/common/http';
import { NGXLogger } from 'ngx-logger';
import { ReportByNet } from 'src/app/reportbynet';
import { FormGroup, FormControl } from '@angular/forms';
import { HttpParams } from "@angular/common/http";
import { HttpHeaders } from "@angular/common/http";




@Component({
    selector: 'app-netreport',
    templateUrl: './netreport.component.html',
    styleUrls: ['./netreport.component.css'],
    providers: [HttpService]
})

/** netreport component*/
export class NetreportComponent {
  start: string;
  end: string;
  public currentCount = 0;
  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl()
  });
  params: HttpParams;
  headers = new HttpHeaders()
    .set("start", "${this.name}");

  report: ReportByNet;

  @Inject('BASE_URL') baseUrl: string;

  constructor(private httpService: HttpService, http: HttpClient, private logger: NGXLogger) {
    
  }

  makeFloor(num: number) {
    return Math.floor(num);
  }

  loadReport() {   

    this.start = this.range.value.start;
    this.end = this.range.value.end;
    console.log(this.range);
    console.log(this.start);
    console.log(this.end);
    this.params = new HttpParams().set('start', this.start).set('end', this.end);

    this.httpService.getDataByNet(this.params).subscribe((data: ReportByNet) => this.report = data,
      error => console.error(error));
  }

}

//interface ReportByNet {

//  stores_count: number;

//  orders_count: number;

//  sold_orders: number;

//  time_out_canceled: number;

//  customer_canceled_orders: number;

//  no_end_status_ord: number;

//  canceled_ord: number;

//  no_receive_status_ord: number
//}
