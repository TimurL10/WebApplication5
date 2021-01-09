import { Component } from '@angular/core';
import { UserSettings } from 'src/app/models/user-settings';
import { HttpService } from 'src/app/http.service';
import { HttpResponse } from '@angular/common/http';

@Component({
    selector: 'app-settings',
    templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css'],
  providers: [HttpService]

})
/** settings component*/
export class SettingsComponent {

  user: UserSettings = {
    id: 1,
    netGuid: '',
    email: '',
    password: ''
  };
  guid: string;

  /** settings ctor */
  constructor(private httpService: HttpService) {

  }

  PostGuidToDb() {
    this.httpService.PostGuid(this.user).subscribe((data: HttpResponse<UserSettings>) => {
      console.log(this.user);
    });
  }

}
