import { HttpClient, HttpHandler } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { NGXLogger } from 'ngx-logger';
import { ReportByNet } from './reportbynet';
import { HttpParams } from "@angular/common/http";



@Injectable()
export class HttpService {
  public report: ReportByNet;
  constructor(private http: HttpClient, private logger: NGXLogger) {
    this.logger.debug('Multiple', 'Argument', 'support');   
  }

  getDataByNet(params: HttpParams) {
    return this.http.get<ReportByNet>('reportbynet', { params });
  }
}





