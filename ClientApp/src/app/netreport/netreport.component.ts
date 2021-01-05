import { Component, OnInit, Inject } from '@angular/core';
import { HttpService } from 'src/app/http.service'
import { ReportByNet } from 'src/app/reportbynet';


@Component({
    selector: 'app-netreport',
    templateUrl: './netreport.component.html',
    styleUrls: ['./netreport.component.css'],
    providers: [HttpService]
})
/** netreport component*/
export class NetreportComponent implements OnInit {
  @Inject('BASE_URL') baseUrl: string;
  report: ReportByNet;
  /** netreport ctor */
  constructor(private httpService: HttpService) {

  }
  ngOnInit() {
    this.loadReport();
  }

  loadReport() {
    this.httpService.getDataByNet(this.baseUrl).subscribe((data: ReportByNet) => this.report = data,
      error => console.error(error));
  }

}
