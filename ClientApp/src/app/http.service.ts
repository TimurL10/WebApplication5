import { HttpClient, HttpHandler } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { NGXLogger } from 'ngx-logger';
import { ReportByNet } from './reportbynet';
import { HttpParams } from "@angular/common/http";
import { UserSettings } from 'src/app/models/user-settings';



@Injectable()
export class HttpService {
  public report: ReportByNet;
  constructor(private http: HttpClient, private logger: NGXLogger) {
    this.logger.debug('Multiple', 'Argument', 'support');   
  }

  getDataByNet(params: HttpParams) {
    return this.http.get<ReportByNet>('reportbynet', { params });
  }

  PostGuid(user: UserSettings) {
    return this.http.post<UserSettings>('usersettings/get', user, { observe: 'response' });
  }

  GetReportForStores(params: HttpParams) {
    this.logger.debug(params);
    return this.http.get<ReportByNet>('reportbynet/getreportforstores', { params });
  }


}





