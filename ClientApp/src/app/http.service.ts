import { HttpClient, HttpHandler } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { NGXLogger } from 'ngx-logger';
import { ReportByNet } from './reportbynet';
import { HttpParams } from "@angular/common/http";
import { UserSettings } from 'src/app/models/user-settings';



@Injectable()
export class HttpService {
  constructor(private http: HttpClient, private logger: NGXLogger) {
    this.logger.debug('Multiple', 'Argument', 'support');   
  }

  getDataByNet(params: HttpParams) {
    return this.http.get<ReportByNet>('reportbynet/get', { params });

  }

  PostGuid(user: UserSettings) {
    return this.http.post<UserSettings>('usersettings', user, { observe: 'response' });
  }

  GetReportForStores(params: HttpParams) {    
    return this.http.get<ReportByNet[]>('reportbynet/getreportforstores', { params });      
  }


}





