import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { HttpParams } from "@angular/common/http";
import { HttpService } from 'src/app/http.service';
import { ReportByNet } from 'src/app/reportbynet';




@Component({
    selector: 'app-store-report',
    templateUrl: './store-report.component.html',
    styleUrls: ['./store-report.component.css'],    
      providers: [HttpService]

})
/** StoreReport component*/
export class StoreReportComponent {
  report: ReportByNet;
  start: string;
  end: string;
  params: HttpParams;
  range = new FormGroup({
    start: new FormControl(),
    end: new FormControl()
  });
  /** StoreReport ctor */
  constructor(private httpService: HttpService) {

  }

  loadReport() {
    this.start = this.range.value.start;
    this.end = this.range.value.end;
    this.params = new HttpParams().set('start', this.start).set('end', this.end);
    this.httpService.GetReportForStores(this.params).subscribe((data: ReportByNet) => this.report = data,
      error => console.error(error));
  }
}
