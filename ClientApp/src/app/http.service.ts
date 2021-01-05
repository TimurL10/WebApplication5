import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { ReportByNet } from './reportbynet';

@Injectable()
export class HttpService {
  public report: ReportByNet;
  constructor(private http: HttpClient) {

  }

  getDataByNet(baseUrl: string) {
    return this.http.get<ReportByNet>(baseUrl + 'reportbynet');
  }
}

